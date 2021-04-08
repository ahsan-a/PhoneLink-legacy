using Mayerch1.GithubUpdateCheck;
using Microsoft.Toolkit.Uwp.Notifications;
using SimpleHttp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Phonelink
{
    public partial class Form1 : Form
    {
        static string AppVersion = "1.4.0";

        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern int ExitWindowsEx(uint uFlags, uint dwReason);

        //needed to lock PC
        [System.Runtime.InteropServices.DllImport("user32")]
        public static extern void LockWorkStation();

        public Form1()
        {
            InitializeComponent();
        }

        public static Configuration Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateMenus();
            SendUpdateNotif();
            Route.Add("/", (req, res, args) =>
            {
                res.AsText("server is up, send a link!");
            });

            var baseUrl = Convert.ToBoolean(Config.AppSettings.Settings["passwordEnabled"].Value) ? "/" + Config.AppSettings.Settings["password"].Value + "/" : "/";
            Route.Add($"{baseUrl}url/{{url}}", (req, res, args) =>
            {
                var url = args["url"];
                if (!(url.StartsWith("http"))) url = $"http://{url}";
                System.Diagnostics.Process.Start($"{url}");
                res.AsText($"opened {url} on your computer.");
                GC.Collect();
            });

            Route.Add($"{baseUrl}file", (req, res, args) =>
                {
                    SaveFile(req, res, args);
                    GC.Collect();
                },
                "POST");

            Route.Add($"{baseUrl}notification", (req, res, args) =>
                {
                    SendNotification(req.Headers["title"], req.Headers["body"]);
                    res.AsText($"sent a notification with the title as \"{req.Headers["title"]}\" and the content body as \"{req.Headers["body"]}\"");
                });
                
            Route.Add($"{baseUrl}power/{{state}}", (req, res, args) =>
            {
                Console.WriteLine("called");
                res.AsText(handlePower(args["state"]));
                });


            HttpServer.ListenAsync(
                Convert.ToInt32(Config.AppSettings.Settings["port"].Value),
                System.Threading.CancellationToken.None,
                Route.OnHttpRequestAsync
            );

            Console.WriteLine(baseUrl);
        }

        private void SendNotification(string notifTitle, string body)
        {
            new ToastContentBuilder()
                .AddText(notifTitle)
                .AddText(body)
                .Show();
        }

        private void SendUpdateNotif()
        {
            if (Convert.ToBoolean(Config.AppSettings.Settings["passwordEnabled"].Value))
            {
                var update = new GithubUpdateCheck("ahsan-a", "PhoneLink");
                var isUpdate = update.IsUpdateAvailable(AppVersion, VersionChange.Minor);
                if (isUpdate)
                {
                    SendNotification("PhoneLink Update Available",
                        "Update to get the latest features. A new release is available on the Github repository. You can disable checking for releases in the PhoneLink menu.");
                }
            }
        }

        private void UpdateMenus()
        {
            contextUpdateCheck.Checked = Convert.ToBoolean(Config.AppSettings.Settings["checkNewRelease"].Value);
            contextEnablePassword.Checked = Convert.ToBoolean(Config.AppSettings.Settings["passwordEnabled"].Value);
            PortInput.Text = Config.AppSettings.Settings["port"].Value;
            PasswordInput.Text = Config.AppSettings.Settings["password"].Value;
            EnablePasswordBox.Checked = Convert.ToBoolean(Config.AppSettings.Settings["passwordEnabled"].Value);
            UpdateCheckBox.Checked = Convert.ToBoolean(Config.AppSettings.Settings["checkNewRelease"].Value);
            currentFilelocation.Text = Config.AppSettings.Settings["currentSavePath"].Value;
        }

        private void UpdateAppConfig()
        {
            Config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            UpdateMenus();
        }

        private void SaveFile(HttpListenerRequest req, HttpListenerResponse res, Dictionary<string, string> args)
        {
            var files = req.ParseBody(args);
            //save files
            foreach (var f in files.Values)
            {
                try
                {
                    using (var file = new FileStream(
                        $"{Config.AppSettings.Settings["currentSavePath"].Value}/{f.FileName}", FileMode.CreateNew,
                        FileAccess.Write))
                    {
                        f.Value.CopyTo(file);
                        res.AsText($"Copied {Convert.ToString(f.FileName)} to the {Config.AppSettings.Settings["currentSavePath"].Value} folder.");
                    }
                }
                catch (Exception ex)
                {
                    if (ex.HResult == -2147024816)
                    {
                        var path = getFileName(f.FileName, Config.AppSettings.Settings["currentSavePath"].Value, 0);
                        using (var file = new FileStream(path, FileMode.CreateNew, FileAccess.Write))
                        {
                            f.Value.CopyTo(file);
                            res.AsText($"Copied {Convert.ToString(f.FileName)} to the {Config.AppSettings.Settings["currentSavePath"].Value} folder.");
                        }
                    }
                }
            }
        }

        private string getFileName(string fileName, string path, int i)
        {
            while (File.Exists($"{path}/{Path.GetFileNameWithoutExtension(fileName)} ({i}){Path.GetExtension(fileName)}")) i++;
            return $"{path}/{Path.GetFileNameWithoutExtension(fileName)} ({i}){Path.GetExtension(fileName)}";
        }

        private string handlePower(string state)
        {
            switch (state)
            {
                case "shutdown":
                    Process.Start("shutdown", "/s /t 0");
                    return "Shut down successfully.";
                case "restart":
                    Process.Start("shutdown", "/r /t 0");
                    return "Restarted successfully.";
                case "logout":
                    ExitWindowsEx(0, 0);
                    return "Logged off successfully.";
                case "lock":
                    LockWorkStation();
                    return "Locked successfully.";
                default: return "Invalid argument.";
            }
        }

        // Auto generated methods

        private void Form1_Shown(object sender, EventArgs e)
        {
            Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem1_CheckedChanged(object sender, EventArgs e)
        {
            Config.AppSettings.Settings["checkNewRelease"].Value = Convert.ToString(contextUpdateCheck.Checked);
            UpdateAppConfig();
        }

        private void toolStripMenuItem1_CheckedChanged_1(object sender, EventArgs e)
        {
            Config.AppSettings.Settings["passwordEnabled"].Value = Convert.ToString(contextUpdateCheck.Checked);
            UpdateAppConfig();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void trayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Show();
                WindowState = FormWindowState.Normal;
            }
        }

        private void SubmitNewSettings_Click(object sender, EventArgs e)
        {
            Config.AppSettings.Settings["port"].Value = PortInput.Text;
            Config.AppSettings.Settings["password"].Value = PasswordInput.Text;
            Config.AppSettings.Settings["checkNewRelease"].Value = Convert.ToString(UpdateCheckBox.Checked);
            Config.AppSettings.Settings["passwordEnabled"].Value = Convert.ToString(UpdateCheckBox.Checked);
            UpdateAppConfig();
            MessageBox.Show(
                        "Saved settings. Changing certain settings such as your port and password may need you to restart your app to take effect.");
            Hide();
        }

        private void EditSaveFileLocation_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    Config.AppSettings.Settings["currentSavePath"].Value = fbd.SelectedPath;
                }
                UpdateAppConfig();
            }
        }

        private void OpenSettings_Click(object sender, EventArgs e)
        {
            Show();
        }
    }
}
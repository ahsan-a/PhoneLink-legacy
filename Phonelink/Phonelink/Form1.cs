using Mayerch1.GithubUpdateCheck;
using Microsoft.Toolkit.Uwp.Notifications;
using SimpleHttp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Phonelink
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static Configuration Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateMenus();
            SendUpdateNotif();
            Route.Add("/", (req, res, props) =>
            {
                res.AsText("server is up, send a link!");
            });

            var baseUrl = Convert.ToBoolean(Config.AppSettings.Settings["passwordEnabled"].Value) ? "/" + Config.AppSettings.Settings["password"].Value + "/" : "/";
            Route.Add($"{baseUrl}url/{{url}}", (req, res, props) =>
            {
                var url = props["url"];
                if (!(url.StartsWith("http"))) url = $"http://{url}";
                System.Diagnostics.Process.Start($"{url}");
                res.AsText($"opened {url} on your computer.");
                GC.Collect();
            });

            Route.Add($"{baseUrl}file", (req, res, props) =>
                {
                    SaveFile(req, res, props);
                    GC.Collect();
                },
                "POST");

            HttpServer.ListenAsync(
                Convert.ToInt32(Config.AppSettings.Settings["port"].Value),
                System.Threading.CancellationToken.None,
                Route.OnHttpRequestAsync
            );

            Console.WriteLine("server ready");
        }

        private static void SendUpdateNotif()
        {
            if (Convert.ToBoolean(Config.AppSettings.Settings["passwordEnabled"].Value))
            {
                var update = new GithubUpdateCheck("ahsan-a", "PhoneLink");
                var isUpdate = update.IsUpdateAvailable(ConfigurationManager.AppSettings.Get("currentVersion"), VersionChange.Minor);
                if (isUpdate)
                {
                    new ToastContentBuilder()
                        .AddText("PhoneLink Update Available")
                        .AddText("Update to get the latest features. A new release is available on the Github repository. You can disable checking for releases in the PhoneLink menu.")
                        .AddArgument("action", "openGithub")
                        .Show();
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
                Directory.CreateDirectory(Config.AppSettings.Settings["currentSavePath"].Value);
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
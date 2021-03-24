using Mayerch1.GithubUpdateCheck;
using Microsoft.Toolkit.Uwp.Notifications;
using SimpleHttp;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace Phonelink
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void UpdateContextMenu()
        {
            contextUpdateCheck.Checked = Convert.ToBoolean(Config.AppSettings.Settings["checkNewRelease"].Value);
            contextEnablePassword.Checked = Convert.ToBoolean(Config.AppSettings.Settings["passwordEnabled"].Value);
        }

        private void updateAppConfig()
        {
            Config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static Configuration Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateContextMenu();
            if (Convert.ToBoolean(Config.AppSettings.Settings["passwordEnabled"].Value))
            {
                GithubUpdateCheck update = new GithubUpdateCheck("ahsan-a", "PhoneLink");
                bool isUpdate = update.IsUpdateAvailable(ConfigurationManager.AppSettings.Get("currentVersion"), VersionChange.Minor);
                if (isUpdate)
                {
                    new ToastContentBuilder()
                        .AddText("Phonelink Update Available")
                        .AddText("Update to get the latest features. A new release is available on the Github repository. You can disable checking for releases in the PhoneLink menu.")
                        .AddArgument("action", "openGithub")
                        .Show();
                }
            }

            Route.Add("/", (req, res, props) =>
            {
                res.AsText("server is up, send a link!");
            });

            var baseUrl = Convert.ToBoolean(Config.AppSettings.Settings["passwordEnabled"].Value) ? "/" + Config.AppSettings.Settings["password"].Value + "/" : "/";
            Console.WriteLine(baseUrl);
            Route.Add($"{baseUrl}url/{{url}}", (req, res, props) =>
            {
                var url = props["url"];
                System.Diagnostics.Process.Start($"{url}");
                res.AsText($"opened {url} on your computer.");
            });

            HttpServer.ListenAsync(
                Convert.ToInt32(Config.AppSettings.Settings["port"].Value),
                System.Threading.CancellationToken.None,
                Route.OnHttpRequestAsync
            );
        }

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
            updateAppConfig();
        }

        private void toolStripMenuItem1_CheckedChanged_1(object sender, EventArgs e)
        {
            Config.AppSettings.Settings["passwordEnabled"].Value = Convert.ToString(contextUpdateCheck.Checked);
            updateAppConfig();
        }
    }
}
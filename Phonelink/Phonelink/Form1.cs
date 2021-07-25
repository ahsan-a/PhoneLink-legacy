using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using SimpleHttp;

namespace Phonelink {

	public partial class Form1 : Form {
		private static readonly string AppVersion = "1.4.1";

		private static Configuration Config;
		public KeyValueConfigurationCollection settings;

		private Dictionary<string, string> settingsItems = new Dictionary<string, string>()
			{
				{"port", "1234" },
				{"password", "1234" },
				{"checkNewRelease", "true" },
				{"passwordEnabled", "true" },
				{"currentSavePath", "savedFiles" }
			};

		public System.Threading.Tasks.Task httpListener;
		private bool httpServerUp = false;
		private CancellationTokenSource cancelToken = new CancellationTokenSource();

		public Form1() => InitializeComponent();

		private void SetConfiguration() {
			Configuration roaming = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

			ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap
			{
				ExeConfigFilename = roaming.FilePath
			};

			Config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
			settings = Config.AppSettings.Settings;

			if (!settings.AllKeys.OrderBy(x => x).SequenceEqual(settingsItems.Keys.OrderBy(x => x))) {
				foreach (KeyValuePair<string, string> x in settingsItems) if (!settings.AllKeys.Contains(x.Key)) settings.Add(x.Key, x.Value);
				foreach (string x in settings.AllKeys) if (!settingsItems.ContainsKey(x)) settings.Remove(x);
			}

			UpdateConfigFile();
		}

		public System.Threading.Tasks.Task createRoutes() {
			//if (httpServerUp) {
			//	cancelToken.Cancel();
			//	try {
			//		cancelToken.Token.ThrowIfCancellationRequested();
			//	}
			//	catch { }
			//	cancelToken = new CancellationTokenSource();
			//}
			Route.Add("/", (req, res, args) => res.AsText("Phonelink is running on this computer."));

			var baseUrl = Convert.ToBoolean(Config.AppSettings.Settings["passwordEnabled"].Value)
				? "/" + Config.AppSettings.Settings["password"].Value + "/"
				: "/";
			

			// Sends URL
			Route.Add($"{baseUrl}url/{{url}}", (req, res, args) =>
			{
				var url = args["url"];
				if (!url.StartsWith("http")) url = $"http://{url}";
				Process.Start($"{url}");
				res.AsText($"opened {url} on your computer.");
			});

			// Sends File
			Route.Add($"{baseUrl}file", (req, res, args) => SaveFile(req, res, args), "POST");

			// Sends Notification
			Route.Add($"{baseUrl}notification", (req, res, args) =>
			{
				SendNotif(req.Headers["title"], req.Headers["body"]);
				res.AsText(
					$"sent a notification with the title as \"{req.Headers["title"]}\" and the content body as \"{req.Headers["body"]}\"");
			});

			// Sends Power State
			Route.Add($"{baseUrl}power/{{state}}", (req, res, args) => res.AsText(HandlePower(args["state"])));

			httpServerUp = true;

			return HttpServer.ListenAsync(
				Convert.ToInt32(Config.AppSettings.Settings["port"].Value),
				cancelToken.Token,
				Route.OnHttpRequestAsync
			);
		}

		private void Form1_Load(object sender, EventArgs e) {
			SetConfiguration();

			MaximizeBox = false;

			SendUpdateNotif(AppVersion);
			httpListener = createRoutes();
		}

		private void PortKeypress(object sender, KeyPressEventArgs e) {
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
				e.Handled = true;
		}

		// change save file location button
		private void ChangeSaveLocation_Click(object sender, EventArgs e) {
			using (var fbd = new FolderBrowserDialog()) {
				DialogResult result = fbd.ShowDialog();
				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath)) SaveLocationLabel.Text = fbd.SelectedPath;
			}
		}

		private void Form1_Resize(object sender, EventArgs e) {
			if (WindowState == FormWindowState.Minimized) Hide();
		}

		private void trayIcon_MouseClick(object sender, MouseEventArgs e) {
			if (e.Button != MouseButtons.Left) return;

			if (WindowState != FormWindowState.Normal) {
				Show();
				UpdateMenus();
				WindowState = FormWindowState.Normal;
			} else {
				Hide();
				WindowState = FormWindowState.Minimized;
			}
		}

		private void SaveSettingsButton_Click(object sender, EventArgs e) => SaveSettings();

		// hide form on load
		private void Form1_Shown(object sender, EventArgs e) => Hide();

		// open settings when context menu item clicked
		private void OpenSettings_Click(object sender, EventArgs e) => Show();

		// right click context menu manual update check
		private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e) => SendUpdateNotif(AppVersion, true);

		// exit app when context menu item clicked
		private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();
	}
}
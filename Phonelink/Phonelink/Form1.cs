using SimpleHttp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Phonelink {

	public partial class Form1 : Form {
		private static readonly string AppVersion = "2.0.0";

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
		private CancellationTokenSource cancelToken = new CancellationTokenSource();
		private System.Threading.Tasks.Task httpListener;

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

		private bool checkPassword(System.Net.HttpListenerRequest req) {
			Console.WriteLine($"header: {req.Headers["password"]}, password: {settings["password"].Value}");
			if (Convert.ToBoolean(settings["passwordEnabled"].Value)
				&& req.Headers["password"] != settings["password"].Value)
				return false;

			return true;
		}

		private void createRoutes() {
			cancelToken.Cancel();
			try {
				cancelToken.Token.ThrowIfCancellationRequested();
			}
			catch { }
			try {
				httpListener?.Dispose();
			}
			catch { }

			Route.Add("/", (req, res, args) => res.AsText("Phonelink is running on this computer."));

			// Sends URL
			Route.Add("/url/{url}", (req, res, args) =>
			{
				if (!checkPassword(req)) res.AsText("Your password is incorrect.");
				else {
					var url = args["url"];
					if (!url.StartsWith("http")) url = $"http://{url}";
					Process.Start($"{url}");
					res.AsText($"opened {url} on your computer.");
				}
			});

			// Sends File
			Route.Add("/file", (req, res, args) =>
			{
				if (!checkPassword(req)) res.AsText("Your password is incorrect.");
				else SaveFile(req, res, args);
			}, "POST");

			// Sends Notification
			Route.Add("/notification", (req, res, args) =>
			{
				if (!checkPassword(req)) res.AsText("Your password is incorrect.");
				else {
					SendNotif(req.Headers["title"], req.Headers["body"]);
					res.AsText(
						$"sent a notification with the title as \"{req.Headers["title"]}\" and the content body as \"{req.Headers["body"]}\"");
				}
			});

			// Sends Power State
			Route.Add("/power/{state}", (req, res, args) =>
			{
				if (!checkPassword(req)) res.AsText("Your password is incorrect.");
				else res.AsText(HandlePower(args["state"]));
			});

			cancelToken = new CancellationTokenSource();

			httpListener = HttpServer.ListenAsync(
				Convert.ToInt32(Config.AppSettings.Settings["port"].Value),
				cancelToken.Token,
				Route.OnHttpRequestAsync
			);
		}

		private void Form1_Load(object sender, EventArgs e) {
			SetConfiguration();
			MaximizeBox = false;
			SendUpdateNotif(AppVersion);
			createRoutes();
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
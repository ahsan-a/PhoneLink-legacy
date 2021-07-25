using System;
using System.Configuration;
using System.Windows.Forms;

namespace Phonelink {

	public partial class Form1 {

		public void UpdateMenus() {
			ContextMenuAppname.Text = $"Phonelink v{AppVersion}";
			FormTitle.Text = $"Phonelink v{AppVersion}";

			EnablePassword.Checked = Convert.ToBoolean(settings["passwordEnabled"].Value);
			AutoUpdateCheck.Checked = Convert.ToBoolean(settings["checkNewRelease"].Value);
			Port.Text = settings["port"].Value;
			PasswordInput.Text = settings["password"].Value;
			SaveLocationLabel.Text = System.IO.Path.GetFullPath(settings["currentSavePath"].Value);
		}

		public void UpdateConfigFile() {
			Config.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection("appSettings");
			UpdateMenus();
		}

		public void SaveSettings() {
			settings["checkNewRelease"].Value = Convert.ToString(AutoUpdateCheck.Checked);
			settings["passwordEnabled"].Value = Convert.ToString(EnablePassword.Checked);

			settings["port"].Value = Port.Text;
			settings["password"].Value = PasswordInput.Text;

			settings["currentSavePath"].Value = SaveLocationLabel.Text;

			UpdateConfigFile();
			MessageBox.Show("Your settings have been applied. If you have changed your port, remember to run the powershell script.",
				"Settings Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
			Hide();
			createRoutes();
		}
	}
}
using Mayerch1.GithubUpdateCheck;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Configuration;

namespace Phonelink {

	public partial class Form1 {

		public void SendNotif(string title, string body = "") {
			new ToastContentBuilder()
				.AddText(title)
				.AddText(body)
				.Show();
		}

		public void SendUpdateNotif(string Version, bool latestAlert = false) {
			if (!Convert.ToBoolean(Config.AppSettings.Settings["passwordEnabled"].Value)) return;

			var update = new GithubUpdateCheck("ahsan-a", "PhoneLink");
			var isUpdate = update.IsUpdateAvailable(Version, VersionChange.Revision);
			if (isUpdate)
				SendNotif("PhoneLink Update Available",
					"Update to get the latest features. A new release is available on the Github repository. You can disable checking for releases in settings.");

			if (latestAlert) SendNotif("Running Latest Phonelink Version", $"You are running the latest version of Phonelink. (v{Version})");
		}
	}
}
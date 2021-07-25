using System.Diagnostics;

namespace Phonelink {
	public partial class Form1 {

		[System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
		private static extern int ExitWindowsEx(uint uFlags, uint dwReason);

		//needed to lock PC
		[System.Runtime.InteropServices.DllImport("user32")]
		private static extern void LockWorkStation();

		public string HandlePower(string state) {
			string message;
			switch (state) {
				case "shutdown":
					Process.Start("shutdown", "/s /t 0");
					message = "Shut down";
					break;

				case "restart":
					Process.Start("shutdown", "/r /t 0");
					message = "Restarted";
					break;

				case "logout":
					ExitWindowsEx(0, 0);
					message = "Logged off";
					break;

				case "lock":
					LockWorkStation();
					message = "Locked";
					break;

				default: return "Invalid argument.";
			}

			return $"{message} successfully.";
		}
	}
}
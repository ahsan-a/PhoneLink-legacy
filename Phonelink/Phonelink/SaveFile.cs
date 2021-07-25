using SimpleHttp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Phonelink {

	public partial class Form1 {
		private string getFileName(string fileName, string path, int i) {
			while (File.Exists(
				$"{path}/{Path.GetFileNameWithoutExtension(fileName)} ({i}){Path.GetExtension(fileName)}")) i++;
			return $"{path}/{Path.GetFileNameWithoutExtension(fileName)} ({i}){Path.GetExtension(fileName)}";
		}

		private void SaveToDisk(HttpFile file, FileStream fs, HttpListenerResponse res) {
			file.Value.CopyTo(fs);
			res.AsText(
				$"Copied {Convert.ToString(file.FileName)} to the {Config.AppSettings.Settings["currentSavePath"].Value} folder.");
			fs.Dispose();
			fs.Close();
		}

		public void SaveFile(HttpListenerRequest req, HttpListenerResponse res, Dictionary<string, string> args) {
			var files = req.ParseBody(args);
			foreach (var file in files.Values) {
				try {
					using (var fs = new FileStream(
						$"{Config.AppSettings.Settings["currentSavePath"].Value}/{file.FileName}", FileMode.CreateNew,
						FileAccess.Write)) {
						SaveToDisk(file, fs, res);
					}
				}
				catch (Exception ex) {
					if (ex.HResult == -2147024816) {
						var path = getFileName(file.FileName, Config.AppSettings.Settings["currentSavePath"].Value, 1);
						using (var fs = new FileStream(path, FileMode.CreateNew, FileAccess.Write)) {
							SaveToDisk(file, fs, res);
						}
					} else if (ex.HResult == -2147024893) {
						Directory.CreateDirectory(Config.AppSettings.Settings["currentSavePath"].Value);
						string path = getFileName(file.FileName, Config.AppSettings.Settings["currentSavePath"].Value, 1);
						using (var fs = new FileStream(path, FileMode.CreateNew, FileAccess.Write)) {
							SaveToDisk(file, fs, res);
						}
					}
				}
			}
		}
	}
}
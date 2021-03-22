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

        private void Form1_Load(object sender, EventArgs e)
        {
            var port = Convert.ToInt32(ConfigurationManager.AppSettings.Get("port"));
            var password = ConfigurationManager.AppSettings.Get("password");
            var passwordEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("passwordEnabled"));

            Route.Add("/", (req, res, props) =>
            {
                res.AsText("server is up, send a link!");
            });

            var requestUrl = passwordEnabled ? "/" + password + "/{type}/{data}" : "/{type}/{data}";
            Console.WriteLine(requestUrl);
            Route.Add(requestUrl, (req, res, props) =>
            {
                var data = props["data"];
                var type = props["type"];
                Console.WriteLine(data, type);

                switch (type)
                {
                    case "url":
                        System.Diagnostics.Process.Start($"{data}");
                        res.AsText($"opened {data} on your computer.");
                        break;
                }
            });

            HttpServer.ListenAsync(
                port,
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
    }
}
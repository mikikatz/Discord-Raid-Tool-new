using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QvoidDiscord.Discord;

namespace Discord_Raid_Tool_Final
{
    internal static class Program
    {
        public static Thread thread = new Thread(() => { });

        [STAThread]
        private static void Main()
        {
            if (!File.Exists("chromedriver.exe"))
            {
                thread = new Thread(() =>
                {
                    new WebClient().DownloadFile("https://chromedriver.storage.googleapis.com/90.0.4430.24/chromedriver_win32.zip", "chromedriver.zip");
                    ZipFile.ExtractToDirectory("chromedriver.zip", $"{Application.StartupPath}\\");
                });
                thread.Start();
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
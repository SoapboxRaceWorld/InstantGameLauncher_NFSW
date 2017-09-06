using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace InstantGameLauncher {
    public partial class Settings : Form {
        IniFile Config = new IniFile(AppDomain.CurrentDomain.FriendlyName.Replace(".exe", "") + ".ini");

        public Settings() {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e) {

            //Serverlist
            var response = "";
            try {
                WebClient wc = new WebClientWithTimeout();
                wc.Headers.Add("user-agent", "GameLauncher (+https://github.com/metonator/GameLauncher_NFSW)");

                string serverurl = "http://nfsw.metonator.ct8.pl/serverlist.txt";
                response = wc.DownloadString(serverurl);
            } catch (Exception) { }

            serverText.DisplayMember = "Text";
            serverText.ValueMember = "Value";

            List<Object> items = new List<Object>();

            String[] substrings = response.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            foreach (var substring in substrings) {
                if (!String.IsNullOrEmpty(substring)) {
                    String[] substrings22 = substring.Split(new string[] { ";" }, StringSplitOptions.None);
                    items.Add(new { Text = substrings22[0], Value = substrings22[1] });
                }
            }

            serverText.DataSource = items;
            serverText.SelectedIndex = 0;

            //Executable
            var executables = Directory.GetFiles(".", "*.exe");
            executableText.DisplayMember = "Text";
            executableText.ValueMember = "Value";

            List<Object> items2 = new List<Object>();

            foreach (var substring2 in executables) {
                var dummy = substring2.Replace(".\\", "");
                if (dummy != AppDomain.CurrentDomain.FriendlyName) { 
                    items2.Add(dummy);
                }
            }

            executableText.DataSource = items2;
        }

        private void saveButton_Click(object sender, EventArgs e) {
            Config.Write("ServerAddress", serverText.SelectedValue.ToString(), "Configuration");
            Config.Write("Username", usernameText.Text, "Configuration");
            Config.Write("Password", passwordText.Text, "Configuration");
            Config.Write("UseExecutable", executableText.SelectedValue.ToString(), "Configuration");

            Process.Start(AppDomain.CurrentDomain.FriendlyName);
            Application.Exit();
        }
    }
}

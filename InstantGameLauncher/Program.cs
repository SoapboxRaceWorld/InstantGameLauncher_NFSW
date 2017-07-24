using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace InstantGameLauncher {
    static class Program {
        [STAThread]
        static void Main() {
            String Username, Password, ServerAddress, serverLoginResponse, encryptedPassword, LoginToken, UserId, Executable;
            String ConfigFile = Assembly.GetExecutingAssembly().GetName().Name + ".ini";
            IniFile Config = new IniFile(ConfigFile);

            if (!File.Exists(Directory.GetCurrentDirectory() + "/lightfx.dll")) {
                File.WriteAllBytes(Directory.GetCurrentDirectory() + "/lightfx.dll", ExtractResource.AsByte("InstantGameLauncher.SoapBoxModules.lightfx.dll"));
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/modules");
                File.WriteAllText(Directory.GetCurrentDirectory() + "/modules/udpcrc.soapbox.module", ExtractResource.AsString("InstantGameLauncher.SoapBoxModules.udpcrc.soapbox.module"));
                File.WriteAllText(Directory.GetCurrentDirectory() + "/modules/udpcrypt1.soapbox.module", ExtractResource.AsString("InstantGameLauncher.SoapBoxModules.udpcrypt1.soapbox.module"));
                File.WriteAllText(Directory.GetCurrentDirectory() + "/modules/udpcrypt2.soapbox.module", ExtractResource.AsString("InstantGameLauncher.SoapBoxModules.udpcrypt2.soapbox.module"));
                File.WriteAllText(Directory.GetCurrentDirectory() + "/modules/xmppsubject.soapbox.module", ExtractResource.AsString("InstantGameLauncher.SoapBoxModules.xmppsubject.soapbox.module"));
            }

            if (!File.Exists(ConfigFile)) {
                DialogResult InstallerAsk = MessageBox.Show(null, "There's no " + ConfigFile + " file. Do you wanna create and edit it?", "InstantGameLauncher", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (InstallerAsk == DialogResult.Yes) {
                    Config.Write("ServerAddress", "", "Configuration");
                    Config.Write("Username", "", "Configuration");
                    Config.Write("Password", "", "Configuration");
                    Process.Start(ConfigFile);
                }

                Environment.Exit(Environment.ExitCode);
            }

            Uri Server_Address = new Uri(Config.Read("ServerAddress", "Configuration"));

            if(Server_Address.Port == 80) {
                ServerAddress = Server_Address.Scheme + "://" + Server_Address.Host + "/soapbox-race-core/Engine.svc";
            } else {
                ServerAddress = Server_Address.Scheme + "://" + Server_Address.Host + ":" + Server_Address.Port + "/soapbox-race-core/Engine.svc";
            }

            Username = Config.Read("Username", "Configuration");
            Password = Config.Read("Password", "Configuration");

            HashAlgorithm algorithm = SHA1.Create();
            StringBuilder sb = new StringBuilder();
            foreach (byte b in algorithm.ComputeHash(Encoding.UTF8.GetBytes(Password))) {
                sb.Append(b.ToString("X2"));
            }

            encryptedPassword = sb.ToString();
            serverLoginResponse = "";

            try
            {
                WebClient wc = new WebClientWithTimeout();
                wc.Headers.Add("user-agent", "InstantGameLauncher (+https://github.com/metonator/InstantGameLauncher_NFSW)");
                Server_Address = new Uri(ServerAddress);
                string BuildURL = ServerAddress + "/User/authenticateUser?email=" + Username + "&password=" + encryptedPassword.ToLower();
                serverLoginResponse = wc.DownloadString(BuildURL);
            } catch (WebException ex) {
                if (ex.Status == WebExceptionStatus.ProtocolError) {
                    HttpWebResponse serverReply = (HttpWebResponse)ex.Response;
                    if ((int)serverReply.StatusCode == 500) {
                        using (StreamReader sr = new StreamReader(serverReply.GetResponseStream())) {
                            serverLoginResponse = sr.ReadToEnd();
                        }
                    } else {
                        MessageBox.Show(null, "Failed to connect to the server. " + ex.Message, "InstantGameLauncher", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(Environment.ExitCode);
                    }
                } else {
                    MessageBox.Show(null, "Failed to connect to the server. " + ex.Message, "InstantGameLauncher", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(Environment.ExitCode);
                }
            }

            XmlDocument SBRW_XML = new XmlDocument();
            SBRW_XML.LoadXml(serverLoginResponse);

            XmlNode DescriptionNode, LoginTokenNode, UserIdNode;

            DescriptionNode = SBRW_XML.SelectSingleNode("LoginStatusVO/Description");
            LoginTokenNode = SBRW_XML.SelectSingleNode("LoginStatusVO/LoginToken");
            UserIdNode = SBRW_XML.SelectSingleNode("LoginStatusVO/UserId");

            if (String.IsNullOrEmpty(DescriptionNode.InnerText)) {
                UserId = UserIdNode.InnerText;
                LoginToken = LoginTokenNode.InnerText;

                if(Config.KeyExists("UseExecutable", "Configuration")) {
                    Executable = Config.Read("UseExecutable", "Configuration");
                } else {
                    Executable = "nfsw.exe";
                }

                if(!File.Exists(Executable)) {
                    MessageBox.Show(null, "Failed to launch " + Executable + ". File not found.", "InstantGameLauncher", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(Environment.ExitCode);
                }

                string filename = Directory.GetCurrentDirectory() + "\\" + Executable;
                String cParams = "US " + ServerAddress + " " + LoginToken + " " + UserId;
                Process.Start(filename, cParams);
            } else {
                MessageBox.Show(null, "Invalid username or password.", "InstantGameLauncher", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

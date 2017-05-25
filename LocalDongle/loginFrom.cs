using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using LocalDongle.DongleServer;
using System.ServiceModel;
using DongleService;
using GsmComm.GsmCommunication;

namespace LocalDongle
{
    public partial class loginFrom : Form
    {
        public loginFrom()
        {
            InitializeComponent();
            checkForActions();
        }

        private void checkForActions()
        {
            string[] args = Environment.GetCommandLineArgs().Select(p => p.ToLower()).Distinct().ToArray();
            
            if (args.Contains("startserver"))
            {
                gotoServerForm();
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (serverpathTextbox.Text.Length == 0) MessageBox.Show("Server url is compulsory!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (usernameTextbox.Text.Length == 0) MessageBox.Show("Username is compulsory!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (passwordTextbox.Text.Length == 0) MessageBox.Show("Password is compulsory!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                string url = string.Format("net.tcp://{0}:9090/DongleService", serverpathTextbox.Text);
                try
                {
                    using (DongleServiceContractClient client = new DongleServiceContractClient(new NetTcpBinding(), new EndpointAddress(url)))
                    {
                        var response = client.login(usernameTextbox.Text, passwordTextbox.Text);
                        if (response.IsSuccess) gotoClientForm(response.UID);
                        else MessageBox.Show("Invalid username or password!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch { MessageBox.Show("No server found at this location", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void startServerButton_Click(object sender, EventArgs e)
        {
            gotoServerForm();
        }

        private void usernameTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) loginButton.PerformClick();
        }

        private void passwordTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) loginButton.PerformClick();
        }

        private void gotoServerForm()
        {
            if (Util.IsElevated())
            {
                ushort comId;

                if (ushort.TryParse(portInputTextbox.Text, out comId))
                {
                    if ((new verifyServerCred()).ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                    {
                        var form = serverForm.getInstance(comId);

                        if (form != null)
                        {
                            form.Shown += (s, args) => this.Hide();
                            form.Closed += (s, args) => this.Close();
                            form.Show();
                        }
                        else MessageBox.Show(string.Format("Could not connect to dongle at COM{0}", comId), "Dongle Connect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else MessageBox.Show("COM ID Entered does not look valid", "Dongle Connect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    var info = new ProcessStartInfo(Assembly.GetEntryAssembly().Location, "startServer")
                    {
                        Verb = "runas", // indicates to elevate privileges
                    };

                    var process = new Process
                    {
                        StartInfo = info
                    };

                    process.Start();
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("You need to have admininstrator access on this machine to start the server", "Could not start server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void gotoClientForm(long uid)
        {
            this.Hide();
            var form = clientForm.getInstance(uid, string.Format("net.tcp://{0}:9090/DongleService", serverpathTextbox.Text));

            if (form != null)
            {
                form.Closed += (s, args) => this.Close();
                form.Show();
            }
            else MessageBox.Show("Trouble connecting to the server. Please try again.", "Dongle Connect", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void registerButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string url = string.Format("net.tcp://{0}:9090/DongleService", serverpathTextbox.Text);
                using (DongleServiceContractClient client = new DongleServiceContractClient(new NetTcpBinding(), new EndpointAddress(url)))
                {
                    var result = (new registerForm(client)).ShowDialog();
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        MessageBox.Show("User login requested. Pending approval.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch { MessageBox.Show("No server found at this location", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void testPortButton_Click(object sender, EventArgs e)
        {
            ushort comId;

            if (ushort.TryParse(portInputTextbox.Text, out comId))
            {
                GsmCommMain comm = new GsmCommMain(ushort.Parse(portInputTextbox.Text), 460800, 1000);

                try
                {
                    comm.Open(); comm.Close();
                    MessageBox.Show("Port found running device", "Test", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch { if (comm.IsOpen()) comm.Close(); MessageBox.Show("Port not active. Try again.", "Test", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            else MessageBox.Show("COM ID Entered does not look valid", "Dongle Connect", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void portInputTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                startServerButton.PerformClick();
            }
        }
    }
}

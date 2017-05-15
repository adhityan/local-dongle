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
                if ((new verifyServerCred()).ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                {
                    var form = new serverForm();
                    form.Shown += (s, args) => this.Hide();
                    form.Closed += (s, args) => this.Close();
                    form.Show();
                }
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
            var form = new clientForm(uid, string.Format("net.tcp://{0}:9090/DongleService", serverpathTextbox.Text));
            form.Closed += (s, args) => this.Close();
            form.Show();
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
                        MessageBox.Show("User login requested. Pending approval", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch { MessageBox.Show("No server found at this location", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}

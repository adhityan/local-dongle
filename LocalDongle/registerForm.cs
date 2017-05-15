using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using DongleService;
using LocalDongle.DongleServer;
using System.ServiceModel;

namespace LocalDongle
{
    public partial class registerForm : Form
    {
        private bool isServer;
        private DongleServiceContractClient client;

        public registerForm(DongleServiceContractClient client = null)
        {
            InitializeComponent();
            if (client == null) this.isServer = true;
            else
            {
                this.client = client;
                this.isServer = false;
            }
            init();
        }

        private void init()
        {
            if (isServer)
            {
                requestButton.Text = "Register";
            }
        }

        private void requestButton_Click(object sender, EventArgs e)
        {
            if (usernameTextbox.Text.Length == 0)
            {
                MessageBox.Show("Username cannot be empty", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else if (usernameTextbox.Text.Contains(' '))
            {
                MessageBox.Show("Username cannot have a space", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else if (passwordTextbox.Text.Length == 0)
            {
                MessageBox.Show("Password cannot be empty", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else if (passwordTextbox.Text.Length < 5)
            {
                MessageBox.Show("Password must be atleast 5 characters", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else if (emailTextbox.Text.Length > 0 && (!emailTextbox.Text.Contains('@') || !emailTextbox.Text.Contains('.') || emailTextbox.Text.Length < 5))
            {
                MessageBox.Show("Email appears to be invalid", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else if (usernameTextbox.Text.Any(c => char.IsUpper(c)))
            {
                MessageBox.Show("Username cannot have upper case characters", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            bool result = false;
            if (isServer) result = handleRegisterOnServer();
            else result = handleRegisterOnClient();

            if (result) this.DialogResult = System.Windows.Forms.DialogResult.OK;
            else this.DialogResult = System.Windows.Forms.DialogResult.No;
            this.Close();
        }

        private bool handleRegisterOnClient()
        {
            try
            {
                var response = client.addNewUser(usernameTextbox.Text, passwordTextbox.Text, nameTextbox.Text, emailTextbox.Text);
                if (!response.status) MessageBox.Show(response.errorMessage, "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return response.status;
            }
            catch
            {
                MessageBox.Show("Server is offline", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool handleRegisterOnServer()
        {
            try
            {
                SqlCeCommand command = new SqlCeCommand("insert into users(username, password, name, email) values(@username, @password, @name, @email)");
                command.Parameters.AddWithValue("@username", usernameTextbox.Text);
                command.Parameters.AddWithValue("@password", passwordTextbox.Text);
                command.Parameters.AddWithValue("@email", emailTextbox.Text);
                command.Parameters.AddWithValue("@name", nameTextbox.Text);

                var result = DongleData.Instance.runExecQuery(command);
                if (result != 0) return true;
                else MessageBox.Show("Adding new user failed", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch { MessageBox.Show("That user name is already taken", "Try again!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
            return false;
        }

        private void passwordTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                requestButton.PerformClick();
            }
        }

        private void nameTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                requestButton.PerformClick();
            }
        }

        private void emailTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                requestButton.PerformClick();
            }
        }
    }
}

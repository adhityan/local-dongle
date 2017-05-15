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

namespace LocalDongle
{
    public partial class passwordResetForm : Form
    {
        private long uid;
        private bool isServer;
        private DongleServiceContractClient client;

        public passwordResetForm(long uid, DongleServiceContractClient client = null)
        {
            InitializeComponent();

            this.uid = uid;
            if (client == null) this.isServer = true;
            else
            {
                this.client = client;
                this.isServer = false;
            }
        }

        private void resetPasswordButton_Click(object sender, EventArgs e)
        {
            if (passwordTextbox.Text.Length < 5) MessageBox.Show("Password must be atleast 5 characters", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            else if (confirmPasswordTextbox.Text != passwordTextbox.Text) MessageBox.Show("Password and confirm password do not match", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            else
            {
                if (isServer) handlePasswordChangeOnServer();
                else handlePasswordChangeOnClient();

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private bool handlePasswordChangeOnClient()
        {
            try
            {
                var response = client.updatePassword(this.uid, passwordTextbox.Text);
                if (!response.status) MessageBox.Show(response.errorMessage, "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return response.status;
            }
            catch
            {
                MessageBox.Show("Server is offline", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool handlePasswordChangeOnServer()
        {
            try
            {
                SqlCeCommand command = new SqlCeCommand("update users set password = @password where id = @uid");
                command.Parameters.AddWithValue("@password", passwordTextbox.Text);
                command.Parameters.AddWithValue("@uid", this.uid);

                var result = DongleData.Instance.runExecQuery(command);
                if (result != 0) return true;
                else MessageBox.Show("Password update failed", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch { MessageBox.Show("Password update failed", "Try again!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
            return false;
        }

        private void confirmPasswordTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                resetPasswordButton.PerformClick();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LocalDongle
{
    public partial class verifyServerCred : Form
    {
        private string username;
        private string password;

        public verifyServerCred()
        {
            InitializeComponent();

            username = "";
            password = "";
        }

        private void launchButton_Click(object sender, EventArgs e)
        {
            if (usernameTextbox.Text == username && passwordTextbox.Text == password)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                this.Close();
            }
            else MessageBox.Show("Invalid username or password", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void passwordTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                launchButton.PerformClick();
            }
        }

        private void usernameTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                launchButton.PerformClick();
            }
        }
    }
}

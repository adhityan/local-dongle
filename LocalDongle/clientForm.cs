using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LocalDongle.DongleServer;
using System.ServiceModel;
using DongleService.Structs;

namespace LocalDongle
{
    public partial class clientForm : Form
    {
        private long uid;
        private List<SMSObject> sms;
        private DongleServiceContractClient client;

        public clientForm(long uid, string url)
        {
            InitializeComponent();
            this.uid = uid;

            client = new DongleServiceContractClient(new NetTcpBinding(), new EndpointAddress(url));
            init();
        }

        public void init()
        {
            client.Open();
            sms = client.getSMS(this.uid).ToList();

            if (sms.Count > 0)
            {
                smsList.DataSource = sms.Select(p => p.from).ToArray();
                smsAvailablePanel.Visible = true;
                noSmsAvailablePanel.Visible = false;
            }
            else
            {
                smsAvailablePanel.Visible = false;
                noSmsAvailablePanel.Visible = true;
            }
        }

        private void smsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SMSObject select = sms[smsList.SelectedIndex];
            smsView.Text = select.content;
        }

        private void clientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                client.Close();
            }
            catch { }
        }

        private void sendMessageButton_Click(object sender, EventArgs e)
        {
            try
            {
                var response = client.sendSMS(this.uid, phoneTextbox.Text, sendMessageTextbox.Text);
                if (!response.status) MessageBox.Show(response.errorMessage, "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("SMS sent!", "Hurray", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                phoneTextbox.Text = sendMessageTextbox.Text = "";
            }
            catch
            {
                MessageBox.Show("Server is offline", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resetPasswordButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var result = (new passwordResetForm(uid, this.client)).ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show("Password updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Server is offline", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

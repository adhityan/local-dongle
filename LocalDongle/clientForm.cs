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
using System.Diagnostics;

namespace LocalDongle
{
    public partial class clientForm : Form
    {
        private long uid;
        private UserObject user;
        private DongleServiceContractClient client;
        private List<KeyValuePair<long, string>> groups;

        public static clientForm getInstance(long uid, string url)
        {
            DongleServiceContractClient client = null;
            clientForm form = null;

            try
            {
                client = new DongleServiceContractClient(new NetTcpBinding(), new EndpointAddress(url));
                client.Open();

                form = new clientForm(uid, client);
                return form;
            }
            catch (Exception ex)
            {
                if (Debugger.IsAttached) Debugger.Break();

                try
                {
                    client.Close();
                    if (form != null) form.Close();
                }
                catch { }

                return null;
            }
        }

        private clientForm(long uid, DongleServiceContractClient client)
        {
            InitializeComponent();
            this.uid = uid;
            this.client = client;

            init();
        }

        public void init()
        {
            initUserInfo();
            initGroups();
        }

        private void initGroups()
        {
            groups = client.getAllGroups().ToList();

            groupCombobox.DisplayMember = "Value";
            groupCombobox.ValueMember = "Key";
            groupCombobox.DataSource = new BindingSource(groups, null);
        }

        private void initUserInfo()
        {
            this.user = client.getUserInfo(this.uid);
            phoneLabel.Text = this.user.username;
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
            if (sendMessageTextbox.Text.Length == 0)
            {
                MessageBox.Show("Message can not be empty", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            try
            {
                sendMessageButton.Enabled = false;

                if (toGroupRadio.Checked)
                {
                    long gid = (long)groupCombobox.SelectedValue;
                    string group = ((KeyValuePair<long, string>)groupCombobox.SelectedItem).Value;

                    var response = client.sendGroupSMS(this.uid, gid, sendMessageTextbox.Text);
                    if (!response.status) MessageBox.Show(response.errorMessage, "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        phoneTextbox.Text = sendMessageTextbox.Text = "";
                        MessageBox.Show(string.Format("All messages to {0} succesfully sent!", group), "Hurray", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (phoneTextbox.Text.Length == 0)
                    {
                        MessageBox.Show("Phone number is mandatory", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }

                    var response = client.sendSMS(this.uid, phoneTextbox.Text, sendMessageTextbox.Text);
                    if (!response.status) MessageBox.Show(response.errorMessage, "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        MessageBox.Show(string.Format("SMS sent to {0}!", phoneTextbox.Text), "Hurray", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        phoneTextbox.Text = sendMessageTextbox.Text = "";
                    }
                }
            }
            catch
            {
                MessageBox.Show("Server is offline", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sendMessageButton.Enabled = true;
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

        private void phoneTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendMessageButton.PerformClick();
            }
        }

        private void toPhoneRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (toGroupRadio.Checked) groupCombobox.Visible = true;
            else groupCombobox.Visible = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using DongleService;
using System.Data.SqlServerCe;
using System.Diagnostics;
using GsmComm.GsmCommunication;
using GsmComm.PduConverter;

namespace LocalDongle
{
    public partial class serverForm : Form
    {
        private ServiceHost host;
        private bool letClose = false;
        private DongleData database;
        private GsmCommMain comm;
        private ushort comId;

        private List<KeyValuePair<long, string>> users;
        private List<KeyValuePair<long, string>> groups;
        private List<KeyValuePair<long, string>> pending;

        private List<KeyValuePair<long, string>> mapped;
        private List<KeyValuePair<long, string>> unMapped;
        private DongleService.DongleService dongleService;

        public static serverForm getInstance(ushort comId)
        {
            try
            {
                return new serverForm(comId);
            }
            catch { return null; }
        }

        private serverForm(ushort comId)
        {
            InitializeComponent();
            database = DongleData.Instance;
            this.comId = comId;

            initCom();
            initServer();
            initGroups();
            initUsers();
            initPendingUsers();
            initMappings();
            initMessages();

            updateTimer.Enabled = true;
        }

        private void showStillRunning()
        {
            notifyIcon.ShowBalloonTip(2000, "Local Dongle", "The server is running in the background", ToolTipIcon.Info);
        }

        private void showHideMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = !this.Visible;
            if (this.Visible) showHideMenuItem.Text = "Hide";
            else showHideMenuItem.Text = "Show";
        }

        private void quitMenuItem_Click(object sender, EventArgs e)
        {
            letClose = true;
            this.Close();
        }

        private void serverForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!letClose)
            {
                this.Hide();
                e.Cancel = true;
                showStillRunning();
            }
            else
            {
                if (comm.IsOpen()) comm.Close();

                host.Close();
                notifyIcon.Visible = false;
            }
        }

        private void serverForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible) showHideMenuItem.Text = "Hide";
            else showHideMenuItem.Text = "Show";
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void initCom()
        {
            this.comm = new GsmCommMain(this.comId, 460800, 1000);
            comm.Open();

            comm.MessageReceived += new MessageReceivedEventHandler(comm_MessageReceived);
            comm.PhoneDisconnected += new EventHandler(comm_PhoneDisconnected);
            comm.PhoneConnected += new EventHandler(comm_PhoneConnected);
        }

        void comm_PhoneDisconnected(object sender, EventArgs e)
        {
            
        }

        void comm_PhoneConnected(object sender, EventArgs e)
        {
            
        }

        private void initMessages()
        {
            processAllUnreadMessages();
        }

        private void processAllUnreadMessages()
        {
            try
            {
                var sim_messages = comm.ReadMessages(PhoneMessageStatus.All, PhoneStorageType.Sim);
                var phone_messages = comm.ReadMessages(PhoneMessageStatus.All, PhoneStorageType.Phone);
                var messages = sim_messages.Union(phone_messages).ToArray();

                foreach (DecodedShortMessage message in messages)
                {
                    if (message.Data is SmsDeliverPdu)
                    {
                        SmsDeliverPdu data = (SmsDeliverPdu)message.Data;
                        var timestamp = data.SCTimestamp.ToDateTime();
                        var phoneNumber = data.OriginatingAddress;
                        var text = data.UserDataText;

                        if (phoneNumber.Contains("+91")) phoneNumber = phoneNumber.Replace("+91", "");
                        SqlCeCommand command = new SqlCeCommand("insert into sms_received(sender, message, timestamp) values(@sender, @message, @timestamp)");
                        command.Parameters.AddWithValue("@timestamp", timestamp);
                        command.Parameters.AddWithValue("@sender", phoneNumber);
                        command.Parameters.AddWithValue("@message", text);
                        DongleData.Instance.runExecQuery(command);

                        processIncomingTriggers(phoneNumber, text);
                    }
                }
            }
            catch (Exception ex) { if (Debugger.IsAttached) Debugger.Break(); }
        }

        void comm_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            try
            {
                if (e.IndicationObject is MemoryLocation)
                {
                    MemoryLocation location = (MemoryLocation)e.IndicationObject;
                    var message = comm.ReadMessage(location.Index, location.Storage);

                    if (message.Data is SmsDeliverPdu)
                    {
                        SmsDeliverPdu data = (SmsDeliverPdu)message.Data;
                        var timestamp = data.SCTimestamp.ToDateTime();
                        var phoneNumber = data.OriginatingAddress;
                        var text = data.UserDataText;

                        if (phoneNumber.Contains("+91")) phoneNumber = phoneNumber.Replace("+91", "");
                        SqlCeCommand command = new SqlCeCommand("insert into sms_received(sender, message, timestamp) values(@sender, @message, @timestamp)");
                        command.Parameters.AddWithValue("@timestamp", timestamp);
                        command.Parameters.AddWithValue("@sender", phoneNumber);
                        command.Parameters.AddWithValue("@message", text);
                        DongleData.Instance.runExecQuery(command);

                        processIncomingTriggers(phoneNumber, text);
                    }
                }
                else if (e.IndicationObject is ShortMessage)
                {
                    var message = (ShortMessage)e.IndicationObject;
                    var data = (SmsDeliverPdu)comm.DecodeReceivedMessage(message);

                    var timestamp = data.SCTimestamp.ToDateTime();
                    var phoneNumber = data.OriginatingAddress;
                    var text = data.UserDataText;

                    if (phoneNumber.Contains("+91")) phoneNumber = phoneNumber.Replace("+91", "");
                    SqlCeCommand command = new SqlCeCommand("insert into sms_received(sender, message, timestamp) values(@sender, @message, @timestamp)");
                    command.Parameters.AddWithValue("@timestamp", timestamp);
                    command.Parameters.AddWithValue("@sender", phoneNumber);
                    command.Parameters.AddWithValue("@message", text);
                    DongleData.Instance.runExecQuery(command);

                    processIncomingTriggers(phoneNumber, text);
                }
            }
            catch (Exception ex) { if (Debugger.IsAttached) Debugger.Break(); }
        }

        private void processIncomingTriggers(string sender, string message)
        {
            if (message.ToUpper().StartsWith("REG "))
            {
                var parts = message.Split(new char[] { ' ' });
                if (parts.Length < 2) return;

                string username = parts[1];
                string name = username;
                if (parts.Length > 2) name = parts[2];

                SqlCeCommand command = new SqlCeCommand("insert into users(username, password, phone, name, enabled) values(@username, @password, @phone, @name, 0)");
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", username);
                command.Parameters.AddWithValue("@name", username);
                command.Parameters.AddWithValue("@phone", sender);

                int result = 0;
                try
                {
                    result = DongleData.Instance.runExecQuery(command);
                }
                catch { }

                if (result != 0) comm.SendMessage(new SmsSubmitPdu(string.Format("Registration request accepted for {0}", username), sender));
                else comm.SendMessage(new SmsSubmitPdu(string.Format("Username: {0} or phone number: {1} is already registered", username, sender), sender));
            }
        }

        private void initServer()
        {
            dongleService = new DongleService.DongleService(this.comm);
            Uri baseAddress = new Uri("net.tcp://localhost:9090/DongleService");
            host = new ServiceHost(dongleService, baseAddress);

            host.Open();
        }

        private void initGroups()
        {
            groups = new List<KeyValuePair<long, string>>();
            var reader = database.runTableQuery("select id, name from groups where enabled = 1");
            while (reader.Read())
            {
                groups.Add(new KeyValuePair<long, string>((long)reader[0], (string)reader[1]));
            }
            reader.Close();

            groupsList.DisplayMember = "Value";
            groupsList.ValueMember = "Key";
            groupsList.DataSource = new BindingSource(groups, null);

            groupsDeleteDropdown.DisplayMember = "Value";
            groupsDeleteDropdown.ValueMember = "Key";
            groupsDeleteDropdown.DataSource = new BindingSource(groups, null);
        }

        private void initUsers()
        {
            users = new List<KeyValuePair<long, string>>();
            mapped = new List<KeyValuePair<long, string>>();
            unMapped = new List<KeyValuePair<long, string>>();

            readUsers();

            usersList.DisplayMember = "Value";
            usersList.ValueMember = "Key";
            usersList.DataSource = new BindingSource(users, null);

            usersDeleteDropdown.DisplayMember = "Value";
            usersDeleteDropdown.ValueMember = "Key";
            usersDeleteDropdown.DataSource = new BindingSource(users, null);
        }

        private void readUsers()
        {
            users.Clear();
            var reader = database.runTableQuery("select id, username from users where enabled = 1");
            while (reader.Read())
            {
                users.Add(new KeyValuePair<long, string>((long)reader[0], (string)reader[1]));
            }
            reader.Close();
        }

        private void initPendingUsers()
        {
            pending = new List<KeyValuePair<long, string>>();

            readPendingUsers();
            
            pendingDropdown.DisplayMember = "Value";
            pendingDropdown.ValueMember = "Key";
            pendingDropdown.DataSource = new BindingSource(pending, null);
        }

        private void readPendingUsers()
        {
            rejectPendingUserButton.Enabled = approvePendingUserButton.Enabled = false;
            pending.Clear();

            var reader = database.runTableQuery("select id, username from users where enabled = 0");
            while (reader.Read())
            {
                pending.Add(new KeyValuePair<long, string>((long)reader[0], (string)reader[1]));
            }
            reader.Close();

            rejectPendingUserButton.Enabled = approvePendingUserButton.Enabled = true;
        }

        private void initMappings()
        {
            mapped = new List<KeyValuePair<long, string>>();
            unMapped = new List<KeyValuePair<long, string>>();

            notMappedList.DisplayMember = "Value";
            notMappedList.ValueMember = "Key";
            notMappedList.DataSource = new BindingSource(unMapped, null);

            alreadyMappedList.DisplayMember = "Value";
            alreadyMappedList.ValueMember = "Key";
            alreadyMappedList.DataSource = new BindingSource(mapped, null);

            updateUserGroupMappings();
        }

        private void stopServerButton_Click(object sender, EventArgs e)
        {
            letClose = true;
            this.Close();
        }

        private void groupAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (groupAddTextbox.Text.Length == 0)
                {
                    MessageBox.Show("Group name cannot be empty", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                SqlCeCommand command = new SqlCeCommand("insert into groups(name) values(@name)");
                command.Parameters.AddWithValue("@name", groupAddTextbox.Text);

                var result = DongleData.Instance.runExecQuery(command);
                if (result != 0)
                {
                    groups.Add(new KeyValuePair<long, string>((long)result, groupAddTextbox.Text));
                    ((BindingSource)groupsList.DataSource).ResetBindings(false);
                    ((BindingSource)groupsDeleteDropdown.DataSource).ResetBindings(false);
                    groupAddTextbox.Text = "";
                }
                else MessageBox.Show("Adding new group failed", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch { MessageBox.Show("That group name is already taken", "Try again!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }

            updateUserGroupMappings(); 
        }

        private void groupDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = groupsDeleteDropdown.SelectedIndex;
                long id = (long)groupsDeleteDropdown.SelectedValue;

                SqlCeCommand command = new SqlCeCommand("delete from groups where id = @id");
                command.Parameters.AddWithValue("@id", id.ToString());

                var result = DongleData.Instance.runExecQuery(command);
                if (result != 0)
                {
                    command = new SqlCeCommand("delete from users_groups where group_id = @id");
                    command.Parameters.AddWithValue("@id", id.ToString());
                    DongleData.Instance.runExecQuery(command);

                    groups.RemoveAt(index);
                    ((BindingSource)groupsList.DataSource).ResetBindings(false);
                    ((BindingSource)groupsDeleteDropdown.DataSource).ResetBindings(false);
                }
                else MessageBox.Show("Deleting the group failed", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch { MessageBox.Show("Something went wrong", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }

            updateUserGroupMappings();
        }

        private void userDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = usersDeleteDropdown.SelectedIndex;
                long id = (long)usersDeleteDropdown.SelectedValue;

                SqlCeCommand command = new SqlCeCommand("delete from users where id = @id");
                command.Parameters.AddWithValue("@id", id.ToString());

                var result = DongleData.Instance.runExecQuery(command);
                if (result != 0)
                {
                    command = new SqlCeCommand("delete from users_groups where user_id = @id");
                    command.Parameters.AddWithValue("@id", id.ToString());
                    DongleData.Instance.runExecQuery(command);

                    users.RemoveAt(index);
                    ((BindingSource)usersList.DataSource).ResetBindings(false);
                    ((BindingSource)usersDeleteDropdown.DataSource).ResetBindings(false);
                }
                else MessageBox.Show("Deleting the user failed", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch { MessageBox.Show("Something went wrong", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }

            updateUserGroupMappings();
        }

        private void updateUserGroupMappings()
        {
            try
            {
                mapped.Clear();
                unMapped.Clear();

                if (users.Count == 0 || groups.Count == 0)
                {
                    ((BindingSource)notMappedList.DataSource).ResetBindings(false);
                    ((BindingSource)alreadyMappedList.DataSource).ResetBindings(false);
                    return;
                }

                long id = (long)usersList.SelectedValue;
                SqlCeCommand command = new SqlCeCommand("select group_id from users_groups where user_id = @uid");
                command.Parameters.AddWithValue("@uid", id.ToString());
                var reader = database.runTableQuery(command);

                List<long> mappedIds = new List<long>();
                while (reader.Read())
                {
                    mappedIds.Add((long)reader[0]);
                }
                reader.Close();

                foreach (var item in groups)
                {
                    var gid = item.Key;
                    if (mappedIds.Contains(gid)) mapped.Add(new KeyValuePair<long, string>(gid, item.Value));
                    else unMapped.Add(new KeyValuePair<long, string>(gid, item.Value));
                }

                ((BindingSource)notMappedList.DataSource).ResetBindings(false);
                ((BindingSource)alreadyMappedList.DataSource).ResetBindings(false);
            }
            catch { }
        }

        private void usersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateUserGroupMappings();
        }

        private void mapButton_Click(object sender, EventArgs e)
        {
            try
            {
                int gIndex = notMappedList.SelectedIndex;
                string value = ((KeyValuePair<long, string>)notMappedList.SelectedItem).Value;
                long gid = (long)notMappedList.SelectedValue;
                long uid = (long)usersList.SelectedValue;

                SqlCeCommand command = new SqlCeCommand("insert into users_groups(user_id, group_id) values(@uid, @gid)");
                command.Parameters.AddWithValue("@uid", uid.ToString());
                command.Parameters.AddWithValue("@gid", gid.ToString());

                var result = DongleData.Instance.runExecQuery(command);
                if (result != 0)
                {
                    mapped.Add(new KeyValuePair<long, string>(gid, value));
                    unMapped.RemoveAt(gIndex);

                    ((BindingSource)notMappedList.DataSource).ResetBindings(false);
                    ((BindingSource)alreadyMappedList.DataSource).ResetBindings(false);
                }
                else MessageBox.Show("Mapping user to group failed", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch { if (Debugger.IsAttached) Debugger.Break(); }
        }

        private void unMapButton_Click(object sender, EventArgs e)
        {
            try
            {
                int gIndex = alreadyMappedList.SelectedIndex;
                string value = ((KeyValuePair<long, string>)alreadyMappedList.SelectedItem).Value;
                long gid = (long)alreadyMappedList.SelectedValue;
                long uid = (long)usersList.SelectedValue;

                SqlCeCommand command = new SqlCeCommand("delete from users_groups where user_id = @uid and group_id = @gid");
                command.Parameters.AddWithValue("@uid", uid.ToString());
                command.Parameters.AddWithValue("@gid", gid.ToString());

                var result = DongleData.Instance.runExecQuery(command);
                if (result != 0)
                {
                    unMapped.Add(new KeyValuePair<long, string>(gid, value));
                    mapped.RemoveAt(gIndex);

                    ((BindingSource)notMappedList.DataSource).ResetBindings(false);
                    ((BindingSource)alreadyMappedList.DataSource).ResetBindings(false);
                }
                else MessageBox.Show("Un mapping user from group failed", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch { if (Debugger.IsAttached) Debugger.Break(); }
        }

        private void addUserButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var result = (new registerForm()).ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                MessageBox.Show("User added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                readUsers();
                ((BindingSource)usersList.DataSource).ResetBindings(false);
                ((BindingSource)usersDeleteDropdown.DataSource).ResetBindings(false);
                if (users.Count == 1) updateUserGroupMappings();
            }
        }

        private void resetPasswordButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            long uid = (long)usersList.SelectedValue;
            var result = (new passwordResetForm(uid)).ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                MessageBox.Show("Password updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void approvePendingUserButton_Click(object sender, EventArgs e)
        {
            try
            {
                long uid = (long)pendingDropdown.SelectedValue;
                string uvalue = ((KeyValuePair<long, string>)pendingDropdown.SelectedItem).Value;
                int uindex = usersList.SelectedIndex;

                SqlCeCommand command = new SqlCeCommand("update users set enabled = 1 where id = @uid");
                command.Parameters.AddWithValue("@uid", uid.ToString());

                var result = DongleData.Instance.runExecQuery(command);
                if (result != 0)
                {
                    users.Add(new KeyValuePair<long, string>(uid, uvalue));
                    pending.RemoveAt(uindex);

                    ((BindingSource)usersList.DataSource).ResetBindings(false);
                    ((BindingSource)usersDeleteDropdown.DataSource).ResetBindings(false);
                    ((BindingSource)pendingDropdown.DataSource).ResetBindings(false);
                }
                else MessageBox.Show("User could not be approved", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch { if (Debugger.IsAttached) Debugger.Break(); }
        }

        private void rejectPendingUserButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = pendingDropdown.SelectedIndex;
                long id = (long)pendingDropdown.SelectedValue;

                SqlCeCommand command = new SqlCeCommand("delete from users where id = @id");
                command.Parameters.AddWithValue("@id", id.ToString());

                var result = DongleData.Instance.runExecQuery(command);
                if (result != 0)
                {
                    pending.RemoveAt(index);
                    ((BindingSource)pendingDropdown.DataSource).ResetBindings(false);
                }
                else MessageBox.Show("Deleting pending user failed", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch { MessageBox.Show("Something went wrong", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            readPendingUsers();
            ((BindingSource)pendingDropdown.DataSource).ResetBindings(false);
        }

        private void showMailboxButton_Click(object sender, EventArgs e)
        {
            (new mailboxForm()).ShowDialog();
        }
    }
}

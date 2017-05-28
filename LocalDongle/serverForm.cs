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
using LocalDongle.Structs;
using log4net;

namespace LocalDongle
{
    public partial class serverForm : Form
    {
        private ServiceHost host;
        private bool letClose = false;
        private DongleData database;
        private GsmCommMain comm;
        private ushort comId;

        private BindingList<UserListItem> users;
        private BindingList<GroupListItem> groups;
        private BindingList<MessagesListItem> messages;
        private BindingList<ContactsListItem> contacts;

        private BindingList<NotificationLongStringKeyValuePair> pending;
        private BindingList<NotificationLongStringKeyValuePair> mapped;
        private BindingList<NotificationLongStringKeyValuePair> unMapped;

        private DongleService.DongleService dongleService;
        private static readonly ILog log = LogManager.GetLogger(typeof(serverForm));
        
        public static serverForm getInstance(ushort comId)
        {
            serverForm form = null;

            try
            {
                form = new serverForm(comId);
                return form;
            }
            catch (Exception ex)
            {
                if (Debugger.IsAttached) Debugger.Break();

                try
                {
                    form.cleanup();
                }
                catch { }

                MessageBox.Show(string.Format("Server could not be started. Exact error follows: \n\n{0}", ex.Message), "Dongle Connect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("Server could not be started", ex);
                return null;
            }
        }

        private void cleanup()
        {
            notifyIcon.Visible = false;
            host.Close();
            comm.Close();

            this.Close();
        }

        private serverForm(ushort comId)
        {
            InitializeComponent();
            log.Info("Starting server");
            database = DongleData.Instance;
            this.comId = comId;

            initCom();
            log.Info("Finished Com");

            initServer();
            log.Info("Finished Server");

            initGroups();
            log.Info("Finished Groups");

            initContacts();
            log.Info("Finished Contacts");

            initMappings();
            log.Info("Finished Mappings");

            initUsers();
            log.Info("Finished Users");

            initPendingUsers();
            log.Info("Finished PendingUsers");

            initMailbox();
            log.Info("Finished Mailbox");

            initMessages();
            log.Info("Finished Messages");

            notifyIcon.Visible = true;
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
                log.Info("Server closing");
                if (comm.IsOpen()) comm.Close();
                log.Info("COM port closed");

                host.Close();
                log.Info("WCF closed");
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

            if (!comm.IsConnected())
            {
                phoneStatusLabel.Text = "Phone disconnected";
                phoneStatusLabel.ForeColor = Color.DarkRed;
            }
        }

        void comm_PhoneDisconnected(object sender, EventArgs e)
        {
            if (comm.IsOpen())
            {
                phoneStatusLabel.Text = "Phone disconnected";
                phoneStatusLabel.ForeColor = Color.DarkRed;
            }
        }

        void comm_PhoneConnected(object sender, EventArgs e)
        {
            if (comm.IsOpen())
            {
                phoneStatusLabel.Text = "Phone connected";
                phoneStatusLabel.ForeColor = Color.Black;
            }
        }

        private void initMessages()
        {
            processAllUnreadMessages();
        }

        private void processAllUnreadMessages()
        {
            try
            {
                if(!comm.IsConnected()) return;
                cleanupAllUnreadMessages(); //JUG
                log.Info("Reading all SMS");

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
            catch (Exception ex) { log.Error("Error reading incoming SMS", ex); if (Debugger.IsAttached) Debugger.Break(); }
        }

        private void cleanupAllUnreadMessages()
        {
            log.Info("Cleaning incoming SMS local copies");
            SqlCeCommand command = new SqlCeCommand("delete from sms_received");
            DongleData.Instance.runExecQuery(command);
        }

        private void comm_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            try
            {
                log.Info("New incomming text detected. Ignored for manual refresh in this build."); //JUG
                return;

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
            groups = new BindingList<GroupListItem>();

            readGroups();

            groupsGrid.DataSource = groups;
            if (groups.Count > 0) groupsGrid.Rows[0].Selected = true;
        }

        private void readGroups()
        {
            groups.Clear();
            var reader = database.runTableQuery("select id, name from groups order by id desc");
            while (reader.Read())
            {
                groups.Add(new GroupListItem((long)reader[0], (string)reader[1]));
            }
            reader.Close();
        }

        private void initUsers()
        {
            users = new BindingList<UserListItem>();

            readUsers();

            usersGrid.DataSource = users;
            if (users.Count > 0) usersGrid.Rows[0].Selected = true;
        }

        private void readUsers()
        {
            users.Clear();
            var reader = database.runTableQuery("select id, username from users where enabled = 1 order by id desc");
            while (reader.Read())
            {
                users.Add(new UserListItem((long)reader[0], (string)reader[1]));
            }
            reader.Close();
        }

        private void initContacts()
        {
            contacts = new BindingList<ContactsListItem>();

            readContacts();

            contactsGrid.DataSource = contacts;
            if (contacts.Count > 0) contactsGrid.Rows[0].Selected = true;
        }

        private void readContacts()
        {
            contacts.Clear();
            var reader = database.runTableQuery("select id, name, phone, designation from contacts order by id desc");
            while (reader.Read())
            {
                contacts.Add(new ContactsListItem((long)reader[0], (string)reader[1], (string)reader[2], (string)reader[3]));
            }
            reader.Close();
        }

        private void initPendingUsers()
        {
            pending = new BindingList<NotificationLongStringKeyValuePair>();

            readPendingUsers();
            
            pendingList.DisplayMember = "Name";
            pendingList.ValueMember = "Key";
            pendingList.DataSource = pending;
        }

        private void readPendingUsers()
        {
            rejectPendingUserButton.Enabled = approvePendingUserButton.Enabled = false;
            pending.Clear();

            var reader = database.runTableQuery("select id, username from users where enabled = 0 order by id desc");
            while (reader.Read())
            {
                pending.Add(new NotificationLongStringKeyValuePair((long)reader[0], (string)reader[1]));
            }
            reader.Close();

            rejectPendingUserButton.Enabled = approvePendingUserButton.Enabled = true;
        }

        private void initMappings()
        {
            mapped = new BindingList<NotificationLongStringKeyValuePair>();
            unMapped = new BindingList<NotificationLongStringKeyValuePair>();

            notMappedList.DisplayMember = "Name";
            notMappedList.ValueMember = "Key";
            notMappedList.DataSource = unMapped;

            alreadyMappedList.DisplayMember = "Name";
            alreadyMappedList.ValueMember = "Key";
            alreadyMappedList.DataSource = mapped;

            updateUserGroupMappings();
        }

        private void updateUserGroupMappings()
        {
            try
            {
                if (mapped == null || unMapped == null) return;

                mapped.Clear();
                unMapped.Clear();

                if (contacts.Count == 0 || groups.Count == 0)
                {
                    ((BindingList<NotificationLongStringKeyValuePair>)notMappedList.DataSource).ResetBindings();
                    ((BindingList<NotificationLongStringKeyValuePair>)alreadyMappedList.DataSource).ResetBindings();
                    return;
                }

                var row = (ContactsListItem)contactsGrid.SelectedRows[0].DataBoundItem;
                long uid = row.ID;

                SqlCeCommand command = new SqlCeCommand("select group_id from users_groups where user_id = @uid");
                command.Parameters.AddWithValue("@uid", uid.ToString());
                var reader = database.runTableQuery(command);

                List<long> mappedIds = new List<long>();
                while (reader.Read())
                {
                    mappedIds.Add((long)reader[0]);
                }
                reader.Close();

                foreach (var item in groups)
                {
                    var gid = item.ID;
                    if (mappedIds.Contains(gid)) mapped.Add(new NotificationLongStringKeyValuePair(gid, item.Name));
                    else unMapped.Add(new NotificationLongStringKeyValuePair(gid, item.Name));
                }

                ((BindingList<NotificationLongStringKeyValuePair>)notMappedList.DataSource).ResetBindings();
                ((BindingList<NotificationLongStringKeyValuePair>)alreadyMappedList.DataSource).ResetBindings();
            }
            catch (Exception ex) { if (Debugger.IsAttached) Debugger.Break(); }
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
                    groups.Add(new GroupListItem((long)result, groupAddTextbox.Text));
                    ((BindingList<GroupListItem>)groupsGrid.DataSource).ResetBindings();
                    groupAddTextbox.Text = "";

                    if (groups.Count == 1) groupsGrid.Rows[0].Selected = true;
                    MessageBox.Show("Group created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else MessageBox.Show("Adding new group failed", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { MessageBox.Show("Something went wrong", "Try again!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }

            updateUserGroupMappings(); 
        }

        private void groupDeleteButton_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Do you want to delete the selected groups?", "Please confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewRow row in groupsGrid.SelectedRows.AsParallel())
                    {
                        var listItem = (GroupListItem)row.DataBoundItem;
                        long id = listItem.ID;
                        string name = listItem.Name;

                        SqlCeCommand command = new SqlCeCommand("delete from groups where id = @id");
                        command.Parameters.AddWithValue("@id", id.ToString());

                        var result = DongleData.Instance.runExecQuery(command);
                        if (result != 0)
                        {
                            command = new SqlCeCommand("delete from users_groups where group_id = @id");
                            command.Parameters.AddWithValue("@id", id.ToString());
                            DongleData.Instance.runExecQuery(command);
                        }
                        else MessageBox.Show(string.Format("Deleting group {0} failed", name), "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    readGroups();
                    ((BindingList<GroupListItem>)groupsGrid.DataSource).ResetBindings();

                    if (groups.Count > 0) groupsGrid.Rows[0].Selected = true;
                    else editGroupGrid.Enabled = false;
                }
                catch { MessageBox.Show("Something went wrong", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }

                updateUserGroupMappings();
            }
        }

        private void userDeleteButton_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Do you want to delete the selected user?", "Please confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewRow row in usersGrid.SelectedRows.AsParallel())
                    {
                        var listItem = (UserListItem)row.DataBoundItem;
                        long id = listItem.ID;
                        string name = listItem.Name;

                        SqlCeCommand command = new SqlCeCommand("delete from users where id = @id");
                        command.Parameters.AddWithValue("@id", id.ToString());

                        var result = DongleData.Instance.runExecQuery(command);
                        if (result != 0)
                        {
                            command = new SqlCeCommand("delete from users_groups where user_id = @id");
                            command.Parameters.AddWithValue("@id", id.ToString());
                            DongleData.Instance.runExecQuery(command);
                        }
                        else MessageBox.Show(string.Format("Deleting user {0} failed", name), "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    readUsers();
                    ((BindingList<UserListItem>)usersGrid.DataSource).ResetBindings();
                    if (users.Count == 0) editUsersGroup.Enabled = false;
                }
                catch { MessageBox.Show("Something went wrong", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

                updateUserGroupMappings();
            }
        }

        private void mapButton_Click(object sender, EventArgs e)
        {
            try
            {
                int gIndex = notMappedList.SelectedIndex;
                var selectedItem = ((NotificationLongStringKeyValuePair)notMappedList.SelectedItem);
                string value = selectedItem.Name;
                long gid = selectedItem.ID;

                var row = (ContactsListItem)contactsGrid.SelectedRows[0].DataBoundItem;
                long uid = row.ID;
                string name = row.Name;

                SqlCeCommand command = new SqlCeCommand("insert into users_groups(user_id, group_id) values(@uid, @gid)");
                command.Parameters.AddWithValue("@uid", uid.ToString());
                command.Parameters.AddWithValue("@gid", gid.ToString());

                var result = DongleData.Instance.runExecQuery(command);
                if (result != 0)
                {
                    mapped.Add(new NotificationLongStringKeyValuePair(gid, value));
                    unMapped.RemoveAt(gIndex);

                    ((BindingList<NotificationLongStringKeyValuePair>)notMappedList.DataSource).ResetBindings();
                    ((BindingList<NotificationLongStringKeyValuePair>)alreadyMappedList.DataSource).ResetBindings();
                    MessageBox.Show(string.Format("{0} added to group {1}", name, value), "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                var selectedItem = ((NotificationLongStringKeyValuePair)alreadyMappedList.SelectedItem);
                string value = selectedItem.Name;
                long gid = selectedItem.ID;

                var row = (ContactsListItem)contactsGrid.SelectedRows[0].DataBoundItem;
                long uid = row.ID;
                string name = row.Name;

                SqlCeCommand command = new SqlCeCommand("delete from users_groups where user_id = @uid and group_id = @gid");
                command.Parameters.AddWithValue("@uid", uid.ToString());
                command.Parameters.AddWithValue("@gid", gid.ToString());

                var result = DongleData.Instance.runExecQuery(command);
                if (result != 0)
                {
                    unMapped.Add(new NotificationLongStringKeyValuePair(gid, value));
                    mapped.RemoveAt(gIndex);

                    ((BindingList<NotificationLongStringKeyValuePair>)notMappedList.DataSource).ResetBindings();
                    ((BindingList<NotificationLongStringKeyValuePair>)alreadyMappedList.DataSource).ResetBindings();
                    MessageBox.Show(string.Format("{0} removed from group {1}", name, value), "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else MessageBox.Show("Un mapping user from group failed", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch { if (Debugger.IsAttached) Debugger.Break(); }
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCeCommand command = new SqlCeCommand("insert into users(username, password) values(@username, @password)");
                command.Parameters.AddWithValue("@username", usernameTextbox.Text);
                command.Parameters.AddWithValue("@password", passwordTextbox.Text);

                var result = DongleData.Instance.runExecQuery(command);
                if (result != 0)
                {
                    usernameTextbox.Text = passwordTextbox.Text = "";

                    readUsers();
                    ((BindingList<UserListItem>)usersGrid.DataSource).ResetBindings();
                    if (users.Count == 1) usersGrid.Rows[0].Selected = true;
                    MessageBox.Show("User added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Adding new user failed", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch { MessageBox.Show("The user name is already taken", "Try again!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

        private void resetPasswordButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (usersGrid.SelectedRows.Count > 1)
            {
                MessageBox.Show("Select a single user then try to reset password", "Try again!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = (UserListItem)usersGrid.SelectedRows[0].DataBoundItem;
            long uid = row.ID;
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
                var selectedItem = (NotificationLongStringKeyValuePair)pendingList.SelectedItem;
                long uid = selectedItem.ID;
                string uvalue = selectedItem.Name;
                int uindex = pendingList.SelectedIndex;

                SqlCeCommand command = new SqlCeCommand("update users set enabled = 1 where id = @uid");
                command.Parameters.AddWithValue("@uid", uid.ToString());

                var result = DongleData.Instance.runExecQuery(command);
                if (result != 0)
                {
                    pending.RemoveAt(uindex);

                    readUsers();
                    ((BindingList<NotificationLongStringKeyValuePair>)pendingList.DataSource).ResetBindings();
                    ((BindingList<UserListItem>)usersGrid.DataSource).ResetBindings();
                    if (users.Count == 1) usersGrid.Rows[0].Selected = true;
                }
                else MessageBox.Show("User could not be approved", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch { if (Debugger.IsAttached) Debugger.Break(); }
        }

        private void rejectPendingUserButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = pendingList.SelectedIndex;
                long id = ((NotificationLongStringKeyValuePair)pendingList.SelectedItem).ID;

                SqlCeCommand command = new SqlCeCommand("delete from users where id = @id");
                command.Parameters.AddWithValue("@id", id.ToString());

                var result = DongleData.Instance.runExecQuery(command);
                if (result != 0)
                {
                    pending.RemoveAt(index);
                    ((BindingList<NotificationLongStringKeyValuePair>)pendingList.DataSource).ResetBindings();
                }
                else MessageBox.Show("Deleting pending user failed", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch { MessageBox.Show("Something went wrong", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            loadCorrectData();
            readPendingUsers();
            ((BindingList<NotificationLongStringKeyValuePair>)pendingList.DataSource).ResetBindings();

            filterStartDatepicker.MaxDate = filterEndDatepicker.MaxDate = DateTime.Now;
        }

        private void showMailboxButton_Click(object sender, EventArgs e)
        {
            (new mailboxForm()).ShowDialog();
        }

        private void initMailbox()
        {
            messages = new BindingList<MessagesListItem>();
            mailGrid.DataSource = messages;
            loadCorrectData();

            slowTimer.Enabled = updateTimer.Enabled = true;
        }

        private void loadCorrectData()
        {
            if (outgoingRadio.Checked) loadSentData();
            else if (incomingRadio.Checked) loadReceivedData();
        }

        private void loadSentData()
        {
            DateTime start = new DateTime(2017, 1, 1);
            if (filterStartDatepicker.Checked) start = filterStartDatepicker.Value;

            DateTime end = DateTime.Now;
            if (filterEndDatepicker.Checked) end = filterEndDatepicker.Value;

            SqlCeCommand command = new SqlCeCommand("select id, recepiant, message, timestamp from sms_sent where timestamp > @start and timestamp < @end order by id desc");
            command.Parameters.AddWithValue("@start", start.ToString());
            command.Parameters.AddWithValue("@end", end.ToString());
            var result = DongleData.Instance.runTableQuery(command);

            messages.Clear();
            while (result.Read())
            {
                messages.Add(new MessagesListItem((long)result[0], result.GetString(1), result.GetString(2), result.GetDateTime(3)));
            }

            ((BindingList<MessagesListItem>)mailGrid.DataSource).ResetBindings();
        }

        private void loadReceivedData()
        {
            DateTime start = new DateTime(2017, 1, 1);
            if (filterStartDatepicker.Checked) start = filterStartDatepicker.Value;

            DateTime end = DateTime.Now;
            if (filterEndDatepicker.Checked) end = filterEndDatepicker.Value;

            SqlCeCommand command = new SqlCeCommand("select id, sender, message, timestamp from sms_received where timestamp > @start and timestamp < @end order by id desc");
            command.Parameters.AddWithValue("@start", start.ToString());
            command.Parameters.AddWithValue("@end", end.ToString());
            var result = DongleData.Instance.runTableQuery(command);

            messages.Clear();
            while (result.Read())
            {
                messages.Add(new MessagesListItem((long)result[0], result.GetString(1), result.GetString(2), result.GetDateTime(3)));
            }

            ((BindingList<MessagesListItem>)mailGrid.DataSource).ResetBindings();
        }

        private void inboxFilterRadio_CheckedChanged(object sender, EventArgs e)
        {
            loadCorrectData();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            loadCorrectData();
        }

        private void passwordTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addUserButton.PerformClick();
            }
        }

        private void groupAddTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                groupAddButton.PerformClick();
            }
        }

        private void groupsGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (groupsGrid.SelectedRows.Count == 0)
            {
                deleteGroupBox.Enabled = false;
            }
            else
            {
                deleteGroupBox.Enabled = true;
            }

            if (groupsGrid.SelectedRows.Count == 0) return;
            if (groupsGrid.SelectedRows.Count > 1)
            {
                editGroupGrid.Enabled = false;
                return;
            }

            editGroupGrid.Enabled = true;
            var row = (GroupListItem)groupsGrid.SelectedRows[0].DataBoundItem;
            string name = row.Name;
            groupEditTextbox.Text = name;
            updateUsersInGroup();
        }

        private void updateUsersInGroup()
        {
            var row = (GroupListItem)groupsGrid.SelectedRows[0].DataBoundItem;

            SqlCeCommand command = new SqlCeCommand("select user_id from users_groups where group_id = @gid");
            command.Parameters.AddWithValue("@gid", row.ID.ToString());

            var groups = new List<long>();
            var reader = DongleData.Instance.runTableQuery(command);
            while (reader.Read())
            {
                groups.Add((long)reader[0]);
            }
            reader.Close();

            usersInGroupListbox.Items.Clear();
            if (groups.Count > 0)
            {
                var commandSql = "select name from contacts where id in ({0}) order by id desc";
                commandSql = string.Format(commandSql, Util.implodeToString(groups.Cast<object>().ToList()));

                reader = DongleData.Instance.runTableQuery(commandSql);
                while (reader.Read())
                {
                    usersInGroupListbox.Items.Add((string)reader[0]);
                }
                reader.Close();
            }
        }

        private void usersGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (usersGrid.SelectedRows.Count == 0) return;
            else if (usersGrid.SelectedRows.Count > 1)
            {
                editUsersGroup.Enabled = false;
                return;
            }

            editUsersGroup.Enabled = true;
        }

        private void groupEditButton_Click(object sender, EventArgs e)
        {
            try
            {
                var row = (GroupListItem)groupsGrid.SelectedRows[0].DataBoundItem;
                long id = row.ID;

                SqlCeCommand command = new SqlCeCommand("update groups set name = @name where id = @id");
                command.Parameters.AddWithValue("@id", id.ToString());
                command.Parameters.AddWithValue("@name", groupEditTextbox.Text);

                var result = DongleData.Instance.runExecQuery(command);
                if (result != 0)
                {
                    readGroups();
                    ((BindingList<GroupListItem>)groupsGrid.DataSource).ResetBindings();
                    MessageBox.Show("Group name updated", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch { MessageBox.Show("Something went wrong", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

        private void contactsGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (contactsGrid.SelectedRows.Count == 0) return;
            else if (contactsGrid.SelectedRows.Count > 1)
            {
                editContactGroup.Enabled = editMappingsGroup.Enabled = false;
                return;
            }

            editContactGroup.Enabled = editMappingsGroup.Enabled = true;
            var row = (ContactsListItem)contactsGrid.SelectedRows[0].DataBoundItem;
            string name = row.Name;
            string phone = row.Phone;
            string designation = row.Designation;

            contactNameEditTextbox.Text = name;
            contactPhoneEditTextbox.Text = phone;
            contactDesignationEditTextbox.Text = designation;

            updateUserGroupMappings();
        }

        private void contactAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCeCommand command = new SqlCeCommand("insert into contacts(name, phone, designation) values(@name, @phone, @designation)");
                command.Parameters.AddWithValue("@name", contactNameAddTextbox.Text);
                command.Parameters.AddWithValue("@phone", contactPhoneAddTextbox.Text);
                command.Parameters.AddWithValue("@designation", contactDesignationAddTextbox.Text);

                var result = DongleData.Instance.runExecQuery(command);
                if (result != 0)
                {
                    contactDesignationAddTextbox.Text = contactNameAddTextbox.Text = contactPhoneAddTextbox.Text = "";

                    readContacts();
                    ((BindingList<ContactsListItem>)contactsGrid.DataSource).ResetBindings();
                    if (users.Count == 1) contactsGrid.Rows[0].Selected = true;
                    MessageBox.Show("Contact added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Adding new contact failed", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch { MessageBox.Show("The phone number is already added", "Try again!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

        private void contactEditButton_Click(object sender, EventArgs e)
        {
            try
            {
                var row = (ContactsListItem)contactsGrid.SelectedRows[0].DataBoundItem;
                long id = row.ID;

                SqlCeCommand command = new SqlCeCommand("update contacts set name = @name, designation = @designation, phone = @phone where id = @id");
                command.Parameters.AddWithValue("@id", id.ToString());
                command.Parameters.AddWithValue("@name", contactNameEditTextbox.Text);
                command.Parameters.AddWithValue("@phone", contactPhoneEditTextbox.Text);
                command.Parameters.AddWithValue("@designation", contactDesignationEditTextbox.Text);

                var result = DongleData.Instance.runExecQuery(command);
                if (result != 0)
                {
                    readContacts();
                    ((BindingList<ContactsListItem>)contactsGrid.DataSource).ResetBindings();
                    MessageBox.Show("Contact details updated", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch { MessageBox.Show("Something went wrong", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

        private void deleteContactButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Do you want to delete the selected contact?", "Please confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    var row = (ContactsListItem)contactsGrid.SelectedRows[0].DataBoundItem;
                    long id = row.ID;

                    SqlCeCommand command = new SqlCeCommand("delete from contacts where id = @id");
                    command.Parameters.AddWithValue("@id", id.ToString());

                    var result = DongleData.Instance.runExecQuery(command);
                    if (result != 0)
                    {
                        readContacts();
                        ((BindingList<ContactsListItem>)contactsGrid.DataSource).ResetBindings();

                        if (contacts.Count > 0) contactsGrid.Rows[0].Selected = true;
                        else editContactGroup.Enabled = editMappingsGroup.Enabled = false;
                        MessageBox.Show("Contact deleted", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch { MessageBox.Show("Something went wrong", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
            }
        }

        private void filterStartDatepicker_ValueChanged(object sender, EventArgs e)
        {
            loadCorrectData();
            if (filterStartDatepicker.Checked) filterEndDatepicker.MinDate = filterStartDatepicker.Value;
        }

        private void filterEndDatepicker_ValueChanged(object sender, EventArgs e)
        {
            loadCorrectData();
            if (filterEndDatepicker.Checked) filterStartDatepicker.MaxDate = filterEndDatepicker.Value;
        }

        private void slowTimer_Tick(object sender, EventArgs e)
        {
            processAllUnreadMessages(); //JUG
        }
    }
}

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

namespace LocalDongle
{
    public partial class serverForm : Form
    {
        private ServiceHost host;
        private bool letClose = false;
        private DongleData database;

        private List<KeyValuePair<long, string>> users;
        private List<KeyValuePair<long, string>> groups;

        private List<KeyValuePair<long, string>> mapped;
        private List<KeyValuePair<long, string>> unMapped;

        public serverForm()
        {
            InitializeComponent();
            database = DongleData.Instance;

            initServer();
            initGroups();
            initUsers();
            initMappings();
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

        private void initServer()
        {
            Uri baseAddress = new Uri("net.tcp://localhost:9090/DongleService");
            host = new ServiceHost(typeof(DongleService.DongleService), baseAddress);
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

            var reader = database.runTableQuery("select id, username from users where enabled = 1");
            while (reader.Read())
            {
                users.Add(new KeyValuePair<long, string>((long)reader[0], (string)reader[1]));
            }
            reader.Close();

            usersList.DisplayMember = "Value";
            usersList.ValueMember = "Key";
            usersList.DataSource = new BindingSource(users, null);

            usersDeleteDropdown.DisplayMember = "Value";
            usersDeleteDropdown.ValueMember = "Key";
            usersDeleteDropdown.DataSource = new BindingSource(users, null);
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
                }
                else MessageBox.Show("Adding new group failed", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch { MessageBox.Show("That group name is already taken", "Try again!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

        private void userAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (userAddTextbox.Text.Length == 0)
                {
                    MessageBox.Show("user name cannot be empty", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                SqlCeCommand command = new SqlCeCommand("insert into users(username, password) values(@username, @password)");
                command.Parameters.AddWithValue("@username", userAddTextbox.Text);
                command.Parameters.AddWithValue("@password", userAddTextbox.Text.ToLower());

                var result = DongleData.Instance.runExecQuery(command);
                if (result != 0)
                {
                    users.Add(new KeyValuePair<long, string>((long)result, userAddTextbox.Text));
                    ((BindingSource)usersList.DataSource).ResetBindings(false);
                    ((BindingSource)usersDeleteDropdown.DataSource).ResetBindings(false);
                }
                else MessageBox.Show("Adding new user failed", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch { MessageBox.Show("That user name is already taken", "Try again!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
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
                    groups.RemoveAt(index);
                    ((BindingSource)groupsList.DataSource).ResetBindings(false);
                    ((BindingSource)groupsDeleteDropdown.DataSource).ResetBindings(false);
                }
                else MessageBox.Show("Deleting the group failed", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch { MessageBox.Show("Something went wrong", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
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
                    users.RemoveAt(index);
                    ((BindingSource)usersList.DataSource).ResetBindings(false);
                    ((BindingSource)usersDeleteDropdown.DataSource).ResetBindings(false);
                }
                else MessageBox.Show("Deleting the user failed", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch { MessageBox.Show("Something went wrong", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

        private void updateUserGroupMappings()
        {
            try
            {
                if (users.Count == 0 || groups.Count == 0) return;
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

                mapped.Clear();
                unMapped.Clear();

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
                string value = ((KeyValuePair<long, string>)notMappedList.SelectedItem).Value;
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
    }
}

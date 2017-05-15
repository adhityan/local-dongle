namespace LocalDongle
{
    partial class serverForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(serverForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showHideMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupAddButton = new System.Windows.Forms.Button();
            this.groupAddTextbox = new System.Windows.Forms.TextBox();
            this.groupDeleteButton = new System.Windows.Forms.Button();
            this.groupsDeleteDropdown = new System.Windows.Forms.ComboBox();
            this.groupsList = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.resetPasswordButton = new System.Windows.Forms.LinkLabel();
            this.addUserButton = new System.Windows.Forms.LinkLabel();
            this.alreadyMappedList = new System.Windows.Forms.ComboBox();
            this.unMapButton = new System.Windows.Forms.Button();
            this.notMappedList = new System.Windows.Forms.ComboBox();
            this.mapButton = new System.Windows.Forms.Button();
            this.usersList = new System.Windows.Forms.ListBox();
            this.usersDeleteDropdown = new System.Windows.Forms.ComboBox();
            this.userDeleteButton = new System.Windows.Forms.Button();
            this.stopServerButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pendingDropdown = new System.Windows.Forms.ComboBox();
            this.approvePendingUserButton = new System.Windows.Forms.Button();
            this.rejectPendingUserButton = new System.Windows.Forms.Button();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.notifyMenuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.ContextMenuStrip = this.notifyMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Local Dongle Server";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // notifyMenuStrip
            // 
            this.notifyMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showHideMenuItem,
            this.quitMenuItem});
            this.notifyMenuStrip.Name = "notifyMenuStrip";
            this.notifyMenuStrip.Size = new System.Drawing.Size(96, 48);
            // 
            // showHideMenuItem
            // 
            this.showHideMenuItem.Name = "showHideMenuItem";
            this.showHideMenuItem.Size = new System.Drawing.Size(95, 22);
            this.showHideMenuItem.Text = "Hide";
            this.showHideMenuItem.Click += new System.EventHandler(this.showHideMenuItem_Click);
            // 
            // quitMenuItem
            // 
            this.quitMenuItem.Name = "quitMenuItem";
            this.quitMenuItem.Size = new System.Drawing.Size(95, 22);
            this.quitMenuItem.Text = "Quit";
            this.quitMenuItem.Click += new System.EventHandler(this.quitMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupAddButton);
            this.groupBox1.Controls.Add(this.groupAddTextbox);
            this.groupBox1.Controls.Add(this.groupDeleteButton);
            this.groupBox1.Controls.Add(this.groupsDeleteDropdown);
            this.groupBox1.Controls.Add(this.groupsList);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(847, 177);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Groups";
            // 
            // groupAddButton
            // 
            this.groupAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupAddButton.ForeColor = System.Drawing.Color.White;
            this.groupAddButton.Location = new System.Drawing.Point(762, 51);
            this.groupAddButton.Name = "groupAddButton";
            this.groupAddButton.Size = new System.Drawing.Size(75, 24);
            this.groupAddButton.TabIndex = 5;
            this.groupAddButton.Text = "Add";
            this.groupAddButton.UseVisualStyleBackColor = true;
            this.groupAddButton.Click += new System.EventHandler(this.groupAddButton_Click);
            // 
            // groupAddTextbox
            // 
            this.groupAddTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.groupAddTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupAddTextbox.Location = new System.Drawing.Point(398, 51);
            this.groupAddTextbox.Name = "groupAddTextbox";
            this.groupAddTextbox.Size = new System.Drawing.Size(358, 24);
            this.groupAddTextbox.TabIndex = 4;
            // 
            // groupDeleteButton
            // 
            this.groupDeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupDeleteButton.ForeColor = System.Drawing.Color.White;
            this.groupDeleteButton.Location = new System.Drawing.Point(762, 19);
            this.groupDeleteButton.Name = "groupDeleteButton";
            this.groupDeleteButton.Size = new System.Drawing.Size(75, 26);
            this.groupDeleteButton.TabIndex = 3;
            this.groupDeleteButton.Text = "Delete";
            this.groupDeleteButton.UseVisualStyleBackColor = true;
            this.groupDeleteButton.Click += new System.EventHandler(this.groupDeleteButton_Click);
            // 
            // groupsDeleteDropdown
            // 
            this.groupsDeleteDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.groupsDeleteDropdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupsDeleteDropdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupsDeleteDropdown.FormattingEnabled = true;
            this.groupsDeleteDropdown.Location = new System.Drawing.Point(398, 19);
            this.groupsDeleteDropdown.MaxDropDownItems = 7;
            this.groupsDeleteDropdown.Name = "groupsDeleteDropdown";
            this.groupsDeleteDropdown.Size = new System.Drawing.Size(358, 26);
            this.groupsDeleteDropdown.TabIndex = 2;
            // 
            // groupsList
            // 
            this.groupsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.groupsList.FormattingEnabled = true;
            this.groupsList.Location = new System.Drawing.Point(12, 19);
            this.groupsList.Name = "groupsList";
            this.groupsList.Size = new System.Drawing.Size(300, 143);
            this.groupsList.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.rejectPendingUserButton);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.pendingDropdown);
            this.groupBox2.Controls.Add(this.approvePendingUserButton);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.resetPasswordButton);
            this.groupBox2.Controls.Add(this.addUserButton);
            this.groupBox2.Controls.Add(this.alreadyMappedList);
            this.groupBox2.Controls.Add(this.unMapButton);
            this.groupBox2.Controls.Add(this.notMappedList);
            this.groupBox2.Controls.Add(this.mapButton);
            this.groupBox2.Controls.Add(this.usersList);
            this.groupBox2.Controls.Add(this.usersDeleteDropdown);
            this.groupBox2.Controls.Add(this.userDeleteButton);
            this.groupBox2.Location = new System.Drawing.Point(12, 195);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(847, 245);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Users";
            // 
            // resetPasswordButton
            // 
            this.resetPasswordButton.AutoSize = true;
            this.resetPasswordButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetPasswordButton.LinkColor = System.Drawing.Color.White;
            this.resetPasswordButton.Location = new System.Drawing.Point(326, 182);
            this.resetPasswordButton.Name = "resetPasswordButton";
            this.resetPasswordButton.Size = new System.Drawing.Size(97, 13);
            this.resetPasswordButton.TabIndex = 17;
            this.resetPasswordButton.TabStop = true;
            this.resetPasswordButton.Text = "Reset password";
            this.resetPasswordButton.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.resetPasswordButton_LinkClicked);
            // 
            // addUserButton
            // 
            this.addUserButton.AutoSize = true;
            this.addUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addUserButton.LinkColor = System.Drawing.Color.White;
            this.addUserButton.Location = new System.Drawing.Point(326, 159);
            this.addUserButton.Name = "addUserButton";
            this.addUserButton.Size = new System.Drawing.Size(84, 13);
            this.addUserButton.TabIndex = 16;
            this.addUserButton.TabStop = true;
            this.addUserButton.Text = "Add new user";
            this.addUserButton.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.addUserButton_LinkClicked);
            // 
            // alreadyMappedList
            // 
            this.alreadyMappedList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.alreadyMappedList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.alreadyMappedList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alreadyMappedList.FormattingEnabled = true;
            this.alreadyMappedList.Items.AddRange(new object[] {
            "Priority",
            "Standard"});
            this.alreadyMappedList.Location = new System.Drawing.Point(398, 83);
            this.alreadyMappedList.MaxDropDownItems = 7;
            this.alreadyMappedList.Name = "alreadyMappedList";
            this.alreadyMappedList.Size = new System.Drawing.Size(358, 26);
            this.alreadyMappedList.TabIndex = 11;
            // 
            // unMapButton
            // 
            this.unMapButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unMapButton.ForeColor = System.Drawing.Color.White;
            this.unMapButton.Location = new System.Drawing.Point(762, 83);
            this.unMapButton.Name = "unMapButton";
            this.unMapButton.Size = new System.Drawing.Size(75, 26);
            this.unMapButton.TabIndex = 12;
            this.unMapButton.Text = "Remove";
            this.unMapButton.UseVisualStyleBackColor = true;
            this.unMapButton.Click += new System.EventHandler(this.unMapButton_Click);
            // 
            // notMappedList
            // 
            this.notMappedList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.notMappedList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.notMappedList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notMappedList.FormattingEnabled = true;
            this.notMappedList.Items.AddRange(new object[] {
            "Admin",
            "Normal",
            "Power Users"});
            this.notMappedList.Location = new System.Drawing.Point(398, 51);
            this.notMappedList.MaxDropDownItems = 7;
            this.notMappedList.Name = "notMappedList";
            this.notMappedList.Size = new System.Drawing.Size(358, 26);
            this.notMappedList.TabIndex = 9;
            // 
            // mapButton
            // 
            this.mapButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mapButton.ForeColor = System.Drawing.Color.White;
            this.mapButton.Location = new System.Drawing.Point(762, 51);
            this.mapButton.Name = "mapButton";
            this.mapButton.Size = new System.Drawing.Size(75, 26);
            this.mapButton.TabIndex = 10;
            this.mapButton.Text = "Map";
            this.mapButton.UseVisualStyleBackColor = true;
            this.mapButton.Click += new System.EventHandler(this.mapButton_Click);
            // 
            // usersList
            // 
            this.usersList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usersList.FormattingEnabled = true;
            this.usersList.Location = new System.Drawing.Point(12, 19);
            this.usersList.Name = "usersList";
            this.usersList.Size = new System.Drawing.Size(300, 208);
            this.usersList.TabIndex = 6;
            this.usersList.SelectedIndexChanged += new System.EventHandler(this.usersList_SelectedIndexChanged);
            // 
            // usersDeleteDropdown
            // 
            this.usersDeleteDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.usersDeleteDropdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.usersDeleteDropdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usersDeleteDropdown.FormattingEnabled = true;
            this.usersDeleteDropdown.Location = new System.Drawing.Point(398, 19);
            this.usersDeleteDropdown.MaxDropDownItems = 7;
            this.usersDeleteDropdown.Name = "usersDeleteDropdown";
            this.usersDeleteDropdown.Size = new System.Drawing.Size(358, 26);
            this.usersDeleteDropdown.TabIndex = 7;
            // 
            // userDeleteButton
            // 
            this.userDeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userDeleteButton.ForeColor = System.Drawing.Color.White;
            this.userDeleteButton.Location = new System.Drawing.Point(762, 19);
            this.userDeleteButton.Name = "userDeleteButton";
            this.userDeleteButton.Size = new System.Drawing.Size(75, 26);
            this.userDeleteButton.TabIndex = 8;
            this.userDeleteButton.Text = "Delete";
            this.userDeleteButton.UseVisualStyleBackColor = true;
            this.userDeleteButton.Click += new System.EventHandler(this.userDeleteButton_Click);
            // 
            // stopServerButton
            // 
            this.stopServerButton.BackColor = System.Drawing.Color.Transparent;
            this.stopServerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopServerButton.ForeColor = System.Drawing.Color.White;
            this.stopServerButton.Location = new System.Drawing.Point(751, 449);
            this.stopServerButton.Name = "stopServerButton";
            this.stopServerButton.Size = new System.Drawing.Size(108, 41);
            this.stopServerButton.TabIndex = 18;
            this.stopServerButton.Text = "Stop server";
            this.stopServerButton.UseVisualStyleBackColor = false;
            this.stopServerButton.Click += new System.EventHandler(this.stopServerButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(326, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Delete group";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(326, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Add group";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(326, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Delete user";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(326, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Map to group";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(326, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Unmap group";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(326, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Pending";
            // 
            // pendingDropdown
            // 
            this.pendingDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pendingDropdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pendingDropdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pendingDropdown.FormattingEnabled = true;
            this.pendingDropdown.Items.AddRange(new object[] {
            "Priority",
            "Standard"});
            this.pendingDropdown.Location = new System.Drawing.Point(398, 115);
            this.pendingDropdown.MaxDropDownItems = 7;
            this.pendingDropdown.Name = "pendingDropdown";
            this.pendingDropdown.Size = new System.Drawing.Size(358, 26);
            this.pendingDropdown.TabIndex = 13;
            // 
            // approvePendingUserButton
            // 
            this.approvePendingUserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.approvePendingUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.approvePendingUserButton.ForeColor = System.Drawing.Color.White;
            this.approvePendingUserButton.Location = new System.Drawing.Point(762, 115);
            this.approvePendingUserButton.Name = "approvePendingUserButton";
            this.approvePendingUserButton.Size = new System.Drawing.Size(37, 26);
            this.approvePendingUserButton.TabIndex = 14;
            this.approvePendingUserButton.Text = "+";
            this.approvePendingUserButton.UseVisualStyleBackColor = true;
            this.approvePendingUserButton.Click += new System.EventHandler(this.approvePendingUserButton_Click);
            // 
            // rejectPendingUserButton
            // 
            this.rejectPendingUserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rejectPendingUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rejectPendingUserButton.ForeColor = System.Drawing.Color.White;
            this.rejectPendingUserButton.Location = new System.Drawing.Point(800, 115);
            this.rejectPendingUserButton.Name = "rejectPendingUserButton";
            this.rejectPendingUserButton.Size = new System.Drawing.Size(37, 26);
            this.rejectPendingUserButton.TabIndex = 15;
            this.rejectPendingUserButton.Text = "-";
            this.rejectPendingUserButton.UseVisualStyleBackColor = true;
            this.rejectPendingUserButton.Click += new System.EventHandler(this.rejectPendingUserButton_Click);
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 5000;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // serverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(871, 498);
            this.Controls.Add(this.stopServerButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "serverForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.serverForm_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.serverForm_VisibleChanged);
            this.notifyMenuStrip.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showHideMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button groupDeleteButton;
        private System.Windows.Forms.ComboBox groupsDeleteDropdown;
        private System.Windows.Forms.ListBox groupsList;
        private System.Windows.Forms.Button groupAddButton;
        private System.Windows.Forms.TextBox groupAddTextbox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox usersList;
        private System.Windows.Forms.ComboBox notMappedList;
        private System.Windows.Forms.Button mapButton;
        private System.Windows.Forms.ComboBox usersDeleteDropdown;
        private System.Windows.Forms.Button userDeleteButton;
        private System.Windows.Forms.ComboBox alreadyMappedList;
        private System.Windows.Forms.Button unMapButton;
        private System.Windows.Forms.Button stopServerButton;
        private System.Windows.Forms.LinkLabel addUserButton;
        private System.Windows.Forms.LinkLabel resetPasswordButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button rejectPendingUserButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox pendingDropdown;
        private System.Windows.Forms.Button approvePendingUserButton;
        private System.Windows.Forms.Timer updateTimer;
    }
}
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
            this.alreadyMappedList = new System.Windows.Forms.ComboBox();
            this.unMapButton = new System.Windows.Forms.Button();
            this.notMappedList = new System.Windows.Forms.ComboBox();
            this.mapButton = new System.Windows.Forms.Button();
            this.userAddButton = new System.Windows.Forms.Button();
            this.usersList = new System.Windows.Forms.ListBox();
            this.userAddTextbox = new System.Windows.Forms.TextBox();
            this.usersDeleteDropdown = new System.Windows.Forms.ComboBox();
            this.userDeleteButton = new System.Windows.Forms.Button();
            this.stopServerButton = new System.Windows.Forms.Button();
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
            this.groupBox1.Controls.Add(this.groupAddButton);
            this.groupBox1.Controls.Add(this.groupAddTextbox);
            this.groupBox1.Controls.Add(this.groupDeleteButton);
            this.groupBox1.Controls.Add(this.groupsDeleteDropdown);
            this.groupBox1.Controls.Add(this.groupsList);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(847, 177);
            this.groupBox1.TabIndex = 1;
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
            this.groupAddButton.TabIndex = 4;
            this.groupAddButton.Text = "Add";
            this.groupAddButton.UseVisualStyleBackColor = true;
            this.groupAddButton.Click += new System.EventHandler(this.groupAddButton_Click);
            // 
            // groupAddTextbox
            // 
            this.groupAddTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.groupAddTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupAddTextbox.Location = new System.Drawing.Point(329, 51);
            this.groupAddTextbox.Name = "groupAddTextbox";
            this.groupAddTextbox.Size = new System.Drawing.Size(427, 24);
            this.groupAddTextbox.TabIndex = 3;
            // 
            // groupDeleteButton
            // 
            this.groupDeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupDeleteButton.ForeColor = System.Drawing.Color.White;
            this.groupDeleteButton.Location = new System.Drawing.Point(762, 19);
            this.groupDeleteButton.Name = "groupDeleteButton";
            this.groupDeleteButton.Size = new System.Drawing.Size(75, 26);
            this.groupDeleteButton.TabIndex = 2;
            this.groupDeleteButton.Text = "Delete";
            this.groupDeleteButton.UseVisualStyleBackColor = true;
            this.groupDeleteButton.Click += new System.EventHandler(this.groupDeleteButton_Click);
            // 
            // groupsDeleteDropdown
            // 
            this.groupsDeleteDropdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupsDeleteDropdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupsDeleteDropdown.FormattingEnabled = true;
            this.groupsDeleteDropdown.Location = new System.Drawing.Point(329, 19);
            this.groupsDeleteDropdown.Name = "groupsDeleteDropdown";
            this.groupsDeleteDropdown.Size = new System.Drawing.Size(427, 26);
            this.groupsDeleteDropdown.TabIndex = 1;
            // 
            // groupsList
            // 
            this.groupsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.groupsList.FormattingEnabled = true;
            this.groupsList.Location = new System.Drawing.Point(12, 19);
            this.groupsList.Name = "groupsList";
            this.groupsList.Size = new System.Drawing.Size(300, 143);
            this.groupsList.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.alreadyMappedList);
            this.groupBox2.Controls.Add(this.unMapButton);
            this.groupBox2.Controls.Add(this.notMappedList);
            this.groupBox2.Controls.Add(this.mapButton);
            this.groupBox2.Controls.Add(this.userAddButton);
            this.groupBox2.Controls.Add(this.usersList);
            this.groupBox2.Controls.Add(this.userAddTextbox);
            this.groupBox2.Controls.Add(this.usersDeleteDropdown);
            this.groupBox2.Controls.Add(this.userDeleteButton);
            this.groupBox2.Location = new System.Drawing.Point(12, 195);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(847, 245);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Users";
            // 
            // alreadyMappedList
            // 
            this.alreadyMappedList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.alreadyMappedList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alreadyMappedList.FormattingEnabled = true;
            this.alreadyMappedList.Items.AddRange(new object[] {
            "Priority",
            "Standard"});
            this.alreadyMappedList.Location = new System.Drawing.Point(329, 113);
            this.alreadyMappedList.Name = "alreadyMappedList";
            this.alreadyMappedList.Size = new System.Drawing.Size(427, 26);
            this.alreadyMappedList.TabIndex = 11;
            // 
            // unMapButton
            // 
            this.unMapButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unMapButton.ForeColor = System.Drawing.Color.White;
            this.unMapButton.Location = new System.Drawing.Point(762, 113);
            this.unMapButton.Name = "unMapButton";
            this.unMapButton.Size = new System.Drawing.Size(75, 26);
            this.unMapButton.TabIndex = 12;
            this.unMapButton.Text = "Remove";
            this.unMapButton.UseVisualStyleBackColor = true;
            this.unMapButton.Click += new System.EventHandler(this.unMapButton_Click);
            // 
            // notMappedList
            // 
            this.notMappedList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.notMappedList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notMappedList.FormattingEnabled = true;
            this.notMappedList.Items.AddRange(new object[] {
            "Admin",
            "Normal",
            "Power Users"});
            this.notMappedList.Location = new System.Drawing.Point(329, 81);
            this.notMappedList.Name = "notMappedList";
            this.notMappedList.Size = new System.Drawing.Size(427, 26);
            this.notMappedList.TabIndex = 9;
            // 
            // mapButton
            // 
            this.mapButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mapButton.ForeColor = System.Drawing.Color.White;
            this.mapButton.Location = new System.Drawing.Point(762, 81);
            this.mapButton.Name = "mapButton";
            this.mapButton.Size = new System.Drawing.Size(75, 26);
            this.mapButton.TabIndex = 10;
            this.mapButton.Text = "Map";
            this.mapButton.UseVisualStyleBackColor = true;
            this.mapButton.Click += new System.EventHandler(this.mapButton_Click);
            // 
            // userAddButton
            // 
            this.userAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userAddButton.ForeColor = System.Drawing.Color.White;
            this.userAddButton.Location = new System.Drawing.Point(762, 51);
            this.userAddButton.Name = "userAddButton";
            this.userAddButton.Size = new System.Drawing.Size(75, 24);
            this.userAddButton.TabIndex = 8;
            this.userAddButton.Text = "Add";
            this.userAddButton.UseVisualStyleBackColor = true;
            this.userAddButton.Click += new System.EventHandler(this.userAddButton_Click);
            // 
            // usersList
            // 
            this.usersList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usersList.FormattingEnabled = true;
            this.usersList.Location = new System.Drawing.Point(12, 19);
            this.usersList.Name = "usersList";
            this.usersList.Size = new System.Drawing.Size(300, 208);
            this.usersList.TabIndex = 5;
            this.usersList.SelectedIndexChanged += new System.EventHandler(this.usersList_SelectedIndexChanged);
            // 
            // userAddTextbox
            // 
            this.userAddTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userAddTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userAddTextbox.Location = new System.Drawing.Point(329, 51);
            this.userAddTextbox.Name = "userAddTextbox";
            this.userAddTextbox.Size = new System.Drawing.Size(427, 24);
            this.userAddTextbox.TabIndex = 7;
            // 
            // usersDeleteDropdown
            // 
            this.usersDeleteDropdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.usersDeleteDropdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usersDeleteDropdown.FormattingEnabled = true;
            this.usersDeleteDropdown.Location = new System.Drawing.Point(329, 19);
            this.usersDeleteDropdown.Name = "usersDeleteDropdown";
            this.usersDeleteDropdown.Size = new System.Drawing.Size(427, 26);
            this.usersDeleteDropdown.TabIndex = 5;
            // 
            // userDeleteButton
            // 
            this.userDeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userDeleteButton.ForeColor = System.Drawing.Color.White;
            this.userDeleteButton.Location = new System.Drawing.Point(762, 19);
            this.userDeleteButton.Name = "userDeleteButton";
            this.userDeleteButton.Size = new System.Drawing.Size(75, 26);
            this.userDeleteButton.TabIndex = 6;
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
            this.stopServerButton.TabIndex = 3;
            this.stopServerButton.Text = "Stop server";
            this.stopServerButton.UseVisualStyleBackColor = false;
            this.stopServerButton.Click += new System.EventHandler(this.stopServerButton_Click);
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
        private System.Windows.Forms.Button userAddButton;
        private System.Windows.Forms.TextBox userAddTextbox;
        private System.Windows.Forms.ComboBox usersDeleteDropdown;
        private System.Windows.Forms.Button userDeleteButton;
        private System.Windows.Forms.ComboBox alreadyMappedList;
        private System.Windows.Forms.Button unMapButton;
        private System.Windows.Forms.Button stopServerButton;
    }
}
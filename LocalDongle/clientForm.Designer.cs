namespace LocalDongle
{
    partial class clientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(clientForm));
            this.smsView = new System.Windows.Forms.TextBox();
            this.smsList = new System.Windows.Forms.ListBox();
            this.sendMessageTextbox = new System.Windows.Forms.TextBox();
            this.sendMessageButton = new System.Windows.Forms.Button();
            this.phoneTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.noSmsAvailablePanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.smsAvailablePanel = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.resetPasswordButton = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.noSmsAvailablePanel.SuspendLayout();
            this.smsAvailablePanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // smsView
            // 
            this.smsView.BackColor = System.Drawing.SystemColors.Control;
            this.smsView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.smsView.Location = new System.Drawing.Point(223, 0);
            this.smsView.Multiline = true;
            this.smsView.Name = "smsView";
            this.smsView.ReadOnly = true;
            this.smsView.Size = new System.Drawing.Size(426, 270);
            this.smsView.TabIndex = 1;
            // 
            // smsList
            // 
            this.smsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.smsList.FormattingEnabled = true;
            this.smsList.Location = new System.Drawing.Point(0, 0);
            this.smsList.Name = "smsList";
            this.smsList.Size = new System.Drawing.Size(217, 273);
            this.smsList.TabIndex = 2;
            this.smsList.SelectedIndexChanged += new System.EventHandler(this.smsList_SelectedIndexChanged);
            // 
            // sendMessageTextbox
            // 
            this.sendMessageTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sendMessageTextbox.Location = new System.Drawing.Point(6, 19);
            this.sendMessageTextbox.Multiline = true;
            this.sendMessageTextbox.Name = "sendMessageTextbox";
            this.sendMessageTextbox.Size = new System.Drawing.Size(438, 100);
            this.sendMessageTextbox.TabIndex = 1;
            // 
            // sendMessageButton
            // 
            this.sendMessageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendMessageButton.Location = new System.Drawing.Point(369, 125);
            this.sendMessageButton.Name = "sendMessageButton";
            this.sendMessageButton.Size = new System.Drawing.Size(75, 34);
            this.sendMessageButton.TabIndex = 3;
            this.sendMessageButton.Text = "Send";
            this.sendMessageButton.UseVisualStyleBackColor = true;
            this.sendMessageButton.Click += new System.EventHandler(this.sendMessageButton_Click);
            // 
            // phoneTextbox
            // 
            this.phoneTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.phoneTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneTextbox.Location = new System.Drawing.Point(32, 127);
            this.phoneTextbox.MaxLength = 10;
            this.phoneTextbox.Name = "phoneTextbox";
            this.phoneTextbox.Size = new System.Drawing.Size(331, 31);
            this.phoneTextbox.TabIndex = 2;
            this.phoneTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phoneTextbox_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "To";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.noSmsAvailablePanel);
            this.groupBox1.Controls.Add(this.smsAvailablePanel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(664, 295);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "View SMS";
            // 
            // noSmsAvailablePanel
            // 
            this.noSmsAvailablePanel.Controls.Add(this.label1);
            this.noSmsAvailablePanel.Location = new System.Drawing.Point(9, 19);
            this.noSmsAvailablePanel.Name = "noSmsAvailablePanel";
            this.noSmsAvailablePanel.Size = new System.Drawing.Size(649, 270);
            this.noSmsAvailablePanel.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(182, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "No SMS Received";
            // 
            // smsAvailablePanel
            // 
            this.smsAvailablePanel.Controls.Add(this.smsList);
            this.smsAvailablePanel.Controls.Add(this.smsView);
            this.smsAvailablePanel.Location = new System.Drawing.Point(9, 19);
            this.smsAvailablePanel.Name = "smsAvailablePanel";
            this.smsAvailablePanel.Size = new System.Drawing.Size(649, 270);
            this.smsAvailablePanel.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.sendMessageTextbox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.sendMessageButton);
            this.groupBox2.Controls.Add(this.phoneTextbox);
            this.groupBox2.Location = new System.Drawing.Point(12, 313);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(451, 169);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Send SMS";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.resetPasswordButton);
            this.groupBox3.Location = new System.Drawing.Point(470, 313);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(206, 169);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Links";
            // 
            // resetPasswordButton
            // 
            this.resetPasswordButton.AutoSize = true;
            this.resetPasswordButton.Location = new System.Drawing.Point(9, 20);
            this.resetPasswordButton.Name = "resetPasswordButton";
            this.resetPasswordButton.Size = new System.Drawing.Size(84, 13);
            this.resetPasswordButton.TabIndex = 4;
            this.resetPasswordButton.TabStop = true;
            this.resetPasswordButton.Text = "Reset Password";
            this.resetPasswordButton.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.resetPasswordButton_LinkClicked);
            // 
            // clientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 492);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "clientForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Local Dongle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.clientForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.noSmsAvailablePanel.ResumeLayout(false);
            this.noSmsAvailablePanel.PerformLayout();
            this.smsAvailablePanel.ResumeLayout(false);
            this.smsAvailablePanel.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox smsView;
        private System.Windows.Forms.ListBox smsList;
        private System.Windows.Forms.TextBox sendMessageTextbox;
        private System.Windows.Forms.Button sendMessageButton;
        private System.Windows.Forms.TextBox phoneTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.LinkLabel resetPasswordButton;
        private System.Windows.Forms.Panel smsAvailablePanel;
        private System.Windows.Forms.Panel noSmsAvailablePanel;
        private System.Windows.Forms.Label label1;
    }
}
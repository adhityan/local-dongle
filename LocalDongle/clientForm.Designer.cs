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
            this.sendMessageTextbox = new System.Windows.Forms.TextBox();
            this.sendMessageButton = new System.Windows.Forms.Button();
            this.phoneTextbox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.resetPasswordButton = new System.Windows.Forms.LinkLabel();
            this.nameLabel = new System.Windows.Forms.Label();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.toPhoneRadio = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.toGroupRadio = new System.Windows.Forms.RadioButton();
            this.groupCombobox = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
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
            this.sendMessageButton.Location = new System.Drawing.Point(368, 160);
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
            this.phoneTextbox.Location = new System.Drawing.Point(6, 162);
            this.phoneTextbox.MaxLength = 10;
            this.phoneTextbox.Name = "phoneTextbox";
            this.phoneTextbox.Size = new System.Drawing.Size(356, 31);
            this.phoneTextbox.TabIndex = 2;
            this.phoneTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phoneTextbox_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupCombobox);
            this.groupBox2.Controls.Add(this.toGroupRadio);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.toPhoneRadio);
            this.groupBox2.Controls.Add(this.sendMessageTextbox);
            this.groupBox2.Controls.Add(this.sendMessageButton);
            this.groupBox2.Controls.Add(this.phoneTextbox);
            this.groupBox2.Location = new System.Drawing.Point(12, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(451, 199);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Send SMS";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.resetPasswordButton);
            this.groupBox3.Location = new System.Drawing.Point(470, 43);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(206, 199);
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
            // nameLabel
            // 
            this.nameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(6, 9);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(72, 31);
            this.nameLabel.TabIndex = 11;
            this.nameLabel.Text = "User";
            // 
            // phoneLabel
            // 
            this.phoneLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneLabel.Location = new System.Drawing.Point(577, 19);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(99, 20);
            this.phoneLabel.TabIndex = 12;
            this.phoneLabel.Text = "9999999999";
            // 
            // toPhoneRadio
            // 
            this.toPhoneRadio.Checked = true;
            this.toPhoneRadio.Location = new System.Drawing.Point(43, 139);
            this.toPhoneRadio.Name = "toPhoneRadio";
            this.toPhoneRadio.Size = new System.Drawing.Size(56, 17);
            this.toPhoneRadio.TabIndex = 0;
            this.toPhoneRadio.TabStop = true;
            this.toPhoneRadio.Text = "Phone";
            this.toPhoneRadio.UseVisualStyleBackColor = true;
            this.toPhoneRadio.CheckedChanged += new System.EventHandler(this.toPhoneRadio_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "To";
            // 
            // toGroupRadio
            // 
            this.toGroupRadio.Location = new System.Drawing.Point(105, 139);
            this.toGroupRadio.Name = "toGroupRadio";
            this.toGroupRadio.Size = new System.Drawing.Size(56, 17);
            this.toGroupRadio.TabIndex = 14;
            this.toGroupRadio.Text = "Group";
            this.toGroupRadio.UseVisualStyleBackColor = true;
            this.toGroupRadio.CheckedChanged += new System.EventHandler(this.toPhoneRadio_CheckedChanged);
            // 
            // groupCombobox
            // 
            this.groupCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.groupCombobox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupCombobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupCombobox.FormattingEnabled = true;
            this.groupCombobox.Location = new System.Drawing.Point(6, 162);
            this.groupCombobox.MaxDropDownItems = 7;
            this.groupCombobox.Name = "groupCombobox";
            this.groupCombobox.Size = new System.Drawing.Size(356, 32);
            this.groupCombobox.Sorted = true;
            this.groupCombobox.TabIndex = 15;
            this.groupCombobox.Visible = false;
            // 
            // clientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 257);
            this.Controls.Add(this.phoneLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "clientForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Local Dongle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.clientForm_FormClosing);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sendMessageTextbox;
        private System.Windows.Forms.Button sendMessageButton;
        private System.Windows.Forms.TextBox phoneTextbox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.LinkLabel resetPasswordButton;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.RadioButton toGroupRadio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton toPhoneRadio;
        private System.Windows.Forms.ComboBox groupCombobox;
    }
}
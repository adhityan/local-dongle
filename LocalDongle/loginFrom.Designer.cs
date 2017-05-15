namespace LocalDongle
{
    partial class loginFrom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginFrom));
            this.usernameTextbox = new System.Windows.Forms.TextBox();
            this.passwordTextbox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.clientBox = new System.Windows.Forms.GroupBox();
            this.registerButton = new System.Windows.Forms.LinkLabel();
            this.serverpathTextbox = new System.Windows.Forms.TextBox();
            this.serverBox = new System.Windows.Forms.GroupBox();
            this.startServerButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.clientBox.SuspendLayout();
            this.serverBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernameTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextbox.Location = new System.Drawing.Point(78, 57);
            this.usernameTextbox.MaxLength = 50;
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.Size = new System.Drawing.Size(230, 22);
            this.usernameTextbox.TabIndex = 0;
            this.usernameTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.usernameTextbox_KeyDown);
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextbox.Location = new System.Drawing.Point(78, 98);
            this.passwordTextbox.MaxLength = 25;
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.PasswordChar = '*';
            this.passwordTextbox.Size = new System.Drawing.Size(230, 22);
            this.passwordTextbox.TabIndex = 1;
            this.passwordTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordTextbox_KeyDown);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(227, 136);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(81, 32);
            this.loginButton.TabIndex = 2;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // clientBox
            // 
            this.clientBox.Controls.Add(this.label3);
            this.clientBox.Controls.Add(this.label2);
            this.clientBox.Controls.Add(this.label1);
            this.clientBox.Controls.Add(this.registerButton);
            this.clientBox.Controls.Add(this.serverpathTextbox);
            this.clientBox.Controls.Add(this.usernameTextbox);
            this.clientBox.Controls.Add(this.loginButton);
            this.clientBox.Controls.Add(this.passwordTextbox);
            this.clientBox.Location = new System.Drawing.Point(12, 95);
            this.clientBox.Name = "clientBox";
            this.clientBox.Size = new System.Drawing.Size(324, 184);
            this.clientBox.TabIndex = 3;
            this.clientBox.TabStop = false;
            this.clientBox.Text = "Client";
            // 
            // registerButton
            // 
            this.registerButton.AutoSize = true;
            this.registerButton.Location = new System.Drawing.Point(13, 146);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(46, 13);
            this.registerButton.TabIndex = 4;
            this.registerButton.TabStop = true;
            this.registerButton.Text = "Register";
            this.registerButton.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.registerButton_LinkClicked);
            // 
            // serverpathTextbox
            // 
            this.serverpathTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.serverpathTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverpathTextbox.Location = new System.Drawing.Point(78, 19);
            this.serverpathTextbox.Name = "serverpathTextbox";
            this.serverpathTextbox.Size = new System.Drawing.Size(230, 22);
            this.serverpathTextbox.TabIndex = 3;
            this.serverpathTextbox.Text = "localhost";
            // 
            // serverBox
            // 
            this.serverBox.Controls.Add(this.startServerButton);
            this.serverBox.Location = new System.Drawing.Point(12, 12);
            this.serverBox.Name = "serverBox";
            this.serverBox.Size = new System.Drawing.Size(324, 67);
            this.serverBox.TabIndex = 4;
            this.serverBox.TabStop = false;
            this.serverBox.Text = "Server";
            // 
            // startServerButton
            // 
            this.startServerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startServerButton.Location = new System.Drawing.Point(16, 21);
            this.startServerButton.Name = "startServerButton";
            this.startServerButton.Size = new System.Drawing.Size(292, 32);
            this.startServerButton.TabIndex = 0;
            this.startServerButton.Text = "Start Server";
            this.startServerButton.UseVisualStyleBackColor = true;
            this.startServerButton.Click += new System.EventHandler(this.startServerButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Server IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Password";
            // 
            // loginFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 291);
            this.Controls.Add(this.serverBox);
            this.Controls.Add(this.clientBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "loginFrom";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.TopMost = true;
            this.clientBox.ResumeLayout(false);
            this.clientBox.PerformLayout();
            this.serverBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox usernameTextbox;
        private System.Windows.Forms.TextBox passwordTextbox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.GroupBox clientBox;
        private System.Windows.Forms.TextBox serverpathTextbox;
        private System.Windows.Forms.GroupBox serverBox;
        private System.Windows.Forms.Button startServerButton;
        private System.Windows.Forms.LinkLabel registerButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}


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
            this.SuspendLayout();
            // 
            // smsView
            // 
            this.smsView.BackColor = System.Drawing.Color.White;
            this.smsView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.smsView.Location = new System.Drawing.Point(238, 0);
            this.smsView.Multiline = true;
            this.smsView.Name = "smsView";
            this.smsView.ReadOnly = true;
            this.smsView.Size = new System.Drawing.Size(452, 468);
            this.smsView.TabIndex = 1;
            // 
            // smsList
            // 
            this.smsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.smsList.FormattingEnabled = true;
            this.smsList.Location = new System.Drawing.Point(1, 0);
            this.smsList.Name = "smsList";
            this.smsList.Size = new System.Drawing.Size(231, 468);
            this.smsList.TabIndex = 2;
            this.smsList.SelectedIndexChanged += new System.EventHandler(this.smsList_SelectedIndexChanged);
            // 
            // clientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 466);
            this.Controls.Add(this.smsList);
            this.Controls.Add(this.smsView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "clientForm";
            this.Text = "Local Dongle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox smsView;
        private System.Windows.Forms.ListBox smsList;
    }
}
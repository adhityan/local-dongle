namespace LocalDongle
{
    partial class mailboxForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mailboxForm));
            this.mailGrid = new System.Windows.Forms.DataGridView();
            this.incomingRadio = new System.Windows.Forms.RadioButton();
            this.outgoingRadio = new System.Windows.Forms.RadioButton();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.mailGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // mailGrid
            // 
            this.mailGrid.AllowUserToAddRows = false;
            this.mailGrid.AllowUserToDeleteRows = false;
            this.mailGrid.AllowUserToOrderColumns = true;
            this.mailGrid.AllowUserToResizeRows = false;
            this.mailGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.mailGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mailGrid.Location = new System.Drawing.Point(0, 25);
            this.mailGrid.Name = "mailGrid";
            this.mailGrid.ReadOnly = true;
            this.mailGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.mailGrid.Size = new System.Drawing.Size(727, 271);
            this.mailGrid.TabIndex = 0;
            // 
            // incomingRadio
            // 
            this.incomingRadio.AutoSize = true;
            this.incomingRadio.Location = new System.Drawing.Point(77, 3);
            this.incomingRadio.Name = "incomingRadio";
            this.incomingRadio.Size = new System.Drawing.Size(68, 17);
            this.incomingRadio.TabIndex = 2;
            this.incomingRadio.Text = "Incoming";
            this.incomingRadio.UseVisualStyleBackColor = true;
            this.incomingRadio.CheckedChanged += new System.EventHandler(this.inboxFilterRadio_CheckedChanged);
            // 
            // outgoingRadio
            // 
            this.outgoingRadio.AutoSize = true;
            this.outgoingRadio.Checked = true;
            this.outgoingRadio.Location = new System.Drawing.Point(3, 3);
            this.outgoingRadio.Name = "outgoingRadio";
            this.outgoingRadio.Size = new System.Drawing.Size(68, 17);
            this.outgoingRadio.TabIndex = 3;
            this.outgoingRadio.TabStop = true;
            this.outgoingRadio.Text = "Outgoing";
            this.outgoingRadio.UseVisualStyleBackColor = true;
            this.outgoingRadio.CheckedChanged += new System.EventHandler(this.inboxFilterRadio_CheckedChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(682, 5);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(44, 13);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Refresh";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // mailboxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 291);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.mailGrid);
            this.Controls.Add(this.incomingRadio);
            this.Controls.Add(this.outgoingRadio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mailboxForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mailbox";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.mailGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView mailGrid;
        private System.Windows.Forms.RadioButton incomingRadio;
        private System.Windows.Forms.RadioButton outgoingRadio;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}
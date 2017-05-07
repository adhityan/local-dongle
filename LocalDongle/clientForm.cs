using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LocalDongle.Structs;

namespace LocalDongle
{
    public partial class clientForm : Form
    {
        private int uid;
        private List<SMSObject> sms;

        public clientForm(int uid)
        {
            InitializeComponent();
            this.uid = uid;
            init();
        }

        public void init()
        {
            sms = new List<SMSObject>();

            sms.Add(new SMSObject("9910314001", "Test"));
            sms.Add(new SMSObject("9999999999", "Test 1"));
            sms.Add(new SMSObject("9910314001", "Test 2"));

            smsList.DataSource = sms.Select(p => p.from).ToArray();
        }

        private void smsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SMSObject select = sms[smsList.SelectedIndex];
            smsView.Text = select.content;
        }
    }
}

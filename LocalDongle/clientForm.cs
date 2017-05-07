using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LocalDongle.DongleServer;
using System.ServiceModel;
using DongleService.Structs;

namespace LocalDongle
{
    public partial class clientForm : Form
    {
        private long uid;
        private List<SMSObject> sms;
        private DongleServiceContractClient client;

        public clientForm(long uid, string server)
        {
            InitializeComponent();
            this.uid = uid;

            string url = string.Format("net.tcp://{0}/DongleService", server);
            client = new DongleServiceContractClient(new NetTcpBinding(), new EndpointAddress(url));
            init();
        }

        public void init()
        {
            client.Open();
            sms = client.getSMS(this.uid).ToList();
            smsList.DataSource = sms.Select(p => p.from).ToArray();
        }

        private void smsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SMSObject select = sms[smsList.SelectedIndex];
            smsView.Text = select.content;
        }

        private void clientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.Close();
        }
    }
}

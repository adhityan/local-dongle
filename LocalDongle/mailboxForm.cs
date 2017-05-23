using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DongleService;
using System.Data.SqlServerCe;

namespace LocalDongle
{
    public partial class mailboxForm : Form
    {
        private DongleData database;
        private List<dynamic> display;

        public mailboxForm()
        {
            InitializeComponent();
            database = DongleData.Instance;
            init();
        }

        private void init()
        {
            display = new List<dynamic>();
            mailGrid.DataSource = new BindingSource(new BindingList<dynamic>(display), null);
            loadCorrectData();
        }

        private void loadCorrectData()
        {
            if (outgoingRadio.Checked) loadSentData();
            else if (incomingRadio.Checked) loadReceivedData();
        }

        private void loadSentData()
        {
            SqlCeCommand command = new SqlCeCommand("select recepiant, message from sms_sent");
            var result = DongleData.Instance.runTableQuery(command);

            display.Clear();
            while (result.Read())
            {
                display.Add(new { To = result.GetString(0), Message = result.GetString(1) });
            }

            ((BindingSource)mailGrid.DataSource).ResetBindings(false);
        }

        private void loadReceivedData()
        {
            display.Clear();
            ((BindingSource)mailGrid.DataSource).ResetBindings(false);
        }

        private void inboxFilterRadio_CheckedChanged(object sender, EventArgs e)
        {
            loadCorrectData();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            loadCorrectData();
        }
    }
}

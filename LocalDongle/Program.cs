using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LocalDongle
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            if (Util.getMutex("{cd079aae19a36e7a540bd500570679f5}"))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Form f = new loginFrom();

                if(!f.IsDisposed) Application.Run(f);
            }
            else MessageBox.Show("Existing instance of LocalDongle is running. This launch is aborted.", "Launch failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}

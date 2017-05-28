using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

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

                System.IO.Stream log4NetConfigStream = System.Reflection.Assembly.GetExecutingAssembly()
                .GetManifestResourceStream("LocalDongle.log4NetConfig.xml");
                log4net.Config.XmlConfigurator.Configure(log4NetConfigStream);

                try
                {
                    Form f = new loginFrom();
                    if (!f.IsDisposed) Application.Run(f);
                }
                catch
                {
                    if (Debugger.IsAttached) Debugger.Break();
                    else MessageBox.Show("This software is unable to load all required components. Recovering from this error is not possible. Application will terminate now.", "Something went wrong!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            else MessageBox.Show("Existing instance of LocalDongle is running. This launch is aborted.", "Launch failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}

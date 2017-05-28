using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.Threading;

namespace LocalDongle
{
    class Util
    {
        public static bool IsElevated()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static bool getMutex(string lockString)
        {
            return true;
            Mutex mutex = new Mutex(true, lockString);

            try
            {
                return mutex.WaitOne(TimeSpan.FromSeconds(7), true);
            }
            catch
            {
                return true;
            }
        }

        public static string implodeToString(List<object> list)
        {
            string payload = "";

            foreach (var item in list)
            {
                if (item is string) payload += "'" + item + "'";
                else payload += item;
                payload += ", ";
            }

            payload = payload.TrimEnd(new char[] { ',', ' ' });
            return payload;
        }
    }
}

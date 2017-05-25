using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DongleService
{
    class Util
    {
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

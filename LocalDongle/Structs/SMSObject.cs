using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocalDongle.Structs
{
    class SMSObject
    {
        public string from { get; set; }
        public string content { get; set; }
        public DateTime time { get; set; }

        public SMSObject(string from, string content) : this(from, content, DateTime.Now) { }
        public SMSObject(string from, string content, DateTime time)
        {
            this.from = from;
            this.content = content;
            this.time = time;
        }
    }
}

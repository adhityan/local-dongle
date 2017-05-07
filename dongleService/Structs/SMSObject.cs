using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DongleService.Structs
{
    [DataContract]
    public class SMSObject
    {
        [DataMember]
        public string from { get; set; }

        [DataMember]
        public string content { get; set; }

        [DataMember]
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

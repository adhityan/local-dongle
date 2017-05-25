using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DongleService.Structs
{
    [DataContract]
    public class UserObject
    {
        [DataMember]
        public long id { get; set; }

        [DataMember]
        public string username { get; set; }

        [DataMember]
        public string phone { get; set; }

        [DataMember]
        public string email { get; set; }

        [DataMember]
        public string name { get; set; }

        public UserObject(long id, string username, string phone, string email, string name)
        {
            this.id = id;
            this.name = name;
            this.phone = phone;
            this.email = email;
            this.username = username;
        }
    }
}

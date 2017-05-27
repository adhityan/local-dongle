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

        public UserObject(long id, string username)
        {
            this.id = id;
            this.username = username;
        }
    }
}

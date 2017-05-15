using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DongleService.Structs
{
    [DataContract]
    public class ExecuteResponse
    {
        [DataMember]
        public bool status { get; set; }

        [DataMember]
        public string errorMessage { get; set; }

        public ExecuteResponse() : this(true, null) { }
        public ExecuteResponse(string errorMessage) : this(false, errorMessage) { }
        public ExecuteResponse(bool status, string errorMessage)
        {
            this.status = status;
            this.errorMessage = errorMessage;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DongleService.Structs
{
    [DataContract]
    public class LoginResponse
    {
        bool isSuccess = true;
        long uid;

        [DataMember]
        public bool IsSuccess
        {
            get { return isSuccess; }
            private set { isSuccess = value; }
        }

        [DataMember]
        public long UID
        {
            get { return uid; }
            private set { uid = value; }
        }

        public LoginResponse(long uid = 0)
        {
            if (uid == 0) isSuccess = false;
            else
            {
                UID = uid;
                isSuccess = true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace dongleService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface dongleServiceContract
    {
        [OperationContract]
        loginResponse login(string username, string password);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations
    [DataContract]
    public class loginResponse
    {
        bool isSuccess = true;
        int  uid;

        [DataMember]
        public bool IsSuccess
        {
            get { return isSuccess; }
            private set { isSuccess = value; }
        }

        [DataMember]
        public int UID
        {
            get { return uid; }
            private set { uid = value; }
        }

        public loginResponse(int uid = 0)
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

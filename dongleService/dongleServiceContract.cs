using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using DongleService.Structs;

namespace DongleService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface DongleServiceContract
    {
        [OperationContract]
        LoginResponse login(string username, string password);

        [OperationContract]
        SMSObject[] getSMS(long uid);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlServerCe;
using DongleService.Structs;

namespace DongleService
{
    public class DongleService : DongleServiceContract
    {
        public LoginResponse login(string username, string password)
        {
            SqlCeCommand command = new SqlCeCommand("select id from users where username = @username and password = @password and enabled = 1");
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            var result = DongleData.Instance.runScalarQuery(command);
            if(result != null) return new LoginResponse((long)result);
            else return new LoginResponse();
        }

        public SMSObject[] getSMS(long uid)
        {
            List<SMSObject> sms = new List<SMSObject>();

            sms.Add(new SMSObject("9910314001", "Test"));
            sms.Add(new SMSObject("9999999999", "Test 1"));
            sms.Add(new SMSObject("9910314001", "Test 2"));

            return sms.ToArray();
        }
    }
}

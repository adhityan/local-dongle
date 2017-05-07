using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlServerCe;

namespace dongleService
{
    public class dongleService : dongleServiceContract
    {
        public loginResponse login(string username, string password)
        {
            SqlCeCommand command = new SqlCeCommand("select id from users where username = @username and password = @password and enabled = 1");
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            var result = dongleData.Instance.runScalarQuery(command);
            if(result != null) return new loginResponse((int)result);
            else return new loginResponse();
        }
    }
}

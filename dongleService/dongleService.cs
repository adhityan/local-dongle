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
            return sms.ToArray();
        }

        public ExecuteResponse addNewUser(string username, string password, string name, string email)
        {
            try
            {
                if (username.Length == 0) return new ExecuteResponse("user name cannot be empty");
                SqlCeCommand command = new SqlCeCommand("insert into users(username, password, name, email, enabled) values(@username, @password, @name, @email, 0)");
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@name", name);

                var result = DongleData.Instance.runExecQuery(command);
                if (result != 0) return new ExecuteResponse();
                else return new ExecuteResponse("Adding new user failed");
            }
            catch { return new ExecuteResponse("That user name is already taken"); }
        }

        public ExecuteResponse updatePassword(long uid, string password)
        {
            try
            {
                SqlCeCommand command = new SqlCeCommand("update users set password = @password where id = @uid");
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@uid", uid);

                var result = DongleData.Instance.runExecQuery(command);
                if (result != 0) return new ExecuteResponse();
                else return new ExecuteResponse("Password update failed");
            }
            catch { return new ExecuteResponse("Password update failed"); }
        }

        public ExecuteResponse sendSMS(long senderId, string recepiant, string messsage)
        {
            try
            {
                if (recepiant.Length <= 5) return new ExecuteResponse("Invalid phone number. Check again!");
                else if (messsage.Length == 0) return new ExecuteResponse("No message content!");

                SqlCeCommand command = new SqlCeCommand("insert into sms_sent(sender_id, recepiant, message) values(@sender_id, @recepiant, @message)");
                command.Parameters.AddWithValue("@sender_id", senderId.ToString());
                command.Parameters.AddWithValue("@recepiant", recepiant);
                command.Parameters.AddWithValue("@message", messsage);

                var result = DongleData.Instance.runExecQuery(command);
                if (result != 0) return new ExecuteResponse();
                else return new ExecuteResponse("Message could not be sent");
            }
            catch { return new ExecuteResponse("Message could not be sent"); }
        }
    }
}

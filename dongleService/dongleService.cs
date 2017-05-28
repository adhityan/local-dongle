using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlServerCe;
using DongleService.Structs;
using GsmComm.GsmCommunication;
using GsmComm.PduConverter;

namespace DongleService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class DongleService : DongleServiceContract
    {
        private GsmCommMain comm;

        public DongleService() : this(null) { }
        public DongleService(GsmCommMain comm)
        {
            this.comm = comm;
        }

        public LoginResponse login(string username, string password)
        {
            SqlCeCommand command = new SqlCeCommand("select id from users where username = @username and password = @password and enabled = 1");
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            var result = DongleData.Instance.runScalarQuery(command);
            if(result != null) return new LoginResponse((long)result);
            else return new LoginResponse();
        }

        public ExecuteResponse addNewUser(string username, string password)
        {
            try
            {
                if (username.Length == 0) return new ExecuteResponse("user name cannot be empty");
                SqlCeCommand command = new SqlCeCommand("insert into users(username, password, enabled) values(@username, @password, 0)");
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                var result = DongleData.Instance.runExecQuery(command);
                if (result != 0) return new ExecuteResponse();
                else return new ExecuteResponse("Adding new user failed");
            }
            catch { return new ExecuteResponse("That user name or phone number is already taken"); }
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
                if (recepiant.Length != 10) return new ExecuteResponse("Invalid phone number. Check again!");
                else if (messsage.Length == 0) return new ExecuteResponse("No message content!");

                comm.SendMessage(new SmsSubmitPdu(messsage, recepiant));

                SqlCeCommand command = new SqlCeCommand("insert into sms_sent(sender_id, recepiant, message, timestamp) values(@sender_id, @recepiant, @message, @timestamp)");
                command.Parameters.AddWithValue("@sender_id", senderId.ToString());
                command.Parameters.AddWithValue("@recepiant", recepiant);
                command.Parameters.AddWithValue("@message", messsage);
                command.Parameters.AddWithValue("@timestamp", DateTime.Now.ToString());

                var result = DongleData.Instance.runExecQuery(command);
                if (result != 0) return new ExecuteResponse();
                else return new ExecuteResponse("Message could not be sent");
            }
            catch { return new ExecuteResponse("Message could not be sent"); }
        }

        public ExecuteResponse sendGroupSMS(long senderId, long groupId, string messsage)
        {
            try
            {
                if (messsage.Length == 0) return new ExecuteResponse("No message content!");

                SqlCeCommand command = new SqlCeCommand("select user_id from users_groups where group_id = @gid");
                command.Parameters.AddWithValue("@gid", groupId.ToString());

                var groups = new List<long>();
                var reader = DongleData.Instance.runTableQuery(command);
                while (reader.Read())
                {
                    groups.Add((long)reader[0]);
                }
                reader.Close();

                var recepiants = new List<string>();
                if (groups.Count > 0)
                {
                    var commandSql = "select phone from contacts where id in ({0})";
                    commandSql = string.Format(commandSql, Util.implodeToString(groups.Cast<object>().ToList()));

                    reader = DongleData.Instance.runTableQuery(commandSql);
                    while (reader.Read())
                    {
                        recepiants.Add((string)reader[0]);
                    }
                    reader.Close();
                }

                bool allOK = true;
                foreach (var recepiant in recepiants)
                {
                    if (recepiant.Length != 10) continue;
                    comm.SendMessage(new SmsSubmitPdu(messsage, recepiant));

                    command = new SqlCeCommand("insert into sms_sent(sender_id, recepiant, message, timestamp) values(@sender_id, @recepiant, @message, @timestamp)");
                    command.Parameters.AddWithValue("@sender_id", senderId.ToString());
                    command.Parameters.AddWithValue("@recepiant", recepiant);
                    command.Parameters.AddWithValue("@message", messsage);
                    command.Parameters.AddWithValue("@timestamp", DateTime.Now.ToString());

                    var result = DongleData.Instance.runExecQuery(command);
                    if (result == 0) allOK = false;
                }

                if(allOK) return new ExecuteResponse();
                else return new ExecuteResponse("Some messages could not be sent.");
            }
            catch { return new ExecuteResponse("Messages could not be sent"); }
        }

        public List<KeyValuePair<long, string>> getAllGroups()
        {
            var groups = new List<KeyValuePair<long, string>>();

            var reader = DongleData.Instance.runTableQuery("select id, name from groups");
            while (reader.Read())
            {
                groups.Add(new KeyValuePair<long, string>((long)reader[0], (string)reader[1]));
            }
            reader.Close();

            return groups;
        }

        public UserObject getUserInfo(long id)
        {
            UserObject response = null;
            SqlCeCommand command = new SqlCeCommand("select id, username from users where id = @uid");
            command.Parameters.AddWithValue("@uid", id.ToString());

            var reader = DongleData.Instance.runTableQuery(command);
            if (reader.Read())
            {
                response = new UserObject((long)reader["id"], (string)reader["username"]);
            }
            reader.Close();

            return response;
        }
    }
}

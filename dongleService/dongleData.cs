using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;

namespace dongleService
{
    public class dongleData
    {
        private static dongleData singleton = null;
        public static dongleData Instance
        {
            get
            {
                if (singleton == null) singleton = new dongleData();
                return singleton;
            }
        }

        private SqlCeConnection connection;
        private dongleData()
        {
            connection = new SqlCeConnection(@"Data Source=C:\Users\Micros\Documents\Visual Studio 2010\Projects\LocalDongle\dongleService\dongleData.sdf;");
            connection.Open();
        }

        ~dongleData()
        {
            connection.Close();
        }

        public SqlCeDataReader runTableQuery(string query)
        {
            SqlCeCommand command = new SqlCeCommand(query);
            return runTableQuery(command);
        }

        public SqlCeDataReader runTableQuery(SqlCeCommand command)
        {
            command.Connection = connection;
            return command.ExecuteReader();
        }

        public object runScalarQuery(string query)
        {
            SqlCeCommand command = new SqlCeCommand(query);
            return runScalarQuery(command);
        }

        public object runScalarQuery(SqlCeCommand command)
        {
            command.Connection = connection;
            return command.ExecuteScalar();
        }

        public int runExecQuery(string query)
        {
            SqlCeCommand command = new SqlCeCommand(query);
            return runExecQuery(command);
        }

        public int runExecQuery(SqlCeCommand command)
        {
            command.Connection = connection;
            return command.ExecuteNonQuery();
        }
    }
}

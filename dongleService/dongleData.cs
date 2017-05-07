using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;

namespace DongleService
{
    public class DongleData
    {
        private static DongleData singleton = null;
        public static DongleData Instance
        {
            get
            {
                if (singleton == null) singleton = new DongleData();
                return singleton;
            }
        }

        private SqlCeConnection connection;
        private DongleData()
        {
            connection = new SqlCeConnection(@"Data Source=C:\Users\Micros\Documents\Visual Studio 2010\Projects\LocalDongle\DongleService\dongledb.sdf;");
            connection.Open();
        }

        ~DongleData()
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

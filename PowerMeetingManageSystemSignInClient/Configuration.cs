using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerMeetingManageSystemSignInClient
{
    class Configuration
    {
        private static string connectionString;
        private static SqlConnection sqlConnection;

        public static string ConnectionString
        {
            get
            {
                return connectionString;
            }

            set
            {
                connectionString = value;
            }
        }

        public static SqlConnection SqlConnection
        {
            get
            {
                return sqlConnection;
            }

            set
            {
                sqlConnection = value;
            }
        }
    }
}

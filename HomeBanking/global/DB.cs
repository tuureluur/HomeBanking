using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace HomeBanking.global
{
    class DB
    {
        public static SQLiteConnection connection;

        public static void connect(string connectionString)
        {
            connection = new SQLiteConnection(connectionString);
            connection.Open();

        }

        // TODO: Desctuctor Connection.Close
    }
}
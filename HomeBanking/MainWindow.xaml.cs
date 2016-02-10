using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;

namespace HomeBanking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SQLiteConnection DBconnection = global.DB.connection;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            tbOutput.Clear();
            tbOutput.AppendText("DB State: " + DBconnection.State.ToString() + '\n');
            string sql = "select count(*) as cnt from MUTATIES";

            SQLiteCommand command = new SQLiteCommand(sql, DBconnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                tbOutput.AppendText("Aantal mutaties: " + reader["cnt"].ToString() + '\n');
            }

            string sqlInsert = "INSERT INTO MUTATIES (Datum, Naam, Bedrag) VALUES (?,?,?)";
            using (var cmd = new SQLiteCommand(sqlInsert, DBconnection))
            {
                cmd.CommandText = sqlInsert;
                using (var transaction = DBconnection.BeginTransaction())
                {
                    cmd.Parameters.Add("Datum", System.Data.DbType.Date);
                    cmd.Parameters.Add("Naam", System.Data.DbType.String);
                    cmd.Parameters.Add("Bedrag", System.Data.DbType.Double);
                    for (var i = 0; i < 10; i++)
                    {
                        cmd.Parameters["Datum"].Value = DateTime.Now;
                        cmd.Parameters["Naam"].Value = "Test " + i.ToString();
                        cmd.Parameters["Bedrag"].Value = 6.557;
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();

                }
            }
            reader.Close();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                tbOutput.AppendText("Aantal mutaties: " + reader["cnt"].ToString() + '\n');
            }
        }

    }
}

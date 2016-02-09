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

        /* IMPORT

        outputLog.Clear();
            outputLog.AppendText(DBconnection.Database.ToString()+ '\n');
            string sql = "select count(*) as cnt from MUTATIES";
            SQLiteCommand command = new SQLiteCommand(sql, DBconnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                outputLog.AppendText("Aantal mutaties: " + reader["cnt"].ToString() + '\n');
            }

            string sqlInsert =  "INSERT INTO MUTATIES (Id, Title, Language, PublicationDate, Publisher, Edition, OfficialUrl, Description, EBookFormat) VALUES (?,?,?,?,?,?,?,?)";
            using (var cmd = new SQLiteCommand(sqlInsert, DBconnection))
            {
                cmd.CommandText = sqlInsert;
                using (var transaction = DBconnection.BeginTransaction())
                {
                    for (var i = 0; i < 1000000; i++)
                    {
                        insertSQL.Parameters.Add(book.Id);
                        insertSQL.Parameters.Add(book.Title);
                        insertSQL.Parameters.Add(book.Language);
                        insertSQL.Parameters.Add(book.PublicationDate);
                        insertSQL.Parameters.Add(book.Publisher);
                        insertSQL.Parameters.Add(book.Edition);
                        insertSQL.Parameters.Add(book.OfficialUrl);
                        insertSQL.Parameters.Add(book.Description);
                        insertSQL.Parameters.Add(book.EBookFormat);

                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }
        */
    }
}

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
using System.Windows.Shapes;
using System.IO;
using CsvHelper;
using HomeBanking.classes;
using System.Data.SQLite;

namespace HomeBanking
{
    /// <summary>
    /// Interaction logic for ImportData.xaml
    /// </summary>
    public partial class ImportData : Window
    {
        public ImportData()
        {
            InitializeComponent();
        }

        private void doImportData()
        {
            var sr = new StreamReader(@"d:\Development\VS\HomeBanking\CSV\temp.csv");
            var csv = new CsvReader(sr);
            csv.Configuration.RegisterClassMap<ImporterINGB.Mapper>();
            IEnumerable<ImporterINGB.csvRecord> records = csv.GetRecords<ImporterINGB.csvRecord>();

            string sqlInsert = "INSERT INTO TRANSACTIONS (TR_DATE, TR_NAME, TR_AMOUNT, ACCOUNT, ACCOUNT_CONTRA, TR_CODE, ADD_SUB, TR_TYPE, TR_DESCRIPTION) VALUES (?,?,?,?,?,?,?,?,?)";
            using (var cmd = new SQLiteCommand(sqlInsert, global.DB.connection))
            {
                cmd.CommandText = sqlInsert;
                using (var transaction = global.DB.connection.BeginTransaction())
                {
                    cmd.Parameters.Add("TR_DATE", System.Data.DbType.Date);
                    cmd.Parameters.Add("TR_NAME", System.Data.DbType.String);
                    cmd.Parameters.Add("TR_AMOUNT", System.Data.DbType.Double);
                    cmd.Parameters.Add("ACCOUNT", System.Data.DbType.String);
                    cmd.Parameters.Add("ACCOUNT_CONTRA", System.Data.DbType.String);
                    cmd.Parameters.Add("TR_CODE", System.Data.DbType.String);
                    cmd.Parameters.Add("ADD_SUB", System.Data.DbType.String);
                    cmd.Parameters.Add("TR_TYPE", System.Data.DbType.String);
                    cmd.Parameters.Add("TR_DESCRIPTION", System.Data.DbType.String);

                    foreach (ImporterINGB.csvRecord record in records)
                    {
                        try
                        {
                            cmd.Parameters["TR_DATE"].Value = DateTime.ParseExact(record.Datum, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                            cmd.Parameters["TR_NAME"].Value = record.Omschrijving;
                            cmd.Parameters["TR_AMOUNT"].Value = Convert.ToDouble(record.Bedrag) * (record.AfBij == "Af" ? -1 : 1);
                            cmd.Parameters["ACCOUNT"].Value = record.Rekening;
                            cmd.Parameters["ACCOUNT_CONTRA"].Value = record.Tegenrekenening;
                            cmd.Parameters["TR_CODE"].Value = record.Code;
                            cmd.Parameters["ADD_SUB"].Value = record.AfBij;
                            cmd.Parameters["TR_TYPE"].Value = record.MutatieSoort;
                            cmd.Parameters["TR_DESCRIPTION"].Value = record.Mededelingen;

                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                            // ignore
                        }

                    }

                    transaction.Commit();

                }
            }
        }

        private void btnImportData_Click(object sender, RoutedEventArgs e)
        {
            doImportData();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            HomeBanking.Properties.Settings.Default.Save();
            Close();
        }
    }
}

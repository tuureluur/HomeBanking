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
using System.Diagnostics;

namespace HomeBanking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }


        private void TabItem_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "select strftime('%m', tr_date) as 'Maand', sum (tr_amount) as 'Totaal' from transactions " +
                         "where tr_date >= '2016-01-01' and internal_payment = 'false' " + 
                         "group by strftime('%m', tr_date) order by strftime('%m', tr_date)";

            System.Data.DataSet dataSet = new System.Data.DataSet();
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(sql, global.DB.connection);
            dataAdapter.Fill(dataSet);

            dgJaaroverzicht.ItemsSource = dataSet.Tables[0].DefaultView;
        }

        private void miImport_Click(object sender, RoutedEventArgs e)
        {
            ImportData frmImportData = new ImportData();
            frmImportData.ShowDialog();
        }
    }
}

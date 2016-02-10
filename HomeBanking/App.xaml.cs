using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HomeBanking
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs arg)
        {
            // TODO: Startup splash screen
            // TODO: DB locatie in app.config
            try
            {
                global.DB.connect("Data Source=d:\\Development\\VS\\HomeBanking\\Database\\MijnING.db;Version=3;");
            }
            catch (Exception e)
            {
                // TODO: DB automatisch aanmaken indien deze niet bestaat (met melding)
                MessageBox.Show("Database kan niet worden geopend: " + e.Message.ToString());
                Application.Current.Shutdown();
            }

            // Open the main window
            HomeBanking.MainWindow mainWindow = new HomeBanking.MainWindow();
            mainWindow.Show();

        }
    }

}

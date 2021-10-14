using Chat_Application_Clients.Stores;
using Chat_Application_Clients.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Chat_Application_Clients
{
    
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationStores navigationStore = new NavigationStores();
            navigationStore.CurrentViewModel = new LoginViewModel(navigationStore);
            MainWindow window = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
        
   


    }
}

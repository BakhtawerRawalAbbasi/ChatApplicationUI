using Chat_Application_Clients.Stores;
using Chat_Application_Clients.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Application_Clients.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private readonly NavigationStores _navigationStore;
        
        //delegate this property to the navigation source current view model property
        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public MainViewModel(NavigationStores navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}

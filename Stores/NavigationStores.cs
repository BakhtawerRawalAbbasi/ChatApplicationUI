using Chat_Application_Clients.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Application_Clients.Stores
{
     public class NavigationStores
    {
        public event Action CurrentViewModelChanged;

        public BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel 
        {
            get => _currentViewModel;

            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            //if it is does not equal null so it has something subscribe to it then we will invoke it ,all subscriber subscribed it will notify event

            CurrentViewModelChanged?.Invoke();
        }
    }
}

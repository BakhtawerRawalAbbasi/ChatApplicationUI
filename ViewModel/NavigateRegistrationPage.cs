﻿using Chat_Application_Clients.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Application_Clients.ViewModel
{
    public class NavigateRegistrationPage : CommandBase
    {
        private readonly NavigationStores _navigationStore;

        public NavigateRegistrationPage()
        {
        }

        public NavigateRegistrationPage(NavigationStores navigationStore)
        {
            _navigationStore = navigationStore;
        }
        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new RegistrationViewModel();
        }
    }
}

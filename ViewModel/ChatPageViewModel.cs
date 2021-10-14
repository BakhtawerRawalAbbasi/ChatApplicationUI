using Chat_Application_Clients.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Models;
using Model;
using System.Windows.Input;
using CommunicationLayer;

namespace Chat_Application_Clients.ViewModel
{
    public class ChatPageViewModel : BaseViewModel
    {
        private DataCommunication communication1;

        private ObservableCollection<User> userList;
        public ObservableCollection<User> UserList
        {
            get { return userList;  }
            set { userList = value; OnPropertyChanged("UserList"); }
        }

        public ChatPageViewModel()
        {
            UserList = new ObservableCollection<User>();
            communication1 = new DataCommunication();
          //  UserList = new ObservableCollection<ResponsetoListUser>();
            // LogoutCommand = new RelayCommand(Logout);

        }

        public ChatPageViewModel(ResponsetoListUser user)
        {
            UserList = new ObservableCollection<User>();
            for (int i = 0; i < user.userListResponse.Count; i++)
            {
                UserList.Add(user.userListResponse[i]);
            }
        }
    }
}

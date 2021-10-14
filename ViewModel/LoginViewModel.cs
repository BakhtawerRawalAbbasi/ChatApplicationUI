using Chat_Application_Clients.Stores;
using Chat_Application_Clients.ViewModels;
using CommunicationLayer;
using Model;
using Models;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
// we need refrences of model which I had create in communication layer using Chat_Application_Clients;

namespace Chat_Application_Clients.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        UserService userInFO;
        private UserLoginRequest currentEmployee;
        private DataCommunication communication1;
        UserLoginResponse userRegistation;
        UserLoginRequest userLogin;
        ResponsetoListUser userList;


        public NavigationStores navigation { get; set; }
        public UserLoginRequest CurrentEmployee
        {
            get { return currentEmployee; }
            set { currentEmployee = value; OnPropertyChanged("CurrentEmployee"); }
        }


        public ICommand NavigateRegistrationPage { get; }

        public ICommand NavigateChatPage { get; }
        public LoginViewModel(NavigationStores navigationStore)
        {
            navigation = navigationStore;
            userInFO = new UserService();
            NavigateRegistrationPage = new NavigateRegistrationPage(navigationStore);
            NavigateChatPage = new NavigateChatPage(navigationStore);
            communication1 = new DataCommunication();
            // mWindow = window;
            CurrentEmployee = new UserLoginRequest();
            communication1.Mess_Send += C1_Mess_Received;
            LoginCommand = new RelayCommand(Login);


        }

       public LoginViewModel()
        {

        }
        // Command for login
        public ICommand LoginCommand { get; set; }

        public void C1_Mess_Received(object mess, string messType)
        {
            if(messType == "Login Request")
            {
                userRegistation = (UserLoginResponse)mess;
                if (userRegistation.response == "succefull")
                {
                    communication1.DataSend("Current User Login");
                }
                else
                {
                    MessageBox.Show("Invalid User Name and Password");
                }


            }

            else if (messType == "Current User Login")
            {
               
                 if(messType== "Current User Login")
                {
                    userList = (ResponsetoListUser)mess;
                    navigation.CurrentViewModel = new ChatPageViewModel(userList);

                   // OnReceivedMess(mess, messType);
                }



            }
           
        }

        //protected virtual void OnReceivedMess(object mess, string messType)
     //   {

            // this method notify all subscriber
           // if (MessToChatPage != null)
                // Raise an event
          //      MessToChatPage(mess, messType);
      //  }


        public void UserListAdd(UserLoginRequest CurrentEmployee)
        {
            userInFO.AddUser(CurrentEmployee);

        }
        // secure string passed in from the view for user to logged into 
        public void Login()
        {
            string email = CurrentEmployee.Email;

            var password = CurrentEmployee.Password;

            communication1.DataSend<UserLoginRequest>(CurrentEmployee,"Login Request");


        }
    }
}

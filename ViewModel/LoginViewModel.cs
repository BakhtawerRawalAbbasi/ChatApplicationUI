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
        private SenderReceiverEmial senderEmail;
        private DataCommunication communication1;
        UserLoginResponse userRegistation;
        UserLoginRequest userLogin;
        ResponsetoListUser userList;
        LoginUser loginUser;


        public NavigationStores navigation { get; set; }
        public UserLoginRequest CurrentEmployee
        {
            get { return currentEmployee; }
            set { currentEmployee = value; OnPropertyChanged("CurrentEmployee"); }
        }

        public SenderReceiverEmial SenderEmail
        {
            get { return senderEmail; }
            set { senderEmail = value; OnPropertyChanged("SenderEmail"); }
        }


        public ICommand NavigateRegistrationPage { get; }

   
        public LoginViewModel(NavigationStores navigationStore)
        {
            navigation = navigationStore;
            userInFO = new UserService();
            NavigateRegistrationPage = new NavigateRegistrationPage(navigationStore);
            communication1 = DataCommunication.Instance;
            CurrentEmployee = new UserLoginRequest();
            SenderEmail = new SenderReceiverEmial();
            communication1.Mess_Send += C1_Mess_Received;
            LoginCommand = new RelayCommand(Login);


        }

       public LoginViewModel()
        {

        }

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

                else if (userRegistation.response == "Invalid")
                {
                    MessageBox.Show("Invalid name and password");

                }

                

            }

            else if (messType == "Current User Login")
            {
          
                    userList = (ResponsetoListUser)mess;
                    navigation.CurrentViewModel = new ChatPageViewModel(userList);
            }


           



        }




        public void Login()
        {
            RetreiveSenderEmail.Instance.SenderEmailID= CurrentEmployee.Email;
            communication1.DataSend<UserLoginRequest>(CurrentEmployee,"Login Request");

        }
    }
}

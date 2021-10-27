using Chat_Application_Clients.Stores;
using Chat_Application_Clients.ViewModels;
using CommunicationLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Chat_Application_Clients.ViewModel
{
   public class RegistrationViewModel : BaseViewModel
    {
        public NavigationStores navigation { get; set; }
        private RequesttoSignUP currentEmployee;
        private DataCommunication communication1;
        private ResponsetoSignUP registrationResponse;
        ResponsetoListUser userList;
        public RequesttoSignUP CurrentEmployee
        {
            get { return currentEmployee; }
            set { currentEmployee = value; OnPropertyChanged("CurrentEmployee"); }
        }
        
        public RegistrationViewModel(NavigationStores navigationStore)
        {
            navigation = navigationStore;
            communication1 = DataCommunication.Instance;
            CurrentEmployee = new RequesttoSignUP();
            NavigateLoginPage = new NavigateLoginPage(navigationStore);
            communication1.Mess_Send += C1_Mess_Received;
            RegisterationCommand = new RelayCommand(Register);
       

        }
        public RegistrationViewModel()
        {
            communication1 = DataCommunication.Instance;
            // mWindow = window;
            CurrentEmployee = new RequesttoSignUP();
            communication1.Mess_Send += C1_Mess_Received;
            RegisterationCommand = new RelayCommand(Register);
       

        }
        public ICommand RegisterationCommand { get; set; }

        public ICommand NavigateLoginPage { get; }
        //   public ICommand AccessibilityCommand { get; set; }
        public void C1_Mess_Received(object mess, string messType)
        {

            if (messType == "Registration")
            {
                registrationResponse = (ResponsetoSignUP)mess;

                if (registrationResponse.registrationResponse == "succefull")
                {
                    communication1.DataSend("Current User Login");
                }

                if (registrationResponse.registrationResponse == "Email ID already Exit")

                {
                    MessageBox.Show("Email ID already Exit");

                }




            }

            else if (messType == "Current User Login")
            {

                userList = (ResponsetoListUser)mess;
                navigation.CurrentViewModel = new ChatPageViewModel(userList);

            }


            

        }

        public void Register()
        {
            string email = CurrentEmployee.Email;
      
            var password = CurrentEmployee.Password;
            RetreiveSenderEmail.Instance.SenderName = CurrentEmployee.UserName;
            communication1.DataSend<RequesttoSignUP>(CurrentEmployee, "Registration");



        }
    }
}

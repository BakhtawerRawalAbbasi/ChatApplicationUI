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
        private RequesttoSignUP currentEmployee;
        private DataCommunication communication1;
        public RequesttoSignUP CurrentEmployee
        {
            get { return currentEmployee; }
            set { currentEmployee = value; OnPropertyChanged("CurrentEmployee"); }
        }
        // Client_socket client_Socket = new Client_socket();
        //  private Window mWindow;
        // public string Email { get; set; }

        // public string Password { get; set; }

        // we never strore password string in memory directly // it will encrypt tries to inject into your application ,its store password safely

       // public ICommand NavigateLoginPage { get; }

        public RegistrationViewModel()
        {
           // NavigateLoginPage = new NavigateLoginPage(navigationStore);
            communication1 = new DataCommunication();
            // mWindow = window;
            CurrentEmployee = new RequesttoSignUP();
            communication1.Mess_Send += C1_Mess_Received;
            RegisterationCommand = new RelayCommand(Register);
            //AccessibilityCommand = new RelayCommand(LoginPage);

        }

        public ICommand RegisterationCommand { get; set; }

     //   public ICommand AccessibilityCommand { get; set; }
        public void C1_Mess_Received(object mess, string messType)
        {
            if (mess == "succefull")
            {

            }
            else
            {
                MessageBox.Show("Invalid User Name and Password");
            }


        }



        // secure string passed in from the view for user to logged into 
        public void Register()
        {
            string email = CurrentEmployee.Email;
            // var email = this.Email;
            // var password = this.Password;
            var password = CurrentEmployee.Password;



            // CommunicationLayer.DataCommunicate.DataReceived(currentEmployee);

            //CommunicationLayer.DataCommunication communication = new DataCommunication();
            communication1.DataSend<RequesttoSignUP>(CurrentEmployee, "Registration");



        }
    }
}

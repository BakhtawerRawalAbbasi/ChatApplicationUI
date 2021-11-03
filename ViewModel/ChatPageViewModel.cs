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
using System.Data.Entity.Core.Metadata.Edm;
using Chat_Application_Clients.Stores;

namespace Chat_Application_Clients.ViewModel
{

    public class ChatPageViewModel : BaseViewModel
    {
        private RequestToSendMess messageSend;
        private DataCommunication communication1;
        private SenderReceiverEmial senderreceiverEmail;
        ResponseOfHistoryMessages responseHistoryMessage;
        SenderNewMessage newMessage;
        User updateUserStatus;
        public string message;
        public string SenderUserName;
        private string userName;

        public DelegateCommand<object> ItemSelectionChanged { get; private set; }
        private ObservableCollection<User> userList;
        public ObservableCollection<User> UserList
        {
            get { return userList;  }
            set { userList = value; OnPropertyChanged("UserList"); }
        }

        private ObservableCollection<HistoryOfMessages> historyMessage;
        public ObservableCollection<HistoryOfMessages> HistoryMessage
        {
            get { return historyMessage; }
            set { historyMessage = value; OnPropertyChanged("HistoryMessage"); }
        }
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value; OnPropertyChanged("userName");
            }
        }

        public RequestToSendMess MessageSend
        {
            get { return messageSend; }
            set { messageSend = value; OnPropertyChanged("MessageSend"); }
        }
        
        private User currentEmployee;
        public User CurrentEmployee
        {
            get { return currentEmployee; }
            set { currentEmployee = value; OnPropertyChanged("CurrentEmployee"); }
        }

        public SenderReceiverEmial SenderReceiverEmailID
        {
            get { return senderreceiverEmail; }
            set { senderreceiverEmail = value; OnPropertyChanged("SenderReceiverEmailID"); }
        }
        public ChatPageViewModel()
        {
            UserList = new ObservableCollection<User>();
            HistoryMessage = new ObservableCollection<HistoryOfMessages>();

        }
        public ICommand SendCommand { get; set; }
        public ICommand LogoutCommand { get; set; }


        public void Send()
        {

            message = MessageSend.Message;
            MessageSend.Sender_Email_ID = RetreiveSenderEmail.Instance.SenderEmailID;
            MessageSend.Receiver_Email_id = SenderReceiverEmailID.ReceiverEmailID;
            //need changes for time...
            MessageSend.Messag_SendTime = DateTime.Now;
            MessageSend.SenderName = RetreiveSenderEmail.Instance.SenderName;
            communication1.DataSend<RequestToSendMess>(MessageSend, "Send Message Request");

        }

        public void Logout()
        {
            communication1.DataSend("Request for Logout");
            communication1.DataSend("Current User Login");
            Environment.Exit(0);

        }

        public ChatPageViewModel(ResponsetoListUser user)
        {

            UserList = new ObservableCollection<User>();
            HistoryMessage = new ObservableCollection<HistoryOfMessages>();
            for (int i = 0; i < user.userListResponse.Count; i++)
            {
               
                UserList.Add(user.userListResponse[i]);
            }
            communication1 = DataCommunication.Instance;
            ItemSelectionChanged = new DelegateCommand<object>((obj) => { OnItemSelectionChanged(obj); });
            SendCommand = new RelayCommand(Send);
            LogoutCommand = new RelayCommand(Logout);
            MessageSend = new RequestToSendMess();
            SenderReceiverEmailID = new SenderReceiverEmial();
            communication1.Mess_Send += C1_Mess_Received;
            communication1.DataSend("Update User Data");
        }
       
        public void C1_Mess_Received(object mess, string messType)
        {
            //SenderUserName = RetreiveSenderEmail.Instance.SenderName;
            if (messType == "History of message")
            {

                responseHistoryMessage = (ResponseOfHistoryMessages)mess;
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    HistoryMessage.Clear();
                });
                for (int i = 0; i < responseHistoryMessage.historyOfMessages.Count; i++)
                {
                    // ObservableCollection created on UI thread can only modify  from UI thread
                    // not from other threads to update objects created on UI thread from different thread,
                    // simply put the delegate on UI Dispatcher and that will do work  delegating it to UI thread.

                    App.Current.Dispatcher.Invoke((Action)delegate
                        {
                            HistoryMessage.Add(responseHistoryMessage.historyOfMessages[i]);
                        });

                }


            }

            else if (messType == "Message Receive Request")
            {
                newMessage = (SenderNewMessage)mess;
                MessageSend.Message = null;
                // ObservableCollection created on UI thread can only modify  from UI thread
                // not from other threads to update objects created on UI thread from different thread,
                // simply put the delegate on UI Dispatcher and that will do work  delegating it to UI thread.

                App.Current.Dispatcher.Invoke((Action)delegate
                    {
                        HistoryOfMessages historyOf = new HistoryOfMessages();
                        historyOf.SenderName = newMessage.SenderName;
                        historyOf.Messages = newMessage.Message;
                        historyOf.MessageSentTime = newMessage.MessageSendTime;
                        historyOf.SenderEmail = newMessage.SenderEmailID;
                        HistoryMessage.Add(historyOf);
                    });
                // 

            }
            else if (messType == "Update User Data")
            {

                updateUserStatus = (User)mess;

            }
            }
        private void OnItemSelectionChanged(object obj)
        {
            if(obj is User user)
            {
                string email = user.EmailID;
                SenderReceiverEmailID.ReceiverEmailID = email;
                SenderReceiverEmailID.SenderEmailID = RetreiveSenderEmail.Instance.SenderEmailID;
                UserName=user.UserName;
                communication1.DataSend<SenderReceiverEmial>(SenderReceiverEmailID, "History of message");
     
            }
        }
    }
}

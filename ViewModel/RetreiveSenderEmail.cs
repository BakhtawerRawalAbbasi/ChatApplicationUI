using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Application_Clients.ViewModel
{
   public class RetreiveSenderEmail : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private static RetreiveSenderEmail _instance;
        private string senderEmailID;
        private string senderName;

        public static RetreiveSenderEmail Instance => _instance ?? (_instance = new RetreiveSenderEmail());

        public string SenderEmailID
        {
            get => senderEmailID;
            set
            {
                senderEmailID = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SenderEmailID)));
            }
        }
        public string SenderName
        {
            get => senderName;
            set
            {
                senderName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SenderName)));
            }
        }

    }
}


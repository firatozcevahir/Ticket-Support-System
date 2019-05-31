using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSupport.ViewModels
{
    public class MainWindowViewModel:ViewModelBase
    {

        public MainWindowViewModel()
        {
            ShowNewTicketComm = new RelayCommand(ShowNewTicket);
            ShowUserLoginComm = new RelayCommand(ShowUserLogin);
        }
        private void ShowNewTicket()
        {
            Messenger.Default.Send(new NotificationMessage("ShowNewTicket"));
        }
        private void ShowUserLogin()
        {
            Messenger.Default.Send(new NotificationMessage("ShowUserLogin"));
        }
    }
}

using DataAccessLayer;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSupport.ViewModels
{
    public class TicketOperationsViewModel : ViewModelBase
    {
        #region Props
        private Models.Ticket selectedItem;
        public Models.Ticket SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        #endregion

        public TicketOperationsViewModel()
        {
            User = new Models.User();
            User = DataTransfer.TransferUser;
            ticketDataAccess = new TicketDataAccess();
            userDataAccess = new UserDataAccess();


            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            //Collections To Be Bound//

            SelectTicketList();
            MostTicketSolvedUsers = Mapper.Map<ObservableCollection<Models.MostTicketSolvedUser>>(userDataAccess.SelectMostTicketSolvedUsers());

            UpdateTicketSolved = new RelayCommand(UpdateTicket);
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if(msg.Notification == "RefreshData")
            {
                MostTicketSolvedUsers = Mapper.Map<ObservableCollection<Models.MostTicketSolvedUser>>(userDataAccess.SelectMostTicketSolvedUsers());
                SelectTicketList();
            }
        }

        private void SelectTicketList()
        {
            ModelTicketList = Mapper.Map<ObservableCollection<Models.Ticket>>(ticketDataAccess.SelectAll());
        }

        private void UpdateTicket()
        {

            var result = ticketDataAccess.UpdateTicketSolved(Mapper.Map<DataAccessLayer.User>(User), Mapper.Map<DataAccessLayer.Ticket>(SelectedItem));


            if (result)
            {
               
                SelectedItem.Solved = true;
                SelectedItem.SolvedBy = User.UserName;
            }
            else
                Messenger.Default.Send(new NotificationMessage("FailedUpdatingTicket"));
        }

    }
}

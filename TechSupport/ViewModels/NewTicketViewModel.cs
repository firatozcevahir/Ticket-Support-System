using AutoMapper;
using DataAccessLayer;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSupport.ViewModels
{
    public class NewTicketViewModel:ViewModelBase
    {

        public NewTicketViewModel()
        {
            SaveNewTicket = new RelayCommand(SaveTicket);
            Ticket = new Models.Ticket();
            DataTicket = new DataAccessLayer.Ticket();
            ticketDataAccess = new TicketDataAccess();            
        }

        private void SaveTicket()
        {
            DataTicket = Mapper.Map<DataAccessLayer.Ticket>(Ticket);
            //DataTicket = DataTransfer.ModelToEntityTicket(Ticket);
            OperationResult = ticketDataAccess.InsertNew(DataTicket);

            if (OperationResult)
            {
                WarningWord = "NewTicketIsAdded";
            }
            else
                WarningWord = "FailedSavingTicket";

            Messenger.Default.Send(new NotificationMessage(WarningWord));
        }
    }
}

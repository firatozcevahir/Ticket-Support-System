using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface ITicketDataAccess
    {
        bool UpdateTicketSolved(DataAccessLayer.User userItem,DataAccessLayer.Ticket ticketItem);

        ObservableCollection<DataAccessLayer.Ticket> SelectMostTicketSolvedUsers();
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TicketDataAccess : IDataAccessRepo<Ticket>, ITicketDataAccess
    {

        public bool InsertNew(Ticket item)
        {
            using (var db = new TechnicalSupportEntities())
            {
                item.Solved = false;
                item.TimeCreated = DateTime.Now;

                db.Ticket.Add(item);

                if (db.SaveChanges() > 0)
                    return true;
                else
                    return false;
            }
        }

        public ObservableCollection<DataAccessLayer.Ticket> SelectAll()
        {
            using (var db = new TechnicalSupportEntities())
            {
                var Tickets = from tickets in db.Ticket
                              select tickets;

                return new ObservableCollection<Ticket>(Tickets);
            }

        }


        public Ticket SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Ticket> SelectMostTicketSolvedUsers()
        {
            using (var db = new TechnicalSupportEntities())
            {
                return null;
            }
        }

        public bool UpdateTicketSolved(User userItem, Ticket ticketItem)
        {
            using (var db = new TechnicalSupportEntities())
            {
                try
                {
                    var SelectedTicket = (from ticket in db.Ticket
                                          where ticket.TicketID == ticketItem.TicketID
                                          select ticket).FirstOrDefault();

                    SelectedTicket.Solved = true;
                    SelectedTicket.SolvedBy = userItem.UserName;

                    if (db.SaveChanges() > 0)
                        return true;
                    else
                        return false;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserDataAccess : IDataAccessRepo<User>, IUserDataAccess
    {

        public bool InsertNew(User item)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<DataAccessLayer.User> SelectAll()
        {
            throw new NotImplementedException();
        }

        public User SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public User UserAuthentication(User item)
        {
            using (var db = new TechnicalSupportEntities())
            {
                var result = db.User.Where(x => x.UserName == item.UserName && x.UserPassword == item.UserPassword).FirstOrDefault();

                if (result != null)
                {
                    return result;
                }
                else
                    return null;
            }
        }

        public ObservableCollection<DataAccessLayer.Models.MostTicketSolvedUser> SelectMostTicketSolvedUsers()
        {
            var returnCollelction = new ObservableCollection<DataAccessLayer.Models.MostTicketSolvedUser>();
            using (var db = new TechnicalSupportEntities())
            {
                var users = from ticket in db.Ticket
                            where ticket.Solved == true && ticket.SolvedBy != null
                            group ticket by ticket.SolvedBy into usr
                            orderby usr.Count() descending
                            select new { UserName = usr.Key, TotalTickets = usr.Count() };



                foreach (var item in users)
                {
                    returnCollelction.Add(new Models.MostTicketSolvedUser()
                    {
                        UserName = item.UserName,
                        TotalSolvedTickets = item.TotalTickets
                    });
                }

                return returnCollelction;

            }
        }
    }
}

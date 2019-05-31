using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IUserDataAccess
    {
        User UserAuthentication(User item);
        ObservableCollection<DataAccessLayer.Models.MostTicketSolvedUser> SelectMostTicketSolvedUsers();
    }
}

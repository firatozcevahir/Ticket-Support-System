using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IDataAccessRepo<T>
    {
        bool InsertNew(T item);
        ObservableCollection<T> SelectAll();
        T SelectById(int id);
    }
}

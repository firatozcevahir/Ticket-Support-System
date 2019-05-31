using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSupport.Models
{
    public class User : BindingBase
    {
        #region Props
        public int UserID { get; set; }

        private string userName;
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        private string userPassword;
        public string UserPassword
        {
            get
            {
                return userPassword;
            }
            set
            {
                userPassword = value;
                OnPropertyChanged("UserPassword");
            }
        }
        #endregion

    }
}

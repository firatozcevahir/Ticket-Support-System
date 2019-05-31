using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSupport.Models
{
    public class Ticket : BindingBase
    {
        #region Props
        public int TicketID { get; set; }

        private string subject;
        public string Subject
        {
            get
            {
                return subject;
            }
            set
            {
                subject = value;
                OnPropertyChanged("Subject");
            }
        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        private string customerName;
        public string CustomerName
        {
            get
            {
                return customerName;
            }
            set
            {
                customerName = value;
                OnPropertyChanged("CustomerName");
            }
        }

        private string productName;
        public string ProductName
        {
            get
            {
                return productName;
            }
            set
            {
                productName = value;
                OnPropertyChanged("ProductName");
            }
        }

        private string solvedBy;
        public string SolvedBy
        {
            get
            {
                return solvedBy;
            }
            set
            {
                solvedBy = value;
                OnPropertyChanged("SolvedBy");
            }
        }

        private bool solved;
        public bool Solved
        {
            get
            {
                return solved;
            }
            set
            {
                solved = value;
                OnPropertyChanged("Solved");
            }
        }

        private DateTime timeCreated;
        public DateTime TimeCreated
        {
            get
            {
                return timeCreated;
            }
            set
            {
                timeCreated = value;
                OnPropertyChanged("TimeCreated");
            }
        }
        #endregion        
    }
}

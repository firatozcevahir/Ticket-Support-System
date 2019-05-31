using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GalaSoft.MvvmLight.Command;
namespace TechSupport.ViewModels
{
    public class ViewModelBase : Models.BindingBase
    {
        private static bool IsInitialized = false;
        public ViewModelBase()
        {
            if (!IsInitialized)
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<DataAccessLayer.Ticket, Models.Ticket>();
                    cfg.CreateMap<DataAccessLayer.User, Models.User>();
                    cfg.CreateMap<DataAccessLayer.Models.MostTicketSolvedUser, Models.MostTicketSolvedUser>();
                });
            }
            IsInitialized = true;
        }


        #region Commands
        public RelayCommand ShowNewTicketComm { get; set; }
        public RelayCommand ShowUserLoginComm { get; set; }
        public RelayCommand SaveNewTicket { get; set; }
        public RelayCommand UpdateTicketSolved { get; set; }
        public RelayCommand CheckUserAuthentication { get; set; }
        #endregion

        #region Fields
        protected DataAccessLayer.TicketDataAccess ticketDataAccess;
        protected DataAccessLayer.Ticket DataTicket;
        protected DataAccessLayer.User DataUser;
        protected DataAccessLayer.UserDataAccess userDataAccess;
        protected bool OperationResult = false;
        protected string WarningWord = "";
        #endregion

        #region Props
        public ObservableCollection<Models.MostTicketSolvedUser> mostTicketSolvedUsers;
        public ObservableCollection<Models.MostTicketSolvedUser> MostTicketSolvedUsers
        {
            get
            {
                return mostTicketSolvedUsers;
            }
            set
            {
                mostTicketSolvedUsers = value;
                OnPropertyChanged("MostTicketSolvedUsers");
            }
        }

        private ObservableCollection<Models.Ticket> modelTicketList;
        public ObservableCollection<Models.Ticket> ModelTicketList
        {
            get
            {
                return modelTicketList;
            }
            set
            {
                modelTicketList = value;
                OnPropertyChanged("ModelTicketList");
            }
        }

        //public ObservableCollection<object> MostTicketSolvedUsers { get; set; }

        public Models.Ticket Ticket { get; set; }
        public Models.User User { get; set; }
        #endregion
    }

}

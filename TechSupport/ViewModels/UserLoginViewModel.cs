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
    public class UserLoginViewModel:ViewModelBase
    {
        public UserLoginViewModel()
        {
            User = new Models.User();
            DataUser = new DataAccessLayer.User();
            CheckUserAuthentication = new RelayCommand(UserAuthentication);
            userDataAccess = new UserDataAccess();
        }
        private void UserAuthentication()
        {
            DataUser = Mapper.Map<DataAccessLayer.User>(User);
            //DataUser = DataTransfer.ModelToEntityUser(User);

            if (userDataAccess.UserAuthentication(DataUser) != null)
            {
                User = Mapper.Map<Models.User>(userDataAccess.UserAuthentication(DataUser));
                WarningWord = "ShowTicketOperations";
            }
            else
                WarningWord = "FailedUserAuthentication";

            DataTransfer.TransferUser = User;
            Messenger.Default.Send(new NotificationMessage(WarningWord));
        }
    }
}

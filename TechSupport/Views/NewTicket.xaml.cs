using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TechSupport.Views
{
    /// <summary>
    /// Interaction logic for NewTicket.xaml
    /// </summary>
    public partial class NewTicket : Window
    {
        public NewTicket()
        {
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "NewTicketIsAdded")
                MessageBox.Show("Kayıt Başarıyla Tamamlandı");
            else if (msg.Notification == "FailedSavingTicket")
                MessageBox.Show("Kaydedilirken Bir Hata Oluştu");
        }
    }
}

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
using System.Windows.Threading;
using TechSupport.ViewModels;

namespace TechSupport.Views
{
    /// <summary>
    /// Interaction logic for TicketOperations.xaml
    /// </summary>
    public partial class TicketOperations : Window
    {

        public TicketOperations()
        {
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            TimerCreator();
        }

        private void TimerCreator()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 5)
            };
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Start();            
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            Messenger.Default.Send(new NotificationMessage("RefreshData"));
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "FailedUpdatingTicket")
            {
                MessageBox.Show("Ticketi Güncellerken Bir Hata Oluştu");
            }
        }
    }
}

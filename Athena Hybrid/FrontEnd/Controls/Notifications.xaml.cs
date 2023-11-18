using Athena_Hybrid.FrontEnd.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Athena_Hybrid.FrontEnd.Controls
{
    /// <summary>
    /// Interaktionslogik für Notifications.xaml
    /// </summary>
    public partial class Notifications : UserControl
    {
        string title1;
        string description1;
        public Notifications(string title, string description)
        {
            title1 = title;
            description1 = description;
            InitializeComponent();
        }

        bool bWait = true;
        private async void userControl_Loaded(object sender, RoutedEventArgs e)
        {
            _ = Task.Run(() =>
            {
                _ = Dispatcher.Invoke(async () =>
                {
                    notificationHeader.Content = title1;
                    notificationContent.Text = description1;
                    Storyboard s = (Storyboard)TryFindResource("ShowNotification");
                    s.Begin();
                    await Task.Delay(4000);
                    if (bWait)
                    {
                        Storyboard s1 = (Storyboard)TryFindResource("HideNotifications");
                        s1.Begin();
                    }
                });
            });
        }

        private void SymbolIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Storyboard s1 = (Storyboard)TryFindResource("HideNotifications");
            s1.Begin();
            bWait = false;
        }
    }
}

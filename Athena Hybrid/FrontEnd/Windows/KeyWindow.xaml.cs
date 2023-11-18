using Athena_Hybrid.BackEnd.Services;
using Athena_Hybrid.FrontEnd.Controls;
using Athena_Hybrid.Properties;
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
using Wpf.Ui.Controls;

namespace Athena_Hybrid.FrontEnd.Windows
{
    /// <summary>
    /// Interaktionslogik für KeyWindow.xaml
    /// </summary>
    public partial class KeyWindow : UiWindow
    {
        public KeyWindow()
        {
            InitializeComponent();
        }

        private async void ContinueBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var DiscordData = await HostingService.DiscordData(Settings.Default.DiscordId);
                if (DiscordData.isPremium)
                {
                    Notifications notification = new Notifications("Success", "You will be redirected in 2 Seconds!");
                    LogService.Write("Logged in as Athena+");
                    notificationContainer.Children.Add(notification);
                    await Task.Delay(2000);
                    ConfigService.isPremium = true;
                    ConfigService.bUsingKey = false;
                    ConfigService.key = "";
                    ConfigService.SaveConfig(ConfigService.ConfigItem.isPremium, ConfigService.ConfigItem.usingKey, ConfigService.ConfigItem.key);
                    this.Hide();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                }
                else
                {
                    ConfigService.isPremium = false;
                    ConfigService.bUsingKey = true;
                    ConfigService.key = "key";
                    ConfigService.SaveConfig(ConfigService.ConfigItem.isPremium, ConfigService.ConfigItem.usingKey, ConfigService.ConfigItem.key);
                }
            } catch (Exception ex) {
                LogService.Write($"There was an error while continueing.\n{ex.Message}", LogLevel.Fatal);
            }
        }

        private async void GetKeyBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private async Task showNotification(string title, string description)
        {
            Notifications notification = new Notifications(title, description);
            notificationContainer.Children.Add(notification);
            await Task.Delay(5000);
            notificationContainer.Children.Clear();
        }
    }
}

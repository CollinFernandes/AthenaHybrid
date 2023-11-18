using AdonisUI.Controls;
using Athena_Hybrid.BackEnd;
using Athena_Hybrid.BackEnd.Services;
using Athena_Hybrid.FrontEnd.Controls;
using Athena_Hybrid.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;
using Wpf.Ui.Extensions;
using MessageBox = Wpf.Ui.Controls.MessageBox;

namespace Athena_Hybrid.FrontEnd.Pages.Pages
{
    /// <summary>
    /// Interaktionslogik für SettingsMainPage.xaml
    /// </summary>
    public partial class SettingsMainPage : Page
    {
        public SettingsMainPage()
        {
            InitializeComponent();
            try
            {
                Task.Run(() => {
                    Dispatcher.Invoke(() => {
                        if (!Settings.Default.bIsLoggedIn)
                        {
                            SwitchAccount.IsEnabled = false;
                            LogOutAccount.IsEnabled = false;
                        }
                        else
                        {
                            SwitchAccount.IsEnabled = true;
                            LogOutAccount.IsEnabled = true;
                        }
                    });
                });
            } catch (Exception ex)
            {
                LogService.Write($"There was an error while initializing the page.\n{ex.Message}", LogLevel.Fatal);
            }

        }

        private void SymbolIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox messageBox = new MessageBox();
            messageBox.Show("Full Anticheat Bypass", "this means that you can't be banned for athena hybrid but you\ncan't use ingame for it! if you don't want to be banned,\nactivate this.");
            messageBox.ButtonLeftClick += async delegate { messageBox.Hide(); };
            messageBox.ButtonLeftName = "Ok";
            messageBox.ButtonRightName = "Ok";
            messageBox.ButtonRightClick += async delegate { messageBox.Hide(); };
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Run(() => {
                Dispatcher.Invoke(async () => {
                    var config = await ConfigService.GetConfig();
                    if (config.FortniteLocation != null)
                    {
                        TextBoxPath.Text = config.FortniteLocation;
                    }
                    if (!Settings.Default.bIsLoggedIn)
                    {
                        SwitchAccount.IsEnabled = false;
                        LogOutAccount.IsEnabled = false;
                    }
                    else
                    {
                        SwitchAccount.IsEnabled = true;
                        LogOutAccount.IsEnabled = true;
                    }
                });
            });
        }

        private async void SwitchAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string token;
                FortniteAuthService auth = new FortniteAuthService();
                string f = await auth.DeviceAuthorization(auth.GetDeviceCode());
                auth.GetDeviceAuths(f);
                token = auth.GetToken();
                Settings.Default.bIsLoggedIn = true;
                Settings.Default.Save();
                LogOutAccount.IsEnabled = true;
                SwitchAccount.IsEnabled = true;
                await showNotification("Logged In", $"You successfully logged in as {Settings.Default.FnUsername}");
            } catch (Exception ex)
            {
                LogService.Write($"There was an error while switchting your account.\n{ex.Message}", LogLevel.Fatal);
            }
        }

        private async void LogOutAccount_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.bIsLoggedIn = false;
            Settings.Default.FnUsername = null;
            Settings.Default.FnPath = null;
            Settings.Default.deviceid = null;
            Settings.Default.secret = null;
            Settings.Default.epicId = null;
            Settings.Default.Save();
            LogOutAccount.IsEnabled = false;
            SwitchAccount.IsEnabled = false;
            await showNotification("Logged In", $"You successfully logged out!");
        }

        private async Task showNotification(string title, string description)
        {
            Notifications notification = new Notifications(title, description);
            notificationContainer.Children.Add(notification);
            await Task.Delay(5000);
            notificationContainer.Children.Clear();
        }

        private void CloseFortnite_Click(object sender, RoutedEventArgs e)
        {
            LogService.Write($"killing fortnite processes...");
            List<string> processes = new List<string> {
                "FortniteClient-Win64-Shipping_EAC",
                "FortniteClient-Win64-Shipping_BE",
                "FortniteClient-Win64-Shipping",
                "FortniteLauncher",
                "EpicGamesLauncher",
                "BEservice"
            };
            foreach (var process in processes)
            {
                var processes1 = Process.GetProcessesByName(process);
                foreach (var process1 in processes1)
                {
                    process1.Kill();
                    LogService.Write($"killed process {process1.ProcessName}");
                }
            }
            Process.GetProcessesByName("FortniteClient-Win64-Shipping_EAC.exe");
        }

        private void VerifyFortnite_Click(object sender, RoutedEventArgs e)
        {
            var Proc = new ProcessStartInfo();
            Proc.CreateNoWindow = true;
            Proc.FileName = "cmd.exe";
            Proc.Arguments = "/C start com.epicgames.launcher://apps/Fortnite?action=verify";
            Process.Start(Proc);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            switch ((sender as  CheckBox).Content)
            {
                case "Ingame":
                    Settings.Default.bIsIngame = true;
                    Settings.Default.Save();
                    break;
                case "Dev Inventory":
                    Settings.Default.bIsDevInventory = true;
                    Settings.Default.Save();
                    break;
                case "Full Anticheat Bypass":
                    Settings.Default.bFACB = true;
                    Settings.Default.Save();
                    break;
            }
            LogService.Write($"activated {(sender as CheckBox).Content}");
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            switch ((sender as CheckBox).Content)
            {
                case "Ingame":
                    Settings.Default.bIsIngame = false;
                    Settings.Default.Save();
                    break;
                case "Dev Inventory":
                    Settings.Default.bIsDevInventory = false;
                    Settings.Default.Save();
                    break;
                case "Full Anticheat Bypass":
                    Settings.Default.bFACB = false;
                    Settings.Default.Save();
                    break;
            }
            LogService.Write($"deactivated {(sender as CheckBox).Content}");
        }

        private async void DeleteCache_Click(object sender, RoutedEventArgs e)
        {
            LogService.Write("successfully deleted the Cache!", LogLevel.Success);
            LogService.Write("closing the launcher in 3 seconds!", LogLevel.Warning);
            await showNotification("Success", "Closing the Launcher in 3 Seconds.");
            File.Delete(Config.ConfigFile);
            File.Delete(Config.publicBackgroundsFile);
            await Task.Delay(3000);
            Environment.Exit(0);
        }
    }
}

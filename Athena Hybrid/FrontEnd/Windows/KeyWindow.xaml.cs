using Athena_Hybrid.BackEnd;
using Athena_Hybrid.BackEnd.Models;
using Athena_Hybrid.BackEnd.Services;
using Athena_Hybrid.FrontEnd.Controls;
using Athena_Hybrid.Properties;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
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
        private bool _disposed;
        public KeyWindow()
        {
            InitializeComponent();
            Storyboard s1 = (Storyboard)TryFindResource("windowIn");
            s1.Begin();
        }

        private async void ContinueBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var DiscordData = await HostingService.DiscordData(Settings.Default.DiscordId);
                if (DiscordData.isPremium)
                {
                    Notifications notification = new Notifications(Config.languageData["Translations"][Settings.Default.Language]["Success"].ToString(), Config.languageData["Translations"][Settings.Default.Language]["Redirect"].ToString());
                    LogService.Write("Logged in as Athena+");
                    notificationContainer.Children.Add(notification);
                    _disposed = true;
                    await Task.Delay(2000);
                    ConfigService.isPremium = true;
                    ConfigService.bUsingKey = false;
                    ConfigService.key = "";
                    ConfigService.SaveConfig(ConfigService.ConfigItem.isPremium, ConfigService.ConfigItem.usingKey, ConfigService.ConfigItem.key);
                    this.Hide();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                }
                if (!_disposed)
                {
                    if (KeyBox.Text != string.Empty)
                    {
                        using (HttpClient client = new HttpClient())
                        {
                            client.Timeout = TimeSpan.FromSeconds(5.0);
                            string requestUri = $"https://bstlar.com/keys/validate/{KeyBox.Text}";
                            client.DefaultRequestHeaders.Add("bstk", "Fw3kjPpKN7KAQwJQfEjNoN69a78cXhkW0jyS");
                            var response = Convert.ToBoolean((object)JObject.Parse(await client.GetStringAsync(requestUri))["valid"]);
                            if (response)
                            {
                                ConfigService.isPremium = false;
                                ConfigService.bUsingKey = true;
                                ConfigService.key = KeyBox.Text;
                                await ConfigService.SaveConfig(ConfigService.ConfigItem.isPremium, ConfigService.ConfigItem.usingKey, ConfigService.ConfigItem.key);
                                Notifications notification = new Notifications(LanguageService.getTranslation("Success"), LanguageService.getTranslation("KeyUsed"));
                                LogService.Write("successfully used a key!");
                                notificationContainer.Children.Add(notification);
                                await Task.Delay(2000);
                                this.Hide();
                                MainWindow mainWindow = new MainWindow();
                                mainWindow.Show();
                            }
                            else
                            {
                                Notifications notification = new Notifications(LanguageService.getTranslation("Error"), LanguageService.getTranslation("KeyNoValid"));
                                LogService.Write("tried to use invalid key", LogLevel.Warning);
                                notificationContainer.Children.Add(notification);
                            }
                        }
                    }
                    else
                    {
                        Notifications notification = new Notifications(LanguageService.getTranslation("Error"), LanguageService.getTranslation("EnterKey"));
                        LogService.Write("no Key entered!", LogLevel.Warning);
                        notificationContainer.Children.Add(notification);
                    }
                }
            } catch (Exception ex) {
                LogService.Write($"There was an error while continueing.\n{ex.Message}", LogLevel.Fatal);
            }
        }

        private async void GetKeyBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                CreateNoWindow = true,
                FileName = "cmd.exe",
                Arguments = "/C start https://bstlar.com/A/athenahybridkey"
            });
        }

        private async Task showNotification(string title, string description)
        {
            Notifications notification = new Notifications(title, description);
            notificationContainer.Children.Add(notification);
            await Task.Delay(5000);
            notificationContainer.Children.Clear();
        }

        private async void UiWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await setLanguage();
                var config = await ConfigService.GetConfig();
                if (config.usingKey)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.Timeout = TimeSpan.FromSeconds(5.0);
                        string requestUri = $"https://bstlar.com/keys/validate/{config.key}";
                        client.DefaultRequestHeaders.Add("bstk", "Fw3kjPpKN7KAQwJQfEjNoN69a78cXhkW0jyS");
                        var response = Convert.ToBoolean((object)JObject.Parse(await client.GetStringAsync(requestUri))["valid"]);
                        if (config.usingKey)
                        {
                            if (response)
                            {
                                KeyBox.Text = config.key;
                            }
                            else
                            {
                                await showNotification(Config.languageData["Translations"][Settings.Default.Language]["Error"].ToString(), Config.languageData["Translations"][Settings.Default.Language]["KeyExpired"].ToString());
                            }
                        }
                    }
                }
            } catch(Exception ex)
            {
                LogService.Write($"There was an error while loading the window.\n{ex.Message}", LogLevel.Fatal);
            }

        }

        private async Task setLanguage()
        {
            _ = this.Dispatcher.Invoke(async () =>
            {
                label.Content = Config.languageData["Translations"][Settings.Default.Language]["KeyWindow"];
                label1.Content = Config.languageData["Translations"][Settings.Default.Language]["KeyWindowDescription"];
                ContinueBtn.Content = Config.languageData["Translations"][Settings.Default.Language]["Continue"];
                GetKeyBtn.Content = Config.languageData["Translations"][Settings.Default.Language]["GetKey"];
            });
        }
    }
}

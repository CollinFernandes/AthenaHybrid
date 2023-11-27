using Athena_Hybrid.BackEnd;
using Athena_Hybrid.BackEnd.Models;
using Athena_Hybrid.BackEnd.Services;
using Athena_Hybrid.BackEnd.Utils;
using Athena_Hybrid.FrontEnd.Controls;
using Athena_Hybrid.Properties;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Athena_Hybrid.FrontEnd.Pages
{
    /// <summary>
    /// Interaktionslogik für LaunchPage.xaml
    /// </summary>
    public partial class LaunchPage : Page
    {
        public LaunchPage()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Settings.Default.bIsLoggedIn )
                {
                    PrimaryButton.Content = "Launch";
                } else
                {
                    PrimaryButton.Content = "Login";
                }
            } catch (Exception ex)
            {
                LogService.Write($"there was an error while loading the page.\n{ex.Message}", LogLevel.Fatal);
            }
        }

        private async void PrimaryButton_Click(object sender, RoutedEventArgs e)
        {
            FortniteAuthService auth = new FortniteAuthService();
            switch ((sender as Button).Content)
            {
                case "Login":
                    #region Login
                    string token;
                    string f = await auth.DeviceAuthorization(auth.GetDeviceCode());
                    auth.GetDeviceAuths(f);
                    token = auth.GetToken();
                    Settings.Default.bIsLoggedIn = true;
                    Settings.Default.Save();
                    await showNotification("Logged In", $"You successfully logged in as {Settings.Default.FnUsername}");
                    PrimaryButton.Content = "Launch";
                    #endregion
                    break;
                case "Launch":
                    #region Launch Game
                    await showNotification("Launching", $"Launching your Game!");
                    LaunchUtils.launchGame();
                    #endregion
                    break;
            }
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

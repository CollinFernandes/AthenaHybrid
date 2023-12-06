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
using System.Windows.Media.Animation;
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
                Storyboard s4 = (Storyboard)TryFindResource("launchGridIn");
                s4.Begin();
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
                    launchGame();
                    await showNotification("Launching", $"Launching your Game!");
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

        private async void animLabel(string text)
        {
            Storyboard labelAnim = (Storyboard)TryFindResource("labelAnim");
            labelAnim.Begin();
            await Task.Delay(400);
            loadingLabel.Text = text;
        }

        public async void launchGame()
        {
            Storyboard s1 = (Storyboard)TryFindResource("launchGridOut");
            s1.Begin();
            await Task.Delay(600);
            launchGrid.Visibility = Visibility.Hidden;
            loadingGrid.Visibility = Visibility.Visible;
            Storyboard s2 = (Storyboard)TryFindResource("loadingGridIn");
            s2.Begin();
            await Task.Delay(700);
            animLabel("downloading Assets...");
            await Task.Delay(1000);
            FilesModelResponse filesResponse = JsonConvert.DeserializeObject<FilesModelResponse>(await new HttpClient().GetStringAsync(Config.filesAPI));
            var config = await ConfigService.GetConfig();
            string Win64 = config.FortniteLocation.Replace("/", "\\") + "\\FortniteGame\\Binaries\\Win64";

            Directory.SetCurrentDirectory(Win64);

            await LaunchUtils.downloadFiles();
            animLabel("killing Fortnite...");
            await Task.Delay(1000);

            LaunchUtils.killFortnite();
            animLabel("copying Files...");
            await Task.Delay(1000);

            if (Settings.Default.bFACB)
            {
                if (File.Exists(Path.Combine(Win64 + "\\FortniteClient-Win64-Shipping_BE.exe")))
                    File.Delete(Path.Combine(Win64 + "\\FortniteClient-Win64-Shipping_BE.exe"));
                if (File.Exists(Path.Combine(Win64 + "\\FortniteClient-Win64-Shipping_EAC.exe")))
                    File.Delete(Path.Combine(Win64 + "\\FortniteClient-Win64-Shipping_EAC.exe"));
                await Task.Delay(500);
                File.Copy(Path.Combine(Config.FilesDirectory, filesResponse.files[3].fileName), Win64 + "\\FortniteClient-Win64-Shipping_BE.exe");
                File.Copy(Path.Combine(Config.FilesDirectory, filesResponse.files[3].fileName), Win64 + "\\FortniteClient-Win64-Shipping_EAC.exe");
            }

            if (Settings.Default.bIsDevInventory)
            {
                animLabel("replacing dev Inventory...");
                await Task.Delay(1000);
                if (filesResponse.DevInventory)
                {
                    ReplaceBytes.ReplaceHexInFile(
                        config.FortniteLocation.Replace("/", "\\") + $"\\FortniteGame\\Content\\Paks\\{filesResponse.DevPak}",
                        filesResponse.DevSearch,
                        filesResponse.DevReplace);
                }
                else
                    LogService.Write("couldn't replace the dev inventory because its deactivated.");
            }

            animLabel("launching Game...");
            await Task.Delay(1000);
            FortniteAuthService fortniteAuth = new FortniteAuthService();

            string exchangeCode = await fortniteAuth.GetExchange(fortniteAuth.GetToken());
            string calderaToken = await FortniteAuthService.GenCaldera();

            string fnlArgs = $"-obfuscationid=oxvLAnsonx2C8fFpVUi4Dqrwk9U-Yw -AUTH_LOGIN=unused -AUTH_PASSWORD={exchangeCode} -AUTH_TYPE=exchangecode -epicapp=Fortnite -epicenv=Prod -EpicPortal -steamimportavailable -epicusername={Settings.Default.FnUsername} -epicuserid=Settings.Default.epicId -epiclocale=en -epicsandboxid=fn -forceeac";
            string args = $"-obfuscationid=oxvLAnsonx2C8fFpVUi4Dqrwk9U-Yw -AUTH_LOGIN=unused -AUTH_PASSWORD={exchangeCode} -AUTH_TYPE=exchangecode -epicapp=Fortnite -epicenv=Prod -EpicPortal -steamimportavailable -epicusername= -epicuserid={Settings.Default.epicId} -epiclocale=en -epicsandboxid=fn -nobe -noeac -fromfl=eac_kamu -caldera={calderaToken}";

            Process FortniteLauncher = Process.Start("FortniteLauncher.exe", fnlArgs);
            FortniteLauncher.Suspend();

            Process EasyAntiCheat = Process.Start("FortniteClient-Win64-Shipping_EAC.exe", args);
            EasyAntiCheat.Suspend();

            Process FortniteClient = Process.Start("FortniteClient-Win64-Shipping.exe", args);
            animLabel("waiting for game Input...");
            await Task.Delay(1000);
            while (true)
            {
                try
                {
                    FortniteClient.WaitForInputIdle();
                    break;
                }
                catch { }
            }
            animLabel("injecting...");
            await Task.Delay(1000);
            LaunchUtils.injectFile(filesResponse.files[0].fileName, FortniteClient);
            LaunchUtils.injectFile(filesResponse.files[4].fileName, EasyAntiCheat);

            animLabel("waiting for game to close!");
            await Task.Delay(1000);
            await FortniteClient.WaitForExitAsync();
            Storyboard s3 = (Storyboard)TryFindResource("loadingGridOut");
            s3.Begin();
            await Task.Delay(500);
            loadingGrid.Visibility = Visibility.Hidden;
            launchGrid.Visibility = Visibility.Visible;
            Storyboard s4 = (Storyboard)TryFindResource("launchGridIn");
            s4.Begin();
        }
    }
}

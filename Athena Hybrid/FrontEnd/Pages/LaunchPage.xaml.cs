using Athena_Hybrid.BackEnd;
using Athena_Hybrid.BackEnd.Services;
using Athena_Hybrid.BackEnd.Utils;
using Athena_Hybrid.FrontEnd.Controls;
using Athena_Hybrid.Properties;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
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
                    string temp = Path.GetTempPath();
                    await showNotification("Launching", $"Launching your Game!");
                    var config = await ConfigService.GetConfig();
                    if (Settings.Default.bIsDevInventory)
                    {
                        ReplaceBytes.ReplaceHexInFile(config.FortniteLocation + "\\FortniteGame\\Content\\Paks\\pakchunk20-WindowsClient.ucas",
                                                      Config.SearchHex,
                                                      Config.ReplaceBytes);
                    }
                    string w64 = config.FortniteLocation.Replace("/", "\\") + "\\FortniteGame\\Binaries\\Win64/";
                    WebClient web = new WebClient();
                    string DllPath = temp + "EasyAntiCheat_x32.dll";
                    string anticheat = "https://cdn.atomicfn.dev/anticheat/main";

                    web.DownloadFile(Config.UEUnlockerURL, temp + "cns.dll");
                    web.DownloadFile("https://cdn.atomicfn.dev/Suspend.dll", temp + "Suspend.dll");

                    web.DownloadFile("http://server.basicfx.cloud:1337/api/v1/injector", temp + "Inject.exe");
                    web.DownloadFile(Config.SSLURL, DllPath);
                    Directory.SetCurrentDirectory(w64);
                    String exchangecode = auth.GetExchange(auth.GetToken());
                    String calderaToken = await FortniteAuthService.GenCaldera();
                    String ArgsFNL = "-obfuscationid=oxvLAnsonx2C8fFpVUi4Dqrwk9U-Yw -AUTH_LOGIN=unused -AUTH_PASSWORD=" + exchangecode + " -AUTH_TYPE=exchangecode -epicapp=Fortnite -epicenv=Prod -EpicPortal -steamimportavailable -epicusername=" + Settings.Default.FnUsername + " -epicuserid=" + Settings.Default.epicId + " -epiclocale=en -epicsandboxid=fn -forceeac";
                    String Args = $"-obfuscationid=oxvLAnsonx2C8fFpVUi4Dqrwk9U-Yw -AUTH_LOGIN=unused -AUTH_PASSWORD={exchangecode} -AUTH_TYPE=exchangecode -epicapp=Fortnite -epicenv=Prod -EpicPortal -steamimportavailable -epicusername= -epicuserid={Settings.Default.epicId} -epiclocale=en -epicsandboxid=fn -nobe -noeac -fromfl=eac_kamu -caldera={calderaToken}";
                    Process FNL = Process.Start("FortniteLauncher.exe", ArgsFNL);
                    FNL.Suspend();
                    Process EAC = Process.Start("FortniteClient-Win64-Shipping_EAC.exe", Args);
                    EAC.Suspend();
                    Process perow = Process.Start("FortniteClient-Win64-Shipping.exe", Args);
                    //Process perow = GetFNProcess();
                    while (true)
                    {
                        try
                        {
                            perow.WaitForInputIdle();
                            break;
                        }
                        catch
                        {

                        }
                    }

                    new Process()
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            Arguments = $"\"{perow.Id}\" \"{Path.Combine(temp, "EasyAntiCheat_x32.dll")}\"",
                            CreateNoWindow = true,
                            UseShellExecute = false,
                            FileName = $"{Path.GetTempPath()}/Inject.exe"
                        }
                    }.Start();
                    new Process()
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            Arguments = $"\"{EAC.Id}\" \"{Path.Combine(temp, "Suspend.dll")}\"",
                            CreateNoWindow = true,
                            UseShellExecute = false,
                            FileName = $"{Path.GetTempPath()}/Injector.exe"
                        }
                    }.Start();
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

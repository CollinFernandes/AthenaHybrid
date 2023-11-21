using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.PortableExecutable;
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
using System.Windows.Navigation;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

namespace Athena_Installer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : UiWindow
    {
        public MainWindow()
        {
            Theme.GetSystemTheme();
            Accent.ApplySystemAccent();
            Task.Run(() => {
                Dispatcher.Invoke(() => {
                    headerasdasdas.Foreground = Accent.SystemAccentBrush;
                    symbolIcon.Foreground = Accent.SystemAccentBrush;
                    symbolIcon1.Foreground = Accent.SystemAccentBrush;
                });
            });
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            LANext.IsEnabled = true;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            LANext.IsEnabled = false;
        }

        private void UiWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Task.Run(async () => {
                _ = Dispatcher.Invoke(async () =>
                {
                    if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Athena Launcher\\Athena Hybrid.exe"))
                    {
                        installButton.IsEnabled = false;
                        installButton.Icon = Wpf.Ui.Common.SymbolRegular.Checkmark24;
                        uninstallButton.Visibility = Visibility.Hidden;
                    } else
                    {
                        installButton.Content = "Update Athena Hybrid";
                    }
                    await Task.Delay(200);
                    welcomeGrid.Visibility = Visibility.Visible;
                    Storyboard s = (Storyboard)TryFindResource("WelcomeBackIn");
                    s.Begin();
                    await Task.Delay(850);
                    Storyboard s1 = (Storyboard)TryFindResource("WelcomeBackOut");
                    s1.Begin();
                    await Task.Delay(700);
                    welcomeGrid.Visibility = Visibility.Hidden;
                    agreementGrid.Visibility = Visibility.Visible;
                    Storyboard s2 = (Storyboard)TryFindResource("AgreementIn");
                    s2.Begin();
                });
            });
        }

        private async void LANext_Click(object sender, RoutedEventArgs e)
        {
            Storyboard s2 = (Storyboard)TryFindResource("AgreementOut");
            s2.Begin();
            await Task.Delay(750);
            agreementGrid.Visibility = Visibility.Hidden;
            installGrid.Visibility = Visibility.Visible;
            Storyboard s1 = (Storyboard)TryFindResource("InstallIn");
            s1.Begin();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _ = Task.Run(async () =>
            {
                _ = Dispatcher.Invoke(async () =>
                {
                    installButton.IsEnabled = false;
                    installButton.Icon = Wpf.Ui.Common.SymbolRegular.Checkmark24;
                    uninstallButton.Icon = Wpf.Ui.Common.SymbolRegular.Delete24;
                    uninstallButton.IsEnabled = true;
                    if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Athena Launcher\\Athena Hybrid.exe"))
                    {
                        installButton.IsEnabled = false;
                        uninstallButton.IsEnabled = true;
                    }
                });
            });

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Task.Run(async () => {
                _ = Dispatcher.Invoke(async () =>
                {
                    installButton.IsEnabled = true;
                    installButton.Icon = Wpf.Ui.Common.SymbolRegular.ArrowDownload24;
                    uninstallButton.Icon = Wpf.Ui.Common.SymbolRegular.Checkmark24;
                    uninstallButton.IsEnabled = false;
                    if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Athena Launcher\\Athena Hybrid.exe"))
                    {
                        installButton.IsEnabled = false;
                        uninstallButton.IsEnabled = true;
                    }
                });
            });
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (installButton.IsEnabled == false)
            {
                WebClient webClient = new WebClient();
                webClient.OpenRead("https://cdn.discordapp.com/attachments/1051538904840413315/1175591656674836630/Athena_Hybrid.exe");
                Int64 bytes_total = Convert.ToInt64(webClient.ResponseHeaders["Content-Length"]);
                double megabytesTotal = ConvertBytesToMegabytes(bytes_total);
                downloadedLabel.Content = "0 mb/" + Math.Round(megabytesTotal, 2) + "mb";
                Storyboard s2 = (Storyboard)TryFindResource("InstallOut");
                s2.Begin();
                await Task.Delay(850);
                installGrid.Visibility = Visibility.Hidden;
                downloadingGrid.Visibility = Visibility.Visible;
                Storyboard s1 = (Storyboard)TryFindResource("DownloadingIn");
                s1.Begin();
            } else if (uninstallButton.IsEnabled == false)
            {
                string LocalAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string shortcutDir = AppData + "\\Microsoft\\Windows\\Start Menu\\Programs\\Athena";
                File.Delete(shortcutDir + "\\Athena Hybrid" + ".url");
                File.Delete(LocalAppData + "\\Athena Launcher\\Athena Hybrid.exe");
                Directory.Delete(LocalAppData + "\\Athena Launcher");
                installGrid.Visibility = Visibility.Hidden;
                afterDeleteGrid.Visibility = Visibility.Visible;
                Storyboard s2 = (Storyboard)TryFindResource("UninstallIn");
                s2.Begin();
            }
        }

        static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        static double ConvertKilobytesToMegabytes(long kilobytes)
        {
            return kilobytes / 1024f;
        }

        private async void StartDownload(object sender, RoutedEventArgs e)
        {
            switch ((sender as Wpf.Ui.Controls.Button).Content)
            {
                case "Start Installing.":
                    string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    string LocalAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

                    (sender as Wpf.Ui.Controls.Button).IsEnabled = false;
                    WebClient webClient = new WebClient();
                    webClient.OpenRead("https://cdn.discordapp.com/attachments/1051538904840413315/1175591656674836630/Athena_Hybrid.exe");
                    Int64 bytes_total = Convert.ToInt64(webClient.ResponseHeaders["Content-Length"]);
                    double megabytesTotal = ConvertBytesToMegabytes(bytes_total);
                    downloadedLabel.Content = "0 mb/" + Math.Round(megabytesTotal, 2) + "mb";
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    webClient.DownloadProgressChanged += async (object sender, DownloadProgressChangedEventArgs e) =>
                    {
                        double currentMegabytes = ConvertBytesToMegabytes(e.BytesReceived);
                        downloadedBar.Value = e.ProgressPercentage;
                        downloadedLabel.Content = Math.Round(currentMegabytes, 2) + "mb/" + Math.Round(megabytesTotal, 2) + "mb";
                        speedLabel.Content = string.Format("{0} mb/s", (e.BytesReceived / 1024.0 / 1024.0 / stopwatch.Elapsed.TotalSeconds).ToString("0.00"));
                    };
                    Directory.CreateDirectory(LocalAppData + "\\Athena Launcher");
                    webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/1051538904840413315/1175591656674836630/Athena_Hybrid.exe"), LocalAppData + "\\Athena Launcher\\Athena Hybrid.exe");
                    webClient.DownloadFileCompleted += async (object sender1, AsyncCompletedEventArgs e) =>
                    {
                        _ = Task.Run(async () =>
                        {
                            _ = Dispatcher.Invoke(async () =>
                            {
                                downloadedLabel.Content = "Download Done.";
                                string shortcutDir = AppData + "\\Microsoft\\Windows\\Start Menu\\Programs\\Athena";
                                Directory.CreateDirectory(shortcutDir);
                                using (StreamWriter writer = new StreamWriter(shortcutDir + "\\Athena Hybrid" + ".url"))
                                {
                                    string app = LocalAppData + "\\Athena Launcher\\Athena Hybrid.exe";
                                    writer.WriteLine("[InternetShortcut]");
                                    writer.WriteLine("URL=file:///" + app);
                                    writer.WriteLine("IconIndex=0");
                                    string icon = app.Replace('\\', '/');
                                    writer.WriteLine("IconFile=" + icon);
                                }
                                (sender as Wpf.Ui.Controls.Button).IsEnabled = true;
                                (sender as Wpf.Ui.Controls.Button).Content = "Next";
                            });
                        });
                    };
                    break;
                case "Next":
                    Storyboard s2 = (Storyboard)TryFindResource("DownloadingOut");
                    s2.Begin();
                    await Task.Delay(850);
                    downloadingGrid.Visibility = Visibility.Hidden;
                    afterDownloadGrid.Visibility = Visibility.Visible;
                    Storyboard s3 = (Storyboard)TryFindResource("afterDownloadIn");
                    s3.Begin();
                    break;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private async void button2_Click(object sender, RoutedEventArgs e)
        {
            string LocalAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            Process.Start(LocalAppData + "\\Athena Launcher\\Athena Hybrid.exe");
            await Task.Delay(1500);
            Environment.Exit(0);
        }
    }
}

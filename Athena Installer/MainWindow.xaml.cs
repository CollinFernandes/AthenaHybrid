﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
using System.Windows.Shapes;
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
                });
            });
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
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
        }

        static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        static double ConvertKilobytesToMegabytes(long kilobytes)
        {
            return kilobytes / 1024f;
        }

        private void StartDownload(object sender, RoutedEventArgs e)
        {
            switch ((sender as Wpf.Ui.Controls.Button).Content)
            {
                case "Start Installing.":
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
                    webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/1051538904840413315/1175591656674836630/Athena_Hybrid.exe"), "discord.exe");
                    webClient.DownloadFileCompleted += async (object sender1, AsyncCompletedEventArgs e) =>
                    {
                        _ = Task.Run(async () =>
                        {
                            _ = Dispatcher.Invoke(async () =>
                            {
                                (sender as Wpf.Ui.Controls.Button).IsEnabled = true;
                                (sender as Wpf.Ui.Controls.Button).Content = "Next";
                            });
                        });
                    };
                    break;
                case "Next":

                    break;
            }
        }
    }
}
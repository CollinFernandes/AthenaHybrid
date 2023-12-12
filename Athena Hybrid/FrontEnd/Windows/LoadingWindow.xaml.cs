using Athena_Hybrid.BackEnd;
using Athena_Hybrid.BackEnd.Services;
using Athena_Hybrid.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
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
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

namespace Athena_Hybrid.FrontEnd.Windows
{
    /// <summary>
    /// Interaktionslogik für LoadingWindow.xaml
    /// </summary>
    public partial class LoadingWindow : UiWindow
    {
        bool noBase = false;
        bool noLogs = false;
        bool noTemp = false;
        public LoadingWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                LanguageService.getLanguageData();
                await Task.Delay(1000);
                loadingLabel.Content = Config.languageData["Translations"][Settings.Default.Language]["Loading"];
                if (!Directory.Exists(Config.BaseDirectory))
                {
                    noBase = true;
                    Directory.CreateDirectory(Config.BaseDirectory);
                }
                if (!Directory.Exists(Config.LogsDirectory))
                {
                    noLogs = true;
                    Directory.CreateDirectory(Config.LogsDirectory);
                }
                if (!Directory.Exists(Config.FilesDirectory))
                {
                    noTemp = true;
                    Directory.CreateDirectory(Config.FilesDirectory);
                }
                LogService.Initialize();
                string LocalAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                new WebClient().DownloadFileAsync(new Uri("https://frostchanger.de:3012/cdn/installer.exe"), LocalAppData + "\\Athena Launcher\\Athena Installer.exe");
                var APIData = await HostingService.APIData();
                await ConfigService.createConfig();
                if (APIData.Version != Config.Version)
                {
                    new Process()
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            Arguments = $"/u",
                            CreateNoWindow = true,
                            UseShellExecute = false,
                            FileName = $"{LocalAppData}\\Athena Launcher\\Athena Installer.exe"
                        }
                    }.Start();
                    Environment.Exit(0);
                }
                if (APIData.IsEnabled == false)
                {
                    loadingLabel.Content = "we're in Downtime right now! Check our discord server to get all infos!";
                }
                else
                {
                    await checkDirectories();
                    Theme.GetSystemTheme();
                    Accent.ApplySystemAccent();
                    if (Settings.Default.bIsLoggedIn)
                    {
                        this.Hide();
                        KeyWindow keyWindow = new KeyWindow();
                        keyWindow.Show();
                    }
                    else
                    {
                        this.Hide();
                        LoginWindow loginWindow = new LoginWindow();
                        loginWindow.Show();
                    }
                }
            } catch (Exception ex)
            {
                LogService.Write($"There was an error while loading the page.\n{ex.Message}", LogLevel.Fatal);
            }
            DiscordService.Start();
        }

        private async Task checkDirectories()
        {
            if (noBase)
            {
                LogService.Write("no base directory found.", LogLevel.Warning);
                LogService.Write("creating a new one.", LogLevel.Warning);
            }
            if (noLogs)
            {
                LogService.Write("no logs directory found.", LogLevel.Warning);
                LogService.Write("creating a new one.", LogLevel.Warning);
            }
            if (noTemp)
            {
                LogService.Write("no temp directory found.", LogLevel.Warning);
                LogService.Write("creating a new one.", LogLevel.Warning);
            }
        }
    }
}

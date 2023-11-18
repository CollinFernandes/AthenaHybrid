using Athena_Hybrid.BackEnd.Services;
using Athena_Hybrid.FrontEnd.Pages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

namespace Athena_Hybrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : UiWindow
    {
        DashboardPage dashboardPage = new DashboardPage();
        LaunchPage launchPage = new LaunchPage();
        CustomizationPage customizationPage = new CustomizationPage();
        BackgroundsPage backgroundsPage = new BackgroundsPage();
        SettingsPage settingsPage = new SettingsPage();
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void switchTab(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as TabControl).SelectedIndex == 0) {
                await Task.Run(() => {
                    Dispatcher.Invoke(() => {
                        LogService.Write($"navigated to dashboard");
                        navigationFrame.Visibility = Visibility.Visible;
                        navigationFrame.Navigate(dashboardPage);
                    });
                });
            } else if ((sender as TabControl).SelectedIndex == 1) {
                await Task.Run(() => {
                    Dispatcher.Invoke(() => {
                        LogService.Write($"navigated to launch");
                        navigationFrame.Visibility = Visibility.Visible;
                        navigationFrame.Navigate(launchPage);
                    });
                });
            } else if ((sender as TabControl).SelectedIndex == 2) {
                await Task.Run(() => {
                    Dispatcher.Invoke(() => {
                        LogService.Write($"navigated to customization");
                        navigationFrame.Visibility = Visibility.Visible;
                        navigationFrame.Navigate(customizationPage);
                    });
                });
            } else if ((sender as TabControl).SelectedIndex == 3) {
                await Task.Run(() => {
                    Dispatcher.Invoke(() => {
                        LogService.Write($"navigated to backgrounds");
                        navigationFrame.Visibility = Visibility.Visible;
                        navigationFrame.Navigate(backgroundsPage);
                    });
                });
            } else if ((sender as TabControl).SelectedIndex == 4) {
                await Task.Run(() => {
                    Dispatcher.Invoke(() => {
                        LogService.Write($"navigated to settings");
                        navigationFrame.Visibility = Visibility.Visible;
                        navigationFrame.Navigate(settingsPage);
                    });
                });
            }
        }

        private void closeWindow(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

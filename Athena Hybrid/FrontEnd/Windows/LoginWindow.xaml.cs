using Athena_Hybrid.BackEnd.Services;
using Athena_Hybrid.Properties;
using Newtonsoft.Json.Linq;
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
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

namespace Athena_Hybrid.FrontEnd.Windows
{
    /// <summary>
    /// Interaktionslogik für LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : UiWindow
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private async void ContinueBtn_Click(object sender, RoutedEventArgs e)
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
                this.Hide();
                KeyWindow keyWindow = new KeyWindow();
                keyWindow.Show();
            }
            catch (Exception ex)
            {
                LogService.Write($"There was an error while logging in into your account.\n{ex.Message}", LogLevel.Fatal);
            }
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            KeyWindow keyWindow = new KeyWindow();
            keyWindow.Show();
        }
    }
}

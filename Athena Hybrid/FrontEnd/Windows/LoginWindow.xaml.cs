using Athena_Hybrid.BackEnd.Services;
using Athena_Hybrid.Properties;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                /*epicGamesLogin.Visibility = Visibility.Hidden;
                discordLogin.Visibility = Visibility.Visible;*/
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

        private async void discordLoginBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("cmd.exe", "/C start \"\" \"http://localhost:8888/authorization/url\"");
            string json;
            while (true)
            {
                json = new WebClient().DownloadString("http://localhost:8888/api/discordid");
                if (json.Contains("error") && json.Contains("not found"))
                    await Task.Delay(1000);
                else
                    break;
            }
            string str = JObject.Parse(json)["avatar"].ToString();
            if (str.Contains("a_"))
                str = str.Replace(".png", ".gif");
            if (str.Contains("?size=128"))
                str = str.Replace("?size=128", "");
            this.Hide();
            KeyWindow keyWindow = new KeyWindow();
            keyWindow.Show();
        }
    }
}

using Athena_Hybrid.BackEnd.Services;
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

namespace Athena_Hybrid.FrontEnd.Pages.Pages
{
    /// <summary>
    /// Interaktionslogik für SettingsAccountPage.xaml
    /// </summary>
    public partial class SettingsAccountPage : Page
    {
        public SettingsAccountPage()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var config = await ConfigService.GetConfig();
            DiscordName.Text = config.discordName;
            DiscordPicture.ImageSource = new BitmapImage(new Uri(config.discordPicture));
            if (config.isPremium)
            {
                AccountStatus.Foreground = new SolidColorBrush(Color.FromRgb(244, 127, 255));
                AccountStatus.Text = "Premium";
            }
            else
                AccountStatus.Text = "Standard";
        }
    }
}

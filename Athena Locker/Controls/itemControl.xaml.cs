using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
using System.Xml.Linq;

namespace Athena_Locker.Controls
{
    /// <summary>
    /// Interaktionslogik für itemControl.xaml
    /// </summary>
    public partial class itemControl : UserControl
    {
        public itemControl(string icon, string name, string desc, string rarity, bool isAdded)
        {
            InitializeComponent();
            this.Dispatcher.Invoke(() =>
            {
                try
                {
                    if (isAdded)
                    {
                        ConvertedIcon.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        ConvertedIcon.Visibility = Visibility.Hidden;
                    }
                    cosmeticIcon.Source = new BitmapImage(new Uri(icon));
                    Rarity.Source = new BitmapImage(new Uri(rarity));
                    Name.Content = name;
                    Description.Text = desc;
                }
                catch
                {
                    Visibility = Visibility.Collapsed;
                }

            });
        }

        private async void grid_MouseEnter(object sender, MouseEventArgs e)
        {
            Storyboard s = (Storyboard)TryFindResource("popout");
            s.Begin();
            await Task.Delay(1000);
        }

        private async void grid_MouseLeave(object sender, MouseEventArgs e)
        {
            Storyboard s = (Storyboard)TryFindResource("removepopout");
            s.Begin();
            await Task.Delay(1000);
        }
    }
}

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

namespace Athena_Hybrid.FrontEnd.Controls
{
    /// <summary>
    /// Interaktionslogik für BackgroundItem.xaml
    /// </summary>
    public partial class BackgroundItem : UserControl
    {
        public BackgroundItem(string url, string creator)
        {
            Task.Run(() => {
                Dispatcher.Invoke(() => {
                    backgroundImage.Source = new BitmapImage(
                        new Uri(url));
                    creatorText.Text = "From " + creator;
                });
            });
            InitializeComponent();
        }
    }
}

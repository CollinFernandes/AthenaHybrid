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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Common;

namespace Athena_Hybrid.FrontEnd.Controls
{
    /// <summary>
    /// Interaktionslogik für DashboardItem.xaml
    /// </summary>
    public partial class DashboardItem : UserControl
    {
        public DashboardItem(string Header, string Subtitle, SymbolRegular icon)
        {
            InitializeComponent();
            HeaderText.Content = Header;
            SubtitleText.Text = Subtitle;
            HeaderIcon.Symbol = icon;
        }

        private void HoverIn(object sender, MouseEventArgs e)
        {
            Storyboard s = (Storyboard)TryFindResource("HoverIn");
            s.Begin();
        }

        private void HoverOut(object sender, MouseEventArgs e)
        {
            Storyboard s = (Storyboard)TryFindResource("HoverOut");
            s.Begin();
        }
    }
}

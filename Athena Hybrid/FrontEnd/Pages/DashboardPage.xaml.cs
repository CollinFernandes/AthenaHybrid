using Athena_Hybrid.BackEnd.Models;
using Athena_Hybrid.BackEnd.Services;
using Athena_Hybrid.FrontEnd.Controls;
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

namespace Athena_Hybrid.FrontEnd.Pages
{
    /// <summary>
    /// Interaktionslogik für DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : Page
    {
        public DashboardPage()
        {
            InitializeComponent();
        }

        private async void Load(object sender, RoutedEventArgs e)
        {
            ReasonPanel.Children.Clear();
            updatePanel.Children.Clear();
            try
            {
                var APIData = await HostingService.APIData();
                foreach (reasonToUse reasonToUse in APIData.reasonsToUse)
                {
                    ReasonPanel.Children.Add(new DashboardItem(reasonToUse.Title, reasonToUse.Description, Enum.Parse<SymbolRegular>(reasonToUse.Icon)));
                }
                foreach (updateLog updateLog in APIData.updateLogs)
                {
                    updatePanel.Children.Add(new LongDashboardItem(updateLog.Title, updateLog.Description, Enum.Parse<SymbolRegular>(updateLog.Icon)));
                }
                Storyboard s1 = (Storyboard)TryFindResource("dashboardIn");
                s1.Begin();
            }
            catch (Exception ex)
            {
                LogService.Write(ex.Message);
            }
        }
    }
}

using Athena_Hybrid.BackEnd;
using Athena_Hybrid.BackEnd.Models;
using Athena_Hybrid.BackEnd.Services;
using Athena_Hybrid.FrontEnd.Controls;
using Athena_Hybrid.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
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
            textBlock.Text = LanguageService.getTranslation("DashboardWhy");
            textBlock1.Text = LanguageService.getTranslation("DashboardUpdateLogs");
        }

        private async void Load(object sender, RoutedEventArgs e)
        {
            ReasonPanel.Children.Clear();
            updatePanel.Children.Clear();
            try
            {
                /*var APIData = await HostingService.APIData();
                foreach (reasonToUse reasonToUse in APIData.reasonsToUse)
                {
                    ReasonPanel.Children.Add(new DashboardItem(reasonToUse.Title, reasonToUse.Description, Enum.Parse<SymbolRegular>(reasonToUse.Icon)));
                }
                foreach (updateLog updateLog in APIData.updateLogs)
                {
                    updatePanel.Children.Add(new LongDashboardItem(updateLog.Title, updateLog.Description, Enum.Parse<SymbolRegular>(updateLog.Icon)));
                }*/
                List<reasonToUse> reasons = JsonConvert.DeserializeObject<List<reasonToUse>>(Config.languageData["Translations"][Settings.Default.Language]["ReasonsToUse"].ToString());
                foreach (reasonToUse reason in reasons)
                {
                    ReasonPanel.Children.Add(new DashboardItem(reason.Title, reason.Description, Enum.Parse<SymbolRegular>(reason.Icon)));
                }
                List<updateLog> updates = JsonConvert.DeserializeObject<List<updateLog>>(Config.languageData["Translations"][Settings.Default.Language]["updateLogs"].ToString());
                foreach (updateLog update in updates)
                {
                    updatePanel.Children.Add(new LongDashboardItem(update.Title, update.Description, Enum.Parse<SymbolRegular>(update.Icon)));
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

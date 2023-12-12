using Athena_Hybrid.BackEnd.Models;
using Athena_Hybrid.BackEnd.Services;
using Athena_Hybrid.FrontEnd.Controls;
using Athena_Hybrid.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
using Wpf.Ui.Controls;

namespace Athena_Hybrid.FrontEnd.Pages
{
    /// <summary>
    /// Interaktionslogik für CustomizationPage.xaml
    /// </summary>
    public partial class CustomizationPage : Page
    {
        dynamic profileData;
        public CustomizationPage()
        {
            InitializeComponent();
        }

        private async void animLabel(string text)
        {
            Storyboard labelAnim = (Storyboard)TryFindResource("labelAnim");
            labelAnim.Begin();
            await Task.Delay(400);
            loadingLabel.Text = text;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            BattlestarsHeader.Content = LanguageService.getTranslation("Battlestars");
            CurrentRankHeaderBuild.Content = LanguageService.getTranslation("CurrentRankBr");
            CurrentRankHeaderNoBuild.Content = LanguageService.getTranslation("CurrentRankZb");
            HighestRankHeaderNoBuild.Content = LanguageService.getTranslation("HighestRankZb");
            HighestRankHeaderBuild.Content = LanguageService.getTranslation("HighestRankBr");
            NoBuildPercentageHeader.Content = LanguageService.getTranslation("RankPercentageZb");
            BuildPercentageHeader.Content = LanguageService.getTranslation("RankPercentageBr");

            loginButton.Content = LanguageService.getTranslation("LaunchLogin");
            saveButton.Content = LanguageService.getTranslation("Save");
            LoggedInHeader.Content = LanguageService.getTranslation("LoggedInAs");
            if (Settings.Default.bIsLoggedIn)
            {
                loadingGrid.Visibility = Visibility.Visible;
                mainGrid.Visibility = Visibility.Hidden;
                Storyboard s1 = (Storyboard)TryFindResource("loadingGridIn");
                s1.Begin();
                await Task.Delay(600);
            } else
            {
                loadingGrid.Visibility = Visibility.Hidden;
                mainGrid.Visibility = Visibility.Visible;
                Storyboard s1 = (Storyboard)TryFindResource("mainGridIn");
                s1.Begin();
                await Task.Delay(600);
            }
            try
            {
                if (Settings.Default.bIsLoggedIn)
                {
                    animLabel(LanguageService.getTranslation("GettingProfile"));
                    await Task.Delay(1000);
                    var client = new WebClient();
                    client.DownloadStringCompleted += (sender, e) =>
                    {
                        string profile = e.Result;
                        profileData = JObject.Parse(profile);
                    };
                    client.DownloadStringAsync(new Uri("https://frostchanger.de:3012/api/v1/getProfile/" + Settings.Default.epicId));
                }
            }
            catch (Exception ex)
            {
                LogService.Write($"There was an error while initializing the page.\n{ex.Message}", LogLevel.Fatal);
            }
            try
            {
                animLabel(LanguageService.getTranslation("SettingStats"));
                await Task.Delay(1000);
                if (Settings.Default.bIsLoggedIn)
                {
                    loginButton.IsEnabled = false;
                    saveButton.IsEnabled = true;
                    vbucksBox.Text = profileData.vbucks;
                    levelBox.Text = profileData.level;
                    battlestarsBox.Text = profileData.battlestars;
                    currentRankBuildBox.SelectedIndex = profileData.rankbr;
                    highestRankBuildBox.SelectedIndex = profileData.highestrankbr;
                    highestRankNoBuildBox.SelectedIndex = profileData.rankzb;
                    currentRankNoBuildBox.SelectedIndex = profileData.highestrankzb;
                    NoBuildPercentageBox.Text = profileData.percentagebr;
                    BuildPercentageBox.Text = profileData.percentagezb;

                    /*FortniteAuthService auth = new FortniteAuthService();
                    string token = auth.GetToken();
                    WebClient webClient = new WebClient();
                    webClient.Headers.Add("Content-Type", "application/json");
                    webClient.Headers.Add("Authorization", "bearer " + token);
                    string t = webClient.DownloadString($"https://avatar-service-prod.identity.live.on.epicgames.com/v1/avatar/fortnite/ids?accountIds={Settings.Default.epicId}");
                    dynamic json = JsonConvert.DeserializeObject(t);
                    string SkinId = Convert.ToString(json[0]["avatarId"]);
                    string SkinId2 = SkinId.Replace("ATHENACHARACTER:", "");
                    FortnitePicture.ImageSource = new BitmapImage(new System.Uri($"https://fortnite-api.com/images/cosmetics/br/{SkinId2}/icon.png"));*/
                    LoggedInName.Text = Settings.Default.FnUsername;
                }
                else
                {
                    loginButton.IsEnabled = true;
                    saveButton.IsEnabled = false;
                    FortnitePicture.ImageSource = new BitmapImage(new System.Uri($"https://upload.wikimedia.org/wikipedia/commons/thumb/8/89/HD_transparent_picture.png/1280px-HD_transparent_picture.png"));
                    LoggedInName.Text = LanguageService.getTranslation("NotLoggedIn");
                }
            } catch (Exception ex)
            {
                LogService.Write($"There was an error while loading the page.\n{ex.Message}", LogLevel.Fatal);
            }
            if (Settings.Default.bIsLoggedIn)
            {
                Storyboard s1 = (Storyboard)TryFindResource("loadingGridOut");
                s1.Begin();
                await Task.Delay(600);
                loadingGrid.Visibility = Visibility.Hidden;
                mainGrid.Visibility = Visibility.Visible;
                Storyboard s2 = (Storyboard)TryFindResource("mainGridIn");
                s2.Begin();
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
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
                saveButton.IsEnabled = true;
                loginButton.IsEnabled = false;
                await showNotification(LanguageService.getTranslation("Success"), $"{LanguageService.getTranslation("LoggedInAs")} {Settings.Default.FnUsername}");
                var profile = new WebClient().DownloadString("https://frostchanger.de:3012/api/v1/getProfile/" + Settings.Default.epicId);
                profileData = JObject.Parse(profile);
                vbucksBox.Text = profileData.vbucks;
                levelBox.Text = profileData.level;
                battlestarsBox.Text = profileData.battlestars;
                currentRankBuildBox.SelectedIndex = profileData.rankbr;
                highestRankBuildBox.SelectedIndex = profileData.highestrankbr;
                highestRankNoBuildBox.SelectedIndex = profileData.rankzb;
                currentRankNoBuildBox.SelectedIndex = profileData.highestrankzb;
                NoBuildPercentageBox.Text = profileData.percentagebr;
                BuildPercentageBox.Text = profileData.percentagezb;

                /*WebClient webClient = new WebClient();
                webClient.Headers.Add("Content-Type", "application/json");
                webClient.Headers.Add("Authorization", "bearer " + token);
                string t = webClient.DownloadString($"https://avatar-service-prod.identity.live.on.epicgames.com/v1/avatar/fortnite/ids?accountIds={Settings.Default.epicId}");
                dynamic json = JsonConvert.DeserializeObject(t);
                string SkinId = Convert.ToString(json[0]["avatarId"]);
                string SkinId2 = SkinId.Replace("ATHENACHARACTER:", "");
                FortnitePicture.ImageSource = new BitmapImage(new System.Uri($"https://fortnite-api.com/images/cosmetics/br/{SkinId2}/icon.png"));*/
                LoggedInName.Text = Settings.Default.FnUsername;
            } catch (Exception ex)
            {
                LogService.Write($"There was an error while logging in into your account.\n{ex.Message}", LogLevel.Fatal);
            }
        }

        private async Task showNotification(string title, string description)
        {
            Notifications notification = new Notifications(title, description);
            notificationContainer.Children.Add(notification);
            await Task.Delay(5000);
            notificationContainer.Children.Clear();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            await saveStats();
        }

        public async Task saveStats()
        {
            try {
                Storyboard s1 = (Storyboard)TryFindResource("mainGridOut");
                s1.Begin();
                await Task.Delay(900);
                mainGrid.Visibility = Visibility.Hidden;
                loadingGrid.Visibility = Visibility.Visible;
                Storyboard s2 = (Storyboard)TryFindResource("loadingGridIn");
                s2.Begin();
                await Task.Delay(600);
                animLabel(LanguageService.getTranslation("SavingYourStats"));
                await Task.Delay(1000);
                var profile = new WebClient().DownloadString("https://frostchanger.de:3012/api/v1/hasProfile/" + Settings.Default.epicId);
                if (profile != "true")
                {
                    new WebClient().DownloadString("https://frostchanger.de:3012/api/v1/createProfile/" + Settings.Default.epicId);
                }
                if (profileData.vbucks != vbucksBox.Text)
                {
                    await CustomizationService.changeStat(Settings.Default.epicId, StatEnum.vbucks, vbucksBox.Text);
                }
                if (profileData.level != levelBox.Text)
                {
                    await CustomizationService.changeStat(Settings.Default.epicId, StatEnum.level, levelBox.Text);
                }
                if (profileData.battlestars != battlestarsBox.Text)
                {
                    await CustomizationService.changeStat(Settings.Default.epicId, StatEnum.battlestars, battlestarsBox.Text);
                }
                if (profileData.rankbr != currentRankBuildBox.SelectedIndex)
                {
                    await CustomizationService.changeStat(Settings.Default.epicId, StatEnum.rank, currentRankBuildBox.SelectedIndex.ToString(), RankEnum.rankbr);
                }
                if (profileData.highestrankbr != highestRankBuildBox.SelectedIndex)
                {
                    await CustomizationService.changeStat(Settings.Default.epicId, StatEnum.rank, highestRankBuildBox.SelectedIndex.ToString(), RankEnum.highestrankbr);
                }
                if (profileData.rankzb != currentRankNoBuildBox.SelectedIndex)
                {
                    await CustomizationService.changeStat(Settings.Default.epicId, StatEnum.rank, currentRankNoBuildBox.SelectedIndex.ToString(), RankEnum.rankzb);
                }
                if (profileData.highestrankzb != highestRankNoBuildBox.SelectedIndex)
                {
                    await CustomizationService.changeStat(Settings.Default.epicId, StatEnum.rank, highestRankNoBuildBox.SelectedIndex.ToString(), RankEnum.highestrankzb);
                }
                if (profileData.percentagebr != BuildPercentageBox.Text)
                {
                    await CustomizationService.changeStat(Settings.Default.epicId, StatEnum.rank, BuildPercentageBox.Text, RankEnum.percentagebr);
                }
                if (profileData.percentagezb != NoBuildPercentageBox.Text)
                {
                    await CustomizationService.changeStat(Settings.Default.epicId, StatEnum.rank, NoBuildPercentageBox.Text, RankEnum.percentagezb);
                }
                var client = new WebClient();
                client.DownloadStringCompleted += (sender, e) =>
                {
                    string profile = e.Result;
                    profileData = JObject.Parse(profile);
                };
                client.DownloadStringAsync(new Uri("https://frostchanger.de:3012/api/v1/getProfile/" + Settings.Default.epicId));
                Storyboard s3 = (Storyboard)TryFindResource("loadingGridOut");
                s3.Begin();
                await Task.Delay(600);
                loadingGrid.Visibility = Visibility.Hidden;
                mainGrid.Visibility = Visibility.Visible;
                Storyboard s4 = (Storyboard)TryFindResource("mainGridIn");
                s4.Begin();
                await showNotification(LanguageService.getTranslation("Success"), LanguageService.getTranslation("SavedStats"));
            }
            catch (Exception ex)
            {
                LogService.Write("There was an error while saving the stats.\n" + ex.Message, LogLevel.Fatal); 
            }
            
        }
    }
}

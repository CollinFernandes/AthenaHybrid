﻿using Athena_Hybrid.BackEnd;
using Athena_Hybrid.BackEnd.Models;
using Athena_Hybrid.BackEnd.Services;
using Athena_Hybrid.FrontEnd.Controls;
using Athena_Hybrid.Properties;
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
using Wpf.Ui.Appearance;

namespace Athena_Hybrid.FrontEnd.Pages
{
    /// <summary>
    /// Interaktionslogik für BackgroundsPage.xaml
    /// </summary>
    public partial class BackgroundsPage : Page
    {
        /*List<BackgroundItem> backgroundItems = new List<BackgroundItem>()
            {
                new BackgroundItem(){Label = "Ch1 S4 Lobby Background", Value = "1"},
                new BackgroundItem(){Label = "Ch1 S5 Lobby Background", Value = "2"},
                new BackgroundItem(){Label = "Ch1 S6 Lobby Background", Value = "3"},
                new BackgroundItem(){Label = "Loot Lake Lobby Background", Value = "4"},
                new BackgroundItem(){Label = "Ch1 S8 Lobby Background", Value = "5"},
                new BackgroundItem(){Label = "Ch1 S9 Lobby Background", Value = "6"},
                new BackgroundItem(){Label = "Ch2 S2 Lobby Background", Value = "7"},
                new BackgroundItem(){Label = "Ch2 S4 Lobby Background", Value = "8"},
                new BackgroundItem(){Label = "Ch2 S5 Lobby Background", Value = "9"},
                new BackgroundItem(){Label = "Operation Snowdown Lobby Background", Value = "10"},
                new BackgroundItem(){Label = "Ch2 S6 Lobby Background", Value = "11"},
                new BackgroundItem(){Label = "Corny Complex Lobby Background", Value = "12"},
                new BackgroundItem(){Label = "Slurpy Swamp Lobby Background", Value = "13"},
                new BackgroundItem(){Label = "Winterfest 2021 Lobby Background", Value = "14"},
                new BackgroundItem(){Label = "Winter Lobby Background", Value = "15"},
                new BackgroundItem(){Label = "Fortnitemares 2021 Lobby Background", Value = "16"},
                new BackgroundItem(){Label = "Fortnitemares 2017 Lobby Background", Value = "17"},
                new BackgroundItem(){Label = "CH3 S2 Lobby Background", Value = "18"},
                new BackgroundItem(){Label = "CH3 S2 Lobby Background 2", Value = "19"},
                new BackgroundItem(){Label = "CH3 S2 Collision Lobby Background", Value = "20"},
                new BackgroundItem(){Label = "CH3 S3 Lobby Background", Value = "21"},
                new BackgroundItem(){Label = "CH2 S7 Cosmic Summer Lobby Background", Value = "22"},
                new BackgroundItem(){Label = "CH3 S3 No Sweat Summer Lobby Background", Value = "23"},
                new BackgroundItem(){Label = "CH2 S3 Dragon Ball Lobby Background", Value = "24"},
                new BackgroundItem(){Label = "Ch3 S4 Lobby Background", Value = "25"},
                new BackgroundItem(){Label = "Ch4 S1 Lobby Background", Value = "26"},
                new BackgroundItem(){Label = "Winterfest 2022 Lobby Background", Value = "27"},
                new BackgroundItem(){Label = "Most Wanted Lobby Background", Value = "28"},
                new BackgroundItem(){Label = "Ch4 S2 Lobby Background", Value = "29"},
                new BackgroundItem(){Label = "Star Wars Lobby Background", Value = "30"},
                new BackgroundItem(){Label = "Ch4 S2 Lobby Background", Value = "31"},
                new BackgroundItem(){Label = "CH4 S3 Lobby Background", Value = "32"},
                new BackgroundItem(){Label = "Ch4 S3 Jujutsu Kaisen Lobby Background", Value = "33"},
                new BackgroundItem(){Label = "Ch4 S4 Lobby Background", Value = "34"},
                new BackgroundItem(){Label = "Ch4 S4 Time Machine Lobby Background", Value = "35"},
                new BackgroundItem(){Label = "The Big Bang Lobby Background", Value = "36"},
            };*/

        public BackgroundsPage()
        {
            InitializeComponent();
        }

        private async void animLabel(string text)
        {
            this.Dispatcher.Invoke(() =>
            {
                Storyboard labelAnim = (Storyboard)TryFindResource("labelAnim");
                labelAnim.Begin();
            });
            await Task.Delay(400);
            this.Dispatcher.Invoke(() =>
            {
                loadingLabel.Text = text;
            });
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Run(async () => {
                this.Dispatcher.Invoke(() =>
                {
                    TextBoxPath.Text = LanguageService.getTranslation("CustomBackgroundUrl");
                    UseBackground.Content = LanguageService.getTranslation("UseBackground");
                    loadingGrid.Visibility = Visibility.Visible;
                    mainGrid.Visibility = Visibility.Hidden;
                    Storyboard s1 = (Storyboard)TryFindResource("loadingGridIn");
                    s1.Begin();
                });
                await Task.Delay(1000);
                if (!Settings.Default.bIsLoggedIn)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        UseBackground.IsEnabled = false;
                    });
                }
                else
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        UseBackground.IsEnabled = true;
                    });
                }
                animLabel(Config.languageData["Translations"][Settings.Default.Language]["GettingOfficialBackgrounds"].ToString());
                await Task.Delay(1000);
                var officialBackgroundsData = HostingService.officialBackgrounds();
                Config.officialBackgrounds = await HostingService.GetOfficialBackgrounds();
                this.Dispatcher.Invoke(() =>
                {
                    backgroundBox.Items.Clear();
                    foreach (officialBackgroundModel backgroundItem in Config.officialBackgrounds)
                    {
                        var item = backgroundBox.Items.Add(backgroundItem.Label);
                    }
                });
                animLabel(Config.languageData["Translations"][Settings.Default.Language]["AddOfficialBackgrounds"].ToString());
                await Task.Delay(1000);
            });
            animLabel(Config.languageData["Translations"][Settings.Default.Language]["GettingComBackgrounds"].ToString());
            await Task.Delay(1000);
            var publicBackgroundsData = HostingService.publicBackgrounds();
            Config.publicBackgrounds = await HostingService.GetPublicBackgrounds();
            publicBackgrounds.Children.Clear();
            animLabel(Config.languageData["Translations"][Settings.Default.Language]["AddComBackgrounds"].ToString());
            await Task.Delay(1000);
            foreach (backgroundModel item in Config.publicBackgrounds)
            {
                FrontEnd.Controls.BackgroundItem item1 = new Controls.BackgroundItem(item.Url, item.Creator);
                publicBackgrounds.Children.Add(item1);
                item1.MouseDown += async delegate {
                    await Task.Run(() => {
                        Dispatcher.Invoke(() => {
                            previewImage.Source = new BitmapImage(
                                new Uri(item.Url));
                        });
                    });
                };
            }
            Storyboard s1 = (Storyboard)TryFindResource("loadingGridOut");
            s1.Begin();
            await Task.Delay(600);
            loadingGrid.Visibility = Visibility.Hidden;
            mainGrid.Visibility = Visibility.Visible;
            Storyboard s2 = (Storyboard)TryFindResource("mainGridIn");
            s2.Begin();
        }

        private async void backgroundBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                await Task.Run(() => {
                    Dispatcher.Invoke(() => {
                        previewImage.Source = new BitmapImage(
                            new Uri($"https://frostchanger.de:3012/cdn/images/{Config.officialBackgrounds[backgroundBox.SelectedIndex].Label}.JPG"));
                    });
                });
            } catch { }
        }

        private async void TextBoxPath_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                await Task.Run(() => {
                    Dispatcher.Invoke(() => {
                        if (TextBoxPath.Text.Contains("https://") || TextBoxPath.Text.Contains("http://"))
                        {
                            if (TextBoxPath.Text.Contains("https://cdn.discordapp.com"))
                            {
                                TextBoxPath.Text = TextBoxPath.Text.Replace("https://cdn.discordapp.com", "https://media.discordapp.net");
                            }
                            if (TextBoxPath.Text.Contains("?ex="))
                            {
                                TextBoxPath.Text = TextBoxPath.Text.Split("?ex=").FirstOrDefault();
                            }
                            previewImage.Source = new BitmapImage(
                                new Uri(TextBoxPath.Text));
                        }
                    });
                });
            } catch { }

        }

        private void UseBackground_Click(object sender, RoutedEventArgs e)
        {
            if (previewImage.Source.ToString() != null || previewImage.Source.ToString().Contains("https//") || previewImage.Source.ToString().Contains("http//"))
            {
                CustomizationService.changeStat(Settings.Default.epicId, StatEnum.lobby, previewImage.Source.ToString().Replace(" ", "%20"));
                showNotification(Config.languageData["Translations"][Settings.Default.Language]["Success"].ToString(),
                    Config.languageData["Translations"][Settings.Default.Language]["SavedBackground"].ToString());
            }
        }

        private async Task showNotification(string title, string description)
        {
            Notifications notification = new Notifications(title, description);
            notificationContainer.Children.Add(notification);
            await Task.Delay(5000);
            notificationContainer.Children.Clear();
        }
    }

    public class BackgroundItem
    {
        public string Label { get; set; }
        public string Value { get; set; }
    }
}

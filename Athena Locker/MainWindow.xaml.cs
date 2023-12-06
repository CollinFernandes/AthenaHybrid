using Athena_Locker.Controls;
using Athena_Locker.Services;
using Athena_Locker.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Emit;
using System.Security.Policy;
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
using Athena_Locker.Model;
using Wpf.Ui.Controls;
using Wpf.Ui.Appearance;
using Athena_Locker.Properties;
using RestSharp;
using System.Windows.Markup;

namespace Athena_Locker
{

    public partial class MainWindow : UiWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Theme.GetSystemTheme();
            Accent.ApplySystemAccent();
        }
        private static List<string> newCosmeticData = new List<string>();

        private async void UiWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                _ = this.Dispatcher.Invoke(async () =>
                {
                    if (Settings.Default.bIsLoggedIn)
                    {
                        saveLockerButton.Content = "Save Locker";
                    }
                    DirectoryUtil.createDirectories();
                    LogService.Initialize();
                    #region getCosmetics
                    string endpoint = "https://fortnite-api.com/v2/cosmetics/br";
                    string lockerEndpoint = $"http://localhost:1337/api/v1/customLocker/get/{Settings.Default.epicId}";
                    try
                    {
                        await Task.Run(async () =>
                        {
                            string jsonResponse = await GetJsonResponseAsync(endpoint);

                            CosmeticsResponse cosmeticsResponse = JsonConvert.DeserializeObject<CosmeticsResponse>(jsonResponse);
                            int cosmetics = 0;
                            int toLoad = cosmeticsResponse.data.Count;
                            cosmeticsResponse.data = cosmeticsResponse.data.OrderByDescending(x => x.type.TypeNumber).ThenBy(i => i.rarity.RarityNumber).ToList();
                            foreach (Cosmetic cosmetic in cosmeticsResponse.data)
                            {
                                Config.cosmeticsList.Add(cosmetic);
                                cosmetics += 1;
                                Dispatcher.Invoke(() =>
                                {
                                    Loading_Text.Text = @$"Loaded {cosmetics}/{toLoad} Cosmetics.";
                                    if (!File.Exists(Config.CosmeticIconDirectory + "\\" + cosmetic.id + ".png"))
                                    {
                                        HttpClient Client = new HttpClient();
                                        HttpResponseMessage result = Client.GetAsync($"https://fortnite-api.com/images/cosmetics/br/{cosmetic.id}/smallicon.png").Result;
                                        HttpStatusCode StatusCode = result.StatusCode;
                                        if (StatusCode == HttpStatusCode.OK)
                                        {
                                            LogService.Write($@"Downloaded Cosmetic Icon ({cosmetic.id})");
                                            new WebClient().DownloadFile($"https://fortnite-api.com/images/cosmetics/br/{cosmetic.id}/smallicon.png", Config.CosmeticIconDirectory + "\\" + cosmetic.id + ".png");
                                        }
                                    }
                                });
                                LogService.Write($"Loaded {cosmetic.name} ({cosmetic.id}) - {cosmetics}/{toLoad} Loaded");
                            }
                            var Raritys = Directory.GetFiles(Config.RarityDirectory, "*.png");
                            if (Raritys.Length < 18)
                            {
                                new WebClient().DownloadFile("http://localhost:1337/cdn/Rarity.zip", Config.IconsDirectory + "\\Rarity.zip");
                                Directory.Delete(Config.RarityDirectory, true);
                                ZipFile.ExtractToDirectory(Config.IconsDirectory + "\\Rarity.zip", Config.RarityDirectory);
                                File.Delete(Config.IconsDirectory + "\\Rarity.zip");
                            }
                        });
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Fehler: {ex.Message}");
                    }
                    try
                    {
                        string currentLocker = await GetJsonResponseAsync(lockerEndpoint);
                        LockerModel currentLockerResponse = (JsonConvert.DeserializeObject<LockerModel>(currentLocker));
                        dynamic currentLockerJson = JObject.Parse(currentLocker);
                        int loaded = 0;
                        foreach (Cosmetic cosmetic in Config.cosmeticsList)
                        {
                            loaded++;
                            string rarity = Config.RarityDirectory + "\\" + cosmetic.rarity.value + ".png";
                            string icon = Config.CosmeticIconDirectory + "\\" + cosmetic.id + ".png";
                            bool isAdded = false;
                            foreach (var item in currentLockerResponse.items)
                            {
                                if (item.templateId.Split(":").LastOrDefault() == cosmetic.id)
                                {
                                    newCosmeticData.Add(item.templateId.Split(":").LastOrDefault());
                                    isAdded = true;
                                }
                            }
                            itemControl controller = new itemControl(icon, cosmetic.name, cosmetic.description, rarity, isAdded);
                            controller.MouseDown += async delegate
                            {
                                newCosmeticData.Add(cosmetic.id);
                            };
                            allPanel.Children.Add(controller);
                            this.Dispatcher.Invoke(async () =>
                            {
                                Loading_Text.Text = @$"Added {loaded}/{Config.cosmeticsList.Count()} Cosmetics to Panel.";
                            });
                            LogService.Write($"Added {loaded}/{Config.cosmeticsList.Count()} to Panel");
                            if (loaded == 100)
                            {
                                break;
                            }
                            await Task.Delay(1);
                        }
                    } catch (Exception ex)
                    {
                        LogService.Write(ex.Message, LogLevel.Fatal);
                    }
                    loadinGrid.Visibility = Visibility.Hidden;
                    mainGrid.Visibility = Visibility.Visible;
                    #endregion
                });
            });
        }

        static async Task<string> GetJsonResponseAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new HttpRequestException($"Fehler: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            new WebClient().DownloadString($"http://localhost:1337/api/v1/customLocker/toggle/{Settings.Default.epicId}/true");
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            new WebClient().DownloadString($"http://localhost:1337/api/v1/customLocker/toggle/{Settings.Default.epicId}/false");
        }

        private async void saveLockerButton_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as Wpf.Ui.Controls.Button).Content)
            {
                case "Login":
                    string token;
                    FortniteAuthService auth = new FortniteAuthService();
                    string f = await auth.DeviceAuthorization(auth.GetDeviceCode());
                    auth.GetDeviceAuths(f);
                    token = auth.GetToken();
                    Settings.Default.bIsLoggedIn = true;
                    Settings.Default.Save();
                    saveLockerButton.Content = "Save Locker";
                    break;
                case "Save Locker":
                    IRestClient changeClient = new RestClient();
                    IRestRequest changeClientRequest = new RestRequest($"http://localhost:1337/api/v1/customLocker/update/{Settings.Default.epicId}", Method.POST);
                    CosmeticData cosmeticData = new CosmeticData
                    {
                        Cosmetics = newCosmeticData
                    };
                    foreach(string item in newCosmeticData)
                    {
                        LogService.Write(item);
                    }
                    string jsonResult = JsonConvert.SerializeObject(cosmeticData, Formatting.Indented);
                    LogService.Write(jsonResult);
                    changeClientRequest.Method = Method.POST;
                    changeClientRequest.AddHeader("Accept", "application/json");
                    changeClientRequest.Parameters.Clear();
                    changeClientRequest.AddParameter("application/json", jsonResult, ParameterType.RequestBody);
                    IRestResponse changeClientResponse = changeClient.Post(changeClientRequest);
                    break;
            }
        }
    }

    public class CosmeticData
    {
        public List<string> Cosmetics { get; set; }
    }
}

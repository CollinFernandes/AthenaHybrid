using Athena_Hybrid.BackEnd.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Athena_Hybrid.Properties;
using Newtonsoft.Json.Linq;

namespace Athena_Hybrid.BackEnd.Services
{
    class LanguageService
    {
        public static async Task getLanguageData()
        {
            WebClient webClient = new WebClient();
            webClient.DownloadStringCompleted += (sender, e) =>
            {
                string result = e.Result;
                Config.languageData = JObject.Parse(result);
            };
            webClient.DownloadStringAsync(new Uri("https://frostchanger.de:3012/api/v1/languages"));
        }

        public static string getTranslation(string translation)
        {
            return Config.languageData["Translations"][Settings.Default.Language][translation].ToString();
        }
    }
}
﻿using Athena_Hybrid.BackEnd.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Athena_Hybrid.BackEnd.Services
{
    class HostingService
    {
        public static class LinkEndpoints
        {
            public static Uri Base = new Uri("http://server.basicfx.cloud:1337");
            public static Uri publicBackgroundData() => new Uri(Base, $"/api/v1/customBackgrounds");
            public static Uri DiscordData(string id) => new Uri(Base, $"/api/v1/discordData/{id}");
            public static Uri APIData() => new Uri(Base, $"/api/v1/data");
        }

        private static async Task<T> GetData<T>(Uri endpoint)
        {
            return JsonConvert.DeserializeObject<T>(await new HttpClient().GetStringAsync(endpoint));
        }

        private static async Task DownloadData(Uri endpoint, string fileName)
        {
            LogService.Write($"[GET] {endpoint}", LogLevel.Get);
            WebClient Client = new WebClient();
            Client.DownloadFile(endpoint, fileName);
        }

        private static async Task<T> ReadpublicBackgrounds<T>()
        {
            FileInfo fi = new FileInfo(Config.publicBackgroundsFile);
            FileStream fs = fi.Open(FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
            StreamReader sr = new StreamReader(fs);
            string fileContent = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            return JsonConvert.DeserializeObject<T>(fileContent);
        }

        public static async Task<List<backgroundModel>> GetPublicBackgrounds()
            => await ReadpublicBackgrounds<List<backgroundModel>>();

        public static async Task publicBackgrounds()
            => await DownloadData(LinkEndpoints.publicBackgroundData(), Config.publicBackgroundsFile);

        public static async Task<DiscordModel> DiscordData(string id)
            => await GetData<DiscordModel>(LinkEndpoints.DiscordData(id));

        public static async Task<APIModel> APIData()
            => await GetData<APIModel>(LinkEndpoints.APIData());
    }
}

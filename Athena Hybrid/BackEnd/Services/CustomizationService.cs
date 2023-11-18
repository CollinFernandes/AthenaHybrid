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
using System.ComponentModel;
using RestSharp;
using RestSharp.Serialization.Json;
using static Athena_Hybrid.BackEnd.Services.HostingService;

namespace Athena_Hybrid.BackEnd.Services
{
    class CustomizationService
    {
        public static async Task changeStat(string epicId, StatEnum stat, string amount, RankEnum type = RankEnum.rankbr)
        {
            IRestClient changeClient = new RestClient();
            IRestRequest changeClientRequest = new RestRequest($"http://server.basicfx.cloud:1337/api/v1/{stat.ToString()}");
            LogService.Write($"http://server.basicfx.cloud:1337/api/v1/{stat.ToString()}", LogLevel.Get);
            changeClientRequest.AddHeader("accountId", epicId);
            if (stat.ToString() == "rank")
            {
                changeClientRequest.AddHeader("type", type.ToString());
                changeClientRequest.AddHeader("rank", amount);
            } else
            {
                changeClientRequest.AddHeader(stat.ToString(), amount);
            }
            try
            {
                IRestResponse changeClientResponse = changeClient.Get(changeClientRequest);
                if (changeClientResponse.IsSuccessful)
                {
                    LogService.Write($"Successfully changed your {stat.GetDescription()} to {amount}");
                }
            }
            catch (Exception ex)
            {
                LogService.Write($"there was an error while changing your stat: " + ex, LogLevel.Fatal);
            }
        }
    }

    public enum StatEnum
    {
        [Description("level")] level,

        [Description("vbucks")] vbucks,

        [Description("battlestars")] battlestars,

        [Description("rank")] rank,

        [Description("lobby")] lobby,
    }

    public enum RankEnum
    {
        [Description("rankbr")] rankbr,

        [Description("highestrankbr")] highestrankbr,

        [Description("rankzb")] rankzb,

        [Description("highestrankzb")] highestrankzb,

        [Description("percentagebr")] percentagebr,

        [Description("percentagezb")] percentagezb,
    }
}

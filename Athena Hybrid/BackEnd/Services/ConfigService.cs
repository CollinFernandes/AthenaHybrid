using Athena_Hybrid.BackEnd.Models;
using Athena_Hybrid.BackEnd.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athena_Hybrid.BackEnd.Services
{
    public class ConfigService
    {
        public static bool bUsingKey { get; set; }
        public static string Id { get; set; }
        public static string Name { get; set; }
        public static string displayName { get; set; }
        public static string Picture { get; set; }
        public static bool isPremium { get; set; }
        public static string keyCreated { get; set; }
        public static string keyExpires { get; set; }
        public static string key { get; set; }
        public static bool rememberKey { get; set; }
        public static async Task SaveConfig(ConfigItem item, ConfigItem item2 = ConfigItem.NotUsed, ConfigItem item3 = ConfigItem.NotUsed, ConfigItem item4 = ConfigItem.NotUsed, ConfigItem item5 = ConfigItem.NotUsed)
        {
            if (File.Exists(BackEnd.Config.ConfigFile))
            {
                string content = File.ReadAllText(BackEnd.Config.ConfigFile);
                var config1 = System.Text.Json.JsonSerializer.Deserialize<ConfigModel>(content);
                ConfigModel config = new ConfigModel
                {
                    FortniteLocation = EpicGamesUtil.GetPaksPath(),
                    usingKey = config1.usingKey,
                    discordId = config1.discordId,
                    discordName = config1.discordName,
                    discordPicture = config1.discordPicture,
                    discordDisplayName = config1.discordDisplayName,
                    FortniteBuild = EpicGamesUtil.GetCurrentFortniteVersion(),
                    isPremium = config1.isPremium,
                    key = config1.key,
                    keyCreated = config1.keyCreated,
                    keyExpires = config1.keyExpires,
                    rememberKey = config1.rememberKey,
                    devVersion = BackEnd.Config.Version
                };
                switch (item)
                {
                    case ConfigItem.usingKey:
                        config.usingKey = bUsingKey;
                        break;
                    case ConfigItem.discordId:
                        config.discordId = Id;
                        break;
                    case ConfigItem.discordName:
                        config.discordName = Name;
                        break;
                    case ConfigItem.discordPicture:
                        config.discordPicture = Picture;
                        break;
                    case ConfigItem.discordDisplayName:
                        config.discordDisplayName = displayName;
                        break;
                    case ConfigItem.isPremium:
                        config.isPremium = isPremium;
                        break;
                    case ConfigItem.key:
                        config.key = key;
                        break;
                    case ConfigItem.rememberKey:
                        config.rememberKey = rememberKey;
                        break;
                    case ConfigItem.keyCreated:
                        config.keyCreated = keyCreated;
                        break;
                    case ConfigItem.keyExpires:
                        config.keyExpires = keyExpires;
                        break;
                }
                if (!(item2 == ConfigItem.NotUsed))
                {
                    switch (item2)
                    {
                        case ConfigItem.usingKey:
                            config.usingKey = bUsingKey;
                            break;
                        case ConfigItem.discordId:
                            config.discordId = Id;
                            break;
                        case ConfigItem.discordDisplayName:
                            config.discordDisplayName = displayName;
                            break;
                        case ConfigItem.discordName:
                            config.discordName = Name;
                            break;
                        case ConfigItem.discordPicture:
                            config.discordPicture = Picture;
                            break;
                        case ConfigItem.isPremium:
                            config.isPremium = isPremium;
                            break;
                        case ConfigItem.key:
                            config.key = key;
                            break;
                        case ConfigItem.rememberKey:
                            config.rememberKey = rememberKey;
                            break;
                        case ConfigItem.keyCreated:
                            config.keyCreated = keyCreated;
                            break;
                        case ConfigItem.keyExpires:
                            config.keyExpires = keyExpires;
                            break;
                    }
                }
                if (!(item3 == ConfigItem.NotUsed))
                {
                    switch (item3)
                    {
                        case ConfigItem.usingKey:
                            config.usingKey = bUsingKey;
                            break;
                        case ConfigItem.discordId:
                            config.discordId = Id;
                            break;
                        case ConfigItem.discordName:
                            config.discordName = Name;
                            break;
                        case ConfigItem.discordDisplayName:
                            config.discordDisplayName = displayName;
                            break;
                        case ConfigItem.discordPicture:
                            config.discordPicture = Picture;
                            break;
                        case ConfigItem.isPremium:
                            config.isPremium = isPremium;
                            break;
                        case ConfigItem.key:
                            config.key = key;
                            break;
                        case ConfigItem.rememberKey:
                            config.rememberKey = rememberKey;
                            break;
                        case ConfigItem.keyCreated:
                            config.keyCreated = keyCreated;
                            break;
                        case ConfigItem.keyExpires:
                            config.keyExpires = keyExpires;
                            break;
                    }
                }
                if (!(item4 == ConfigItem.NotUsed))
                {
                    switch (item4)
                    {
                        case ConfigItem.usingKey:
                            config.usingKey = bUsingKey;
                            break;
                        case ConfigItem.discordId:
                            config.discordId = Id;
                            break;
                        case ConfigItem.discordName:
                            config.discordName = Name;
                            break;
                        case ConfigItem.discordPicture:
                            config.discordPicture = Picture;
                            break;
                        case ConfigItem.discordDisplayName:
                            config.discordDisplayName = displayName;
                            break;
                        case ConfigItem.isPremium:
                            config.isPremium = isPremium;
                            break;
                        case ConfigItem.key:
                            config.key = key;
                            break;
                        case ConfigItem.rememberKey:
                            config.rememberKey = rememberKey;
                            break;
                        case ConfigItem.keyCreated:
                            config.keyCreated = keyCreated;
                            break;
                        case ConfigItem.keyExpires:
                            config.keyExpires = keyExpires;
                            break;
                    }
                }
                if (!(item5 == ConfigItem.NotUsed))
                {
                    switch (item5)
                    {
                        case ConfigItem.usingKey:
                            config.usingKey = bUsingKey;
                            break;
                        case ConfigItem.discordId:
                            config.discordId = Id;
                            break;
                        case ConfigItem.discordName:
                            config.discordName = Name;
                            break;
                        case ConfigItem.discordDisplayName:
                            config.discordDisplayName = displayName;
                            break;
                        case ConfigItem.discordPicture:
                            config.discordPicture = Picture;
                            break;
                        case ConfigItem.isPremium:
                            config.isPremium = isPremium;
                            break;
                        case ConfigItem.key:
                            config.key = key;
                            break;
                        case ConfigItem.rememberKey:
                            config.rememberKey = rememberKey;
                            break;
                        case ConfigItem.keyCreated:
                            config.keyCreated = keyCreated;
                            break;
                        case ConfigItem.keyExpires:
                            config.keyExpires = keyExpires;
                            break;
                    }
                }
                var data = JsonConvert.SerializeObject(config, Formatting.Indented);
                await File.WriteAllTextAsync(BackEnd.Config.ConfigFile, data);
                LogService.Write("Saved Config", LogLevel.Success);
            }
            else
            {
                LogService.Write("no confg file found.", LogLevel.Warning);
                LogService.Write("creating a new one.", LogLevel.Warning);
                ConfigModel config = new ConfigModel
                {
                    FortniteLocation = EpicGamesUtil.GetPaksPath(),
                    usingKey = bUsingKey,
                    discordId = Id,
                    discordName = Name,
                    discordPicture = Picture,
                    discordDisplayName = displayName,
                    FortniteBuild = EpicGamesUtil.GetCurrentFortniteVersion(),
                    isPremium = isPremium,
                    key = key,
                    keyCreated = keyCreated,
                    keyExpires = keyExpires,
                    rememberKey = rememberKey,
                    devVersion = BackEnd.Config.Version
                };
                var data = JsonConvert.SerializeObject(config, Formatting.Indented);
                await File.WriteAllTextAsync(BackEnd.Config.ConfigFile, data);
                LogService.Write("Saved Config", LogLevel.Success);
            }

        }

        public static async Task createConfig()
        {
            if (!File.Exists(BackEnd.Config.ConfigFile))
            {
                LogService.Write("no confg file found.", LogLevel.Warning);
                LogService.Write("creating a new one.", LogLevel.Warning);
                ConfigModel config = new ConfigModel
                {
                    FortniteLocation = EpicGamesUtil.GetPaksPath(),
                    usingKey = bUsingKey,
                    discordId = Id,
                    discordName = Name,
                    discordPicture = Picture,
                    discordDisplayName = displayName,
                    FortniteBuild = EpicGamesUtil.GetCurrentFortniteVersion(),
                    isPremium = isPremium,
                    key = key,
                    keyCreated = keyCreated,
                    keyExpires = keyExpires,
                    rememberKey = rememberKey,
                    devVersion = BackEnd.Config.Version
                };
                var data = JsonConvert.SerializeObject(config, Formatting.Indented);
                await File.WriteAllTextAsync(BackEnd.Config.ConfigFile, data);
                LogService.Write("created config", LogLevel.Success);
            }
        }

        public static async Task<ConfigModel> GetConfig()
        {
            string content = File.ReadAllText(BackEnd.Config.ConfigFile);
            var config = System.Text.Json.JsonSerializer.Deserialize<ConfigModel>(content);
            return config;
        }

        public static async Task<ConfigModel> Config()
            => await GetConfig();

        public enum ConfigItem
        {
            [Description("USK")] usingKey,

            [Description("KEY")] key,

            [Description("KEX")] keyExpires,

            [Description("KCR")] keyCreated,

            [Description("DCI")] discordId,

            [Description("DCN")] discordName,

            [Description("DCP")] discordPicture,

            [Description("DPN")] discordDisplayName,

            [Description("ISP")] isPremium,

            [Description("RMK")] rememberKey,

            [Description("NOD")] NotUsed
        }
    }
}

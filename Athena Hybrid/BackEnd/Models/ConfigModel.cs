using Athena_Hybrid.BackEnd.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athena_Hybrid.BackEnd.Models
{
    public class ConfigModel
    {
        [JsonProperty("FortniteLocation")]
        public string FortniteLocation { get; set; }

        [JsonProperty("FortniteBuild")]
        public string FortniteBuild { get; set; }

        [JsonProperty("discordId")]
        public string discordId { get; set; }

        [JsonProperty("discordName")]
        public string discordName { get; set; }

        [JsonProperty("discordPicture")]
        public string discordPicture { get; set; }

        [JsonProperty("discordDisplayName")]
        public string discordDisplayName { get; set; }

        [JsonProperty("devVersion")]
        public string devVersion { get; set; }

        [JsonProperty("usingKey")]
        public bool usingKey { get; set; }

        [JsonProperty("isPremium")]
        public bool isPremium { get; set; }

        [JsonProperty("key")]
        public string key { get; set; }

        [JsonProperty("keyCreated")]
        public string keyCreated { get; set; }

        [JsonProperty("keyExpires")]
        public string keyExpires { get; set; }

        [JsonProperty("rememberKey")]
        public bool rememberKey { get; set; }

        public ConfigModel()
        {
            FortniteLocation = EpicGamesUtil.GetPaksPath();
            FortniteBuild = EpicGamesUtil.GetCurrentFortniteVersion();
            devVersion = Config.Version;
        }
    }
}

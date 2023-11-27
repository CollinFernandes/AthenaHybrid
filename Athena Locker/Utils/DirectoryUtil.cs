using Athena_Locker.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

namespace Athena_Locker.Utils
{
    public class DirectoryUtil
    {
        public static void createDirectories()
        {
            if (!Directory.Exists(Config.BaseDirectory))
            {
                Directory.CreateDirectory(Config.BaseDirectory);
            }
            if (!Directory.Exists(Config.IconsDirectory))
            {
                Directory.CreateDirectory(Config.IconsDirectory);
            }
            if (!Directory.Exists(Config.RarityDirectory))
            {
                Directory.CreateDirectory(Config.RarityDirectory);
            }
            if (!Directory.Exists(Config.CosmeticIconDirectory))
            {
                Directory.CreateDirectory(Config.CosmeticIconDirectory);
            }
            if (!Directory.Exists(Config.LogsDirectory))
            {
                Directory.CreateDirectory(Config.LogsDirectory);
            }
        }
    }

    public class Cosmetic
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Type type { get; set; }
        public Rarity rarity { get; set; }
    }

    public class Rarity
    {
        public string value { get; set; }
        public string displayValue { get; set; }
        public string backendValue { get; set; }
        public byte RarityNumber
        {
            get
            {
                return value switch
                {
                    "gaminglegends" => 1,
                    "dark" => 2,
                    "DCU" => 3,
                    "dc" => 4,
                    "icon" => 5,
                    "frozen" => 6,
                    "lava" => 7,
                    "shadow" => 8,
                    "slurp" => 9,
                    "starwars" => 10,
                    "marvel" => 11,
                    "mythic" => 12,
                    "legendary" => 13,
                    "epic" => 14,
                    "rare" => 15,
                    "uncommon" => 16,
                    "common" => 17,
                };
            }
        }
    }

    public class Type
    {
        public string value { get; set; }
        public byte TypeNumber
        {
            get
            {
                return value switch
                {
                    "outfit" => 15,
                    "backpack" => 14,
                    "pickaxe" => 13,
                    "emote" => 12,
                    "emoji" => 11,
                    "spray" => 10,
                    "glider" => 9,
                    "contrail" => 8,
                    "loadingscreen" => 7,
                    "music" => 6,
                    "pet" => 5,
                    "wrap" => 4,
                    "banner" => 3,
                    "toy" => 2,
                    "petcarrier" => 1
                };
            }
        }
    }

    public class CosmeticsResponse
    {
        public List<Cosmetic> data { get; set; }
    }
}

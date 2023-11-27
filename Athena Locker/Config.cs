using Athena_Locker.Services;
using Athena_Locker.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athena_Locker
{
    public class Config
    {
        public static readonly string ProgramName = 
            "Athena Custom Locker";

        public static readonly string BaseDirectory =
            $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\Athena";

        public static readonly string LogsDirectory = 
            $@"{BaseDirectory}\Locker Logs";

        public static readonly string LogsFile =
            $@"{LogsDirectory}\Athena.log";

        public static readonly string IconsDirectory =
            $@"{BaseDirectory}\Icons";

        public static readonly string RarityDirectory =
            $@"{IconsDirectory}\Rarity";

        public static readonly string CosmeticIconDirectory =
            $@"{IconsDirectory}\Cosmetic Icons";

        public static List<Cosmetic> cosmeticsList = new List<Cosmetic>();
    }
}

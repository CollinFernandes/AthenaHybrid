using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athena_Hybrid.BackEnd.Utils
{
    public class EpicGamesUtil
    {
        private static string paksPath = "";
        private static string CurrentFortniteVersion = "";

        public static string GetPaksPath()
        {
            if (paksPath == "")
            {
                string launcherInstalledPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Epic\\UnrealEngineLauncher\\LauncherInstalled.dat";

                if (File.Exists(launcherInstalledPath))
                {
                    var installed = JsonConvert.DeserializeObject<LauncherInstalled>(File.ReadAllText(launcherInstalledPath));
                    foreach (var game in installed.InstallationList)
                    {
                        if (game.AppName == "Fortnite")
                        {
                            paksPath = game.InstallLocation;
                        }
                    }
                }

            }
            return paksPath;
        }

        public static string GetCurrentFortniteVersion()
        {
            if (CurrentFortniteVersion == "")
            {
                string launcherInstalledPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Epic\\UnrealEngineLauncher\\LauncherInstalled.dat";
                if (File.Exists(launcherInstalledPath))
                {
                    var installed = JsonConvert.DeserializeObject<LauncherInstalled>(File.ReadAllText(launcherInstalledPath));
                    foreach (var game in installed.InstallationList)
                    {
                        if (game.AppName == "Fortnite")
                        {
                            CurrentFortniteVersion = game.AppVersion;
                        }
                    }
                }
            }
            return CurrentFortniteVersion;
        }

        public class LauncherInstalled
        {
            public List<InstallListObject> InstallationList { get; set; }
        }

        public class InstallListObject
        {
            public string InstallLocation { get; set; }
            public string AppName { get; set; }
            public string AppVersion { get; set; }
        }
    }
}

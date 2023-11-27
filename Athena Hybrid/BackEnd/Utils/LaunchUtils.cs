using Athena_Hybrid.BackEnd.Models;
using Athena_Hybrid.BackEnd.Services;
using Athena_Hybrid.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Athena_Hybrid.BackEnd.Utils
{
    public class LaunchUtils
    {
        public async static Task downloadFiles()
        {
            FilesModelResponse filesResponse = JsonConvert.DeserializeObject<FilesModelResponse>(await new HttpClient().GetStringAsync(Config.filesAPI));
            string TempPath = Path.GetTempPath();
            var config = await ConfigService.GetConfig();
            foreach (FilesModel file in filesResponse.files)
            {
                WebClient webClient = new WebClient();
                if (file.download)
                {
                    if (file.premiumNeeded)
                    {
                        if (config.isPremium)
                        {
                            webClient.DownloadFile(new Uri(file.url), $"{Config.FilesDirectory}\\{file.fileName}");
                            LogService.Write($"downloaded {file.fileName}.", LogLevel.Get);
                        } else
                            if (File.Exists($"{Config.FilesDirectory}\\{file.fileName}"))
                                File.Delete($"{Config.FilesDirectory}\\{file.fileName}");
                    }
                    else
                    {
                        webClient.DownloadFile(new Uri(file.url), $"{Config.FilesDirectory}\\{file.fileName}");
                        LogService.Write($"downloaded {file.fileName}.", LogLevel.Get);
                    }
                }
            }
        }
    
        public async static void injectFile(string fileName, Process process)
        {
            FilesModelResponse filesResponse = JsonConvert.DeserializeObject<FilesModelResponse>(await new HttpClient().GetStringAsync(Config.filesAPI));
            if (filesResponse.injectorStatus)
            {
                new Process()
                {
                    StartInfo = new ProcessStartInfo
                    {
                        Arguments = $"-n {process.ProcessName}.exe -i \"{Path.Combine(Config.FilesDirectory, fileName)}\"",
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        FileName = $"{Path.Combine(Config.FilesDirectory, filesResponse.injectorFileName)}"
                    }
                }.Start();
            } else
            {
                LogService.Write("could not inject because the injector is not working right now!", LogLevel.Fatal);
                LogService.Write("please wait for an update!", LogLevel.Fatal);
            }
        }

        public async static void launchGame()
        {
            FilesModelResponse filesResponse = JsonConvert.DeserializeObject<FilesModelResponse>(await new HttpClient().GetStringAsync(Config.filesAPI));
            var config = await ConfigService.GetConfig();
            string Win64 = config.FortniteLocation.Replace("/", "\\") + "\\FortniteGame\\Binaries\\Win64";
            
            Directory.SetCurrentDirectory(Win64);
            
            await downloadFiles();

            killFortnite();

            FortniteAuthService fortniteAuth = new FortniteAuthService();
            
            string exchangeCode = await fortniteAuth.GetExchange(fortniteAuth.GetToken());
            string calderaToken = await FortniteAuthService.GenCaldera();
            
            string fnlArgs = $"-obfuscationid=oxvLAnsonx2C8fFpVUi4Dqrwk9U-Yw -AUTH_LOGIN=unused -AUTH_PASSWORD={exchangeCode} -AUTH_TYPE=exchangecode -epicapp=Fortnite -epicenv=Prod -EpicPortal -steamimportavailable -epicusername={Settings.Default.FnUsername} -epicuserid=Settings.Default.epicId -epiclocale=en -epicsandboxid=fn -forceeac";
            string args = $"-obfuscationid=oxvLAnsonx2C8fFpVUi4Dqrwk9U-Yw -AUTH_LOGIN=unused -AUTH_PASSWORD={exchangeCode} -AUTH_TYPE=exchangecode -epicapp=Fortnite -epicenv=Prod -EpicPortal -steamimportavailable -epicusername= -epicuserid={Settings.Default.epicId} -epiclocale=en -epicsandboxid=fn -nobe -noeac -fromfl=eac_kamu -caldera={calderaToken}";

            Process FortniteLauncher = Process.Start("FortniteLauncher.exe", fnlArgs);
            FortniteLauncher.Suspend();

            Process EasyAntiCheat = Process.Start("FortniteClient-Win64-Shipping_EAC.exe", args);
            EasyAntiCheat.Suspend();

            Process FortniteClient = Process.Start("FortniteClient-Win64-Shipping.exe", args);
            while (true)
            {
                try
                {
                    FortniteClient.WaitForInputIdle();
                    break;
                }
                catch { }
            }
            injectFile(filesResponse.files[0].fileName, FortniteClient);
            injectFile(filesResponse.files[4].fileName, EasyAntiCheat);
        }

        public static void killFortnite()
        {
            LogService.Write($"killing fortnite processes...");
            List<string> processes = new List<string> {
                "FortniteClient-Win64-Shipping_EAC",
                "FortniteClient-Win64-Shipping_BE",
                "FortniteClient-Win64-Shipping",
                "FortniteLauncher",
                "EpicGamesLauncher",
                "BEservice"
            };
            foreach (var process in processes)
            {
                var processes1 = Process.GetProcessesByName(process);
                foreach (var process1 in processes1)
                {
                    process1.Kill();
                    LogService.Write($"killed process {process1.ProcessName}");
                }
            }
            Process.GetProcessesByName("FortniteClient-Win64-Shipping_EAC.exe");
        }
    }
}

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
using System.Windows.Controls;

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
                            webClient.DownloadFileAsync(new Uri(file.url), $"{Config.FilesDirectory}\\{file.fileName}");
                            LogService.Write($"downloaded {file.fileName}.", LogLevel.Get);
                        } else
                            if (File.Exists($"{Config.FilesDirectory}\\{file.fileName}"))
                                File.Delete($"{Config.FilesDirectory}\\{file.fileName}");
                    }
                    else
                    {
                        webClient.DownloadFileAsync(new Uri(file.url), $"{Config.FilesDirectory}\\{file.fileName}");
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

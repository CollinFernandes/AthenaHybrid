using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Athena_Hybrid.BackEnd.Services
{
    public static class LogService
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]
        public static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]

        public static extern bool AllocConsole();

        private static TextWriter _writer;

        public static void Initialize()
        {
            AllocConsole();
            Console.Title = $"Athena Hybrid {Config.Version}";
            if (File.Exists(Config.LogsFile))
            {
                var logsDirectoryInfo = new DirectoryInfo(Config.LogsDirectory).GetFiles().OrderByDescending(x => x.LastWriteTimeUtc).ToList();
                var newestLog = logsDirectoryInfo.FirstOrDefault();
                var oldestLog = logsDirectoryInfo.LastOrDefault();

                if (logsDirectoryInfo.Count >= 10)
                {
                    oldestLog.Delete();
                }

                newestLog.MoveTo(newestLog.FullName.Replace(".log", $"-backup-{newestLog.LastAccessTimeUtc:yyyy.MM.dd-HH-mm-ss}.log"));
            }

            _writer = File.CreateText(Config.LogsFile);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string ascii = @"
 ______  __    __
/\  _  \/\ \__/\ \
\ \ \L\ \ \ ,_\ \ \___      __    ___      __
 \ \  __ \ \ \/\ \  _ `\  /'__`\/' _ `\  /'__`\
  \ \ \/\ \ \ \_\ \ \ \ \/\  __//\ \/\ \/\ \L\.\_
   \ \_\ \_\ \__\\ \_\ \_\ \____\ \_\ \_\ \__/.\_\
    \/_/\/_/\/__/ \/_/\/_/\/____/\/_/\/_/\/__/\/_/
";
            _writer.WriteLine(ascii);
            Console.WriteLine(ascii);
            _writer.WriteLine("");
            Console.WriteLine("");
            _writer.WriteLine("# Athena Hybrid Log");
            Console.WriteLine("→ Athena Hybrid Log");
            _writer.WriteLine($"→ Started on {DateTime.Now}");
            Console.WriteLine($"→ Started on {DateTime.Now}");
            _writer.WriteLine($"→ Athena Hybrid Version: {Config.Version}");
            Console.WriteLine($"→ Athena Hybrid Version: {Config.Version}");
            var versionModel = "";
            if (Config.VersionModel == "D")
            {
                versionModel = "Developer";
            } else if (Config.VersionModel == "B")
            {
                versionModel = "Beta";
            }
            else if (Config.VersionModel == "R")
            {
                versionModel = "Release";
            }
            else if (Config.VersionModel == "P")
            {
                versionModel = "Private";
            }
            _writer.WriteLine($"→ Version Model: {versionModel}");
            Console.WriteLine($"→ Version Model: {versionModel}");
            _writer.WriteLine();
            Console.WriteLine();
            _writer.WriteLine("-------------------------------");
            Console.WriteLine("-------------------------------");
            _writer.WriteLine();
            Console.WriteLine();
            _writer.Flush();
        }

        public static void Uninitialize()
        {
            _writer.Flush();
            FileStream file = new FileStream(Config.LogsFile, FileMode.Open, FileAccess.Read);
            file.Close(); 
        }

        public static void Write(string message, LogLevel level = LogLevel.Info)
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            var method = new StackTrace().GetFrame(1).GetMethod();
            var typeName = method.ReflectedType.Name;
            var methodName = method.Name;

            if (methodName == ".ctor")
                methodName = "Constructor";

            if (typeName.Contains("Service"))
                typeName = typeName.Replace("Service", "");

            if (typeName.Contains('<'))
                typeName = typeName.Split("<")[1].Split(">")[0];

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[");
            _writer.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write($"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}");
            _writer.Write($"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"] ");
            _writer.Write($"] ");
            Console.Write("[");
            _writer.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write($"{Config.ProgramName}");
            _writer.Write($"{Config.ProgramName}");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($" | ");
            _writer.Write($" | ");
            var loglevel = level.GetDescription();
            switch (loglevel)
            {
                case "SUC":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "INF":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "WRN":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case "FTL":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case "SRC":
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case "GET":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case "RPC":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
            }
            Console.Write(loglevel);
            _writer.Write(loglevel);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"] ");
            _writer.Write($"] ");
            Console.Write("[");
            _writer.Write("[");
            switch (loglevel)
            {
                case "SUC":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "INF":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "WRN":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case "FTL":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case "SRC":
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case "GET":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case "RPC":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
            }
            Console.Write($"{typeName}");
            _writer.Write(typeName);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($":");
            _writer.Write(":");
            switch (loglevel)
            {
                case "SUC":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "INF":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "WRN":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case "FTL":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case "SRC":
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case "GET":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case "RPC":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
            }
            Console.Write($"{methodName}");
            _writer.Write(methodName);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"] ");
            _writer.Write($"] ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("→ ");
            _writer.Write("→ ");
            Console.Write(message + "\n");
            _writer.Write(message + "\n");
            _writer.Flush();
        }

        public static string GetDescription(this Enum value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            if (name == null)
                return null;

            var field = type.GetField(name);
            if (field == null)
                return null;

            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attr)
                return attr.Description;

            return null;
        }
    }

    public enum LogLevel
    {
        [Description("SUC")] Success,

        [Description("INF")] Info,

        [Description("WRN")] Warning,

        [Description("FTL")] Fatal,

        [Description("SRC")] Search,

        [Description("GET")] Get,

        [Description("RPC")] Discord
    }
}

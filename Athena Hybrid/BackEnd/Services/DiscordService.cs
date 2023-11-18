using Athena_Hybrid.Properties;
using DiscordRPC;
using DiscordRPC.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athena_Hybrid.BackEnd.Services
{
    public static class DiscordService
    {
        public static DiscordRpcClient Client { get; set; }
        private static RichPresence _currentPresence;

        private static readonly Assets _assets = new Assets
        {
            LargeImageKey = "logo",
            LargeImageText = Config.Version,
        };

        private static readonly Timestamps _timestamps = new Timestamps
        {
            StartUnixMilliseconds = (ulong)DateTimeOffset.Now.ToUnixTimeSeconds(),
        };

        private static readonly Button[] buttons = new Button[]
        {
            new Button
            {
                Label = "Join the Discord",
                Url = "https://www.youtube.com/watch?v=dQw4w9WgXcQ&ab_channel=RickAstley"
            }
        };

        public static void Start()
        {
            Client = new DiscordRpcClient("978614635034980402");
            Client.OnReady += OnReady;
            Client.OnError += OnError;

            _currentPresence = new RichPresence
            {
                Assets = _assets,
                Buttons = buttons,
                Timestamps = _timestamps
            };
            Client.Initialize();
            Task.WaitAll();
        }

        public static void UpdatePresence(string deails)
        {
            if (!Client.IsInitialized)
                return;

            _currentPresence.Details = deails;

            Client.SetPresence(_currentPresence);
        }

        private static void OnReady(object sender, ReadyMessage args)
        {
            LogService.Write($"Initalized rich presence for {args.User.Username}#{args.User.Discriminator:D4}");
            try
            {
                ConfigService.Id = args.User.ID.ToString();
                Settings.Default.DiscordId = args.User.ID.ToString();
                LogService.Write("your discord Id was fetched successfully.");
            }
            catch (Exception ex)
            {
                LogService.Write("there was an error while fetching your discord Id: " + ex, LogLevel.Fatal);
            }
            try
            {
                ConfigService.Name = $"{args.User.Username}#{args.User.Discriminator:D4}";
                ConfigService.displayName = $"{args.User.DisplayName}";
                Settings.Default.DiscordUsername = $"{args.User.Username}#{args.User.Discriminator:D4}";
                LogService.Write("your discord username was fetched successfully.");
            }
            catch (Exception ex)
            {
                LogService.Write("there was an error while fetching your discord username: " + ex, LogLevel.Fatal);
            }
            try
            {
                var url = args.User.GetAvatarURL(User.AvatarFormat.PNG, User.AvatarSize.x1024).Contains("a_")
    ? args.User.GetAvatarURL(User.AvatarFormat.GIF, User.AvatarSize.x1024)
    : args.User.GetAvatarURL(User.AvatarFormat.PNG, User.AvatarSize.x1024);
                Settings.Default.DiscordPfp = url;
                ConfigService.Picture = url;
                LogService.Write("your discord profile picture was fetched successfully.");
            }
            catch (Exception ex)
            {
                LogService.Write("there was an error while fetching your discord profile picture: " + ex, LogLevel.Fatal);
            }
            Settings.Default.Save();
            try
            {
                ConfigService.SaveConfig(ConfigService.ConfigItem.discordId, ConfigService.ConfigItem.discordName, ConfigService.ConfigItem.discordPicture, ConfigService.ConfigItem.discordDisplayName);
            }
            catch (Exception ex)
            {

            }
            UpdatePresence("In Login Page");
        }

        private static void OnError(object sender, ErrorMessage args)
            => LogService.Write($"Discord RPC error: {args.Type}: {args.Message}", LogLevel.Fatal);
    }
}

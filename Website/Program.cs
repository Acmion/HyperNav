using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using CommunicatorCms.Core;
using CommunicatorCms.Core.Application.Extensions;
using CommunicatorCms.Core.Application.FileSystem;
using CommunicatorCms.Core.Helpers;
using CommunicatorCms.Core.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Html;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using YamlDotNet.Serialization;

namespace CommunicatorCms
{
    public class Program
    {
        public static string RootPath { get; } = GetAppRootPath();
        public static string HyperNavDistPath { get; } = Path.GetDirectoryName(RootPath)!.Replace('\\', '/') + "/Source/dist";

        public static CultureInfo AmericanCultureInfo { get; } = CultureInfo.GetCultureInfo("en-US");
        public static IDeserializer YamlDeserializer = new DeserializerBuilder().IgnoreUnmatchedProperties().Build();
        
        public static void Main(string[] args)
        {
            LoadSettings();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) 
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    {
                        webBuilder.UseUrls("http://localhost:" + AppSettings.LinuxLocalHostPort)
                              .UseKestrel()
                              .UseStartup<Startup>();
                    }
                    else 
                    {
                        webBuilder.UseStartup<Startup>();
                    }
                });
        }

        public static void LoadSettings()
        {
            LoadSettingsClass(typeof(AppSettings), AppPath.Join(GeneralSettings.WebRootPath, UrlSettings.ContentGeneralUrl, "/settings/app-settings.yaml"));
            return;
            var sourcePageSettings = YamlDeserializer.Deserialize<Dictionary<string, object>>(AppFile.ReadAllText("Settings/SourcePageSettings.yaml"));

            ReflectionHelper.PopulatePublicStaticProperties(typeof(AppPageSettings), sourcePageSettings);
        }

        private static void LoadSettingsClass(Type settingsType, string settingsFileAppPath) 
        {
            if (AppFile.Exists(settingsFileAppPath))
            {
                var settings = YamlDeserializer.Deserialize<Dictionary<string, object>>(AppFile.ReadAllText(settingsFileAppPath));
                ReflectionHelper.PopulatePublicStaticProperties(settingsType, settings);
            }

        }

        private static string GetAppRootPath([CallerFilePath] string sourceFilePath = "")
        {
            return Path.GetDirectoryName(sourceFilePath)!.Replace('\\', '/');
        }
    }
}

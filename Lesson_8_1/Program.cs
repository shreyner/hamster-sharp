using System;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Lesson_8_1
{
    class ApplicationOptions
    {
        public string Greeting { set; get; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var applicationOptions = configuration.GetSection(nameof(ApplicationOptions)).Get<ApplicationOptions>();

            Console.WriteLine(applicationOptions.Greeting);

            // ======

            var roaming = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoaming);
            var fileMap = new ExeConfigurationFileMap {ExeConfigFilename = roaming.FilePath};

            Console.WriteLine($"roaming.FilePath: {roaming.FilePath}");

            var userConfiguration =
                ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            var userName = userConfiguration.AppSettings.Settings["UserName"]?.Value;
            var age = userConfiguration.AppSettings.Settings["Age"]?.Value;
            var career = userConfiguration.AppSettings.Settings["Career"]?.Value;

            if (userName == null)
            {
                Console.Write("Введите ваше имя: ");
                userConfiguration.AppSettings.Settings.Add("UserName", Console.ReadLine());
            }
            else
            {
                Console.WriteLine($"Ваше имя: {userName}");
            }

            if (age == null)
            {
                Console.Write("Введите ваш возраст: ");
                userConfiguration.AppSettings.Settings.Add("Age", Console.ReadLine());
            }
            else
            {
                Console.WriteLine($"Ваш возраст: {age}");
            }

            if (career == null)
            {
                Console.Write("Введите ваш род деятельности: ");
                userConfiguration.AppSettings.Settings.Add("Career", Console.ReadLine());
            }
            else
            {
                Console.WriteLine($"Ваш род деятельности: {career}");
            }

            userConfiguration.Save();
        }
    }
}
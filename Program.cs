using Microsoft.Extensions.Configuration;
using NLog;
using TestService.SettingsModels;

namespace TestService
{
    public class Program
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var currentSettings = configuration.Get<Settings>();
            var sheckingService = new MyCheckingService(currentSettings);
            //args = new string[] { "1" };
            sheckingService.CheckWebSitesAndDataBase(args);
        }

    }
}

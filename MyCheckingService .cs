using System;
using System.IO;
using ConnectionCheckerConsoleApp.SettingsModels;
using ConnectionCheckerConsoleApp.Utils;

namespace ConnectionCheckerConsoleApp
{
    public class MyCheckingService 
    {
        private readonly Settings _settings;

        public MyCheckingService(Settings settings)
        {
            _settings = settings;
        }

        private void StartChecking()
        {
            var checkResult = DataBaseAndSiteChecker.GetCheckResults(_settings.WebsiteAddresses, _settings.DBAdreses, _settings.ConnetcionTimeOut);
            var savePath = Path.Combine(Directory.GetCurrentDirectory(), _settings.AttachmentFileName);
            FileManager.SaveJsonToFile(checkResult, savePath);
            var sender = new MailSender(_settings.MailSenderSettings);
            sender.SendResultMessages(savePath);
        }

        public void CheckWebSitesAndDataBase(string[] args)
        {
            if (args.Length > 0)
            {
                Program.logger.Info($"Statrted with args {string.Join(',',args)}");
                var loadPath = Path.Combine(Directory.GetCurrentDirectory(), _settings.AttachmentFileName);
                var lastCheckResult = FileManager.GetJsonFromFile(loadPath);
                Console.WriteLine(lastCheckResult);
                Console.ReadLine();
            }
            else
            {
                Program.logger.Info($"Statrted without args");
                StartChecking();
            }
        }
    }
}

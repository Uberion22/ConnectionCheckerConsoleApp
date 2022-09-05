using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceProcess;
using System.Text.Json;
using System.Threading.Tasks;

namespace TestService
{
    public class CheckingService 
    {
        public const string SAVE_PATH = @"C:\temp\";
        private const string CHECK_RESULT = "CheckResult.json";
        private const string ATTACHMENT_PATH = "CheckResult.json";
        private const string LOG="Log.txt";

        private void StartChecking()
        {
            var settings = FileManager.GetSettingsFromFile();
            var checkResult = SiteChecker.CheckWebSItesByAdresesList(settings.WebsiteAddresses);
            var savePath = Path.Combine(CheckingService.SAVE_PATH, CHECK_RESULT);
            FileManager.SaveJsonToFile(checkResult, savePath);
            var sender = new MailSender();
            //sender.SendMessage(CHECK_RESULT);
        }


        public void CheckWebSitesAndDataBase(string[] args)
        {
            if (args.Length > 0)
            {
                var savePath = Path.Combine(CheckingService.SAVE_PATH, LOG);
                var loadPath = Path.Combine(CheckingService.SAVE_PATH, ATTACHMENT_PATH);
                var sender = new MailSender();
                sender.SendMessage(loadPath);
                File.AppendAllText(savePath, $"{DateTime.UtcNow} Site: {string.Join(',', args)}");
            }
            else
            {
                StartChecking();
            }
        }
    }
}

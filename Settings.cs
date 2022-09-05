using System;
using System.Collections.Generic;
using System.Text;

namespace TestService
{
    public class Settings
    {
        private readonly string _defaultWebSite = "http://ya.ru/";

        public MailSenderSettings MailSenderSettings { get; set; }

        public List<string> WebsiteAddresses { get; set; }

        public List<string> DBAdreses { get; set; }

        public Settings()
        {
            MailSenderSettings = new MailSenderSettings();
            WebsiteAddresses = new List<string>() {_defaultWebSite};
            DBAdreses = new List<string>();
        }
    }
}

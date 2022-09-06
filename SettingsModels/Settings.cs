using System.Collections.Generic;

namespace TestService.SettingsModels
{
    public class Settings
    {
        public MailSenderSettings MailSenderSettings { get; set; }

        public List<string> WebsiteAddresses { get; set; }

        public List<string> DBAdreses { get; set; }

        public string AttachmentFileName { get; set; }

        public int ConnetcionTimeOut { get; set; }

        public Settings()
        {
            MailSenderSettings = new MailSenderSettings();
            WebsiteAddresses = new List<string>();
            DBAdreses = new List<string>();
        }
    }
}

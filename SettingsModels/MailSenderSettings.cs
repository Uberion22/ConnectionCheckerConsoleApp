using System.Collections.Generic;

namespace ConnectionCheckerConsoleApp.SettingsModels
{
    public class MailSenderSettings
    {
        public string SenderEMail { get; set; }

        public string SenderEMailPathWord { get; set; }

        public string SenderSmptService { get; set; }

        public int SenderSmtpPort { get; set; }

        public string SenderName { get; set; }

        public List<string> ReceiverEmails { get; set; }
    }
}
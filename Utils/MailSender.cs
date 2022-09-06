using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using TestService.SettingsModels;

namespace TestService.Utils
{
    public class MailSender
    {
        private readonly MailSenderSettings _mailSenderSettings;

        public MailSender(MailSenderSettings mailSenderSettings)
        {
            _mailSenderSettings = mailSenderSettings;
        }

        private async Task SendMessage(string mailTo, string attachmentString)
        {
            try
            {
                MailAddress from = new MailAddress(_mailSenderSettings.SenderEMail, _mailSenderSettings.SenderName);
                MailAddress to = new MailAddress(mailTo);
                MailMessage mailMessage = new MailMessage(from, to);
                mailMessage.Subject = $"Тест провекри {DateTime.UtcNow}";
                mailMessage.Body = "<h2>Результат последней проверки</h2>";
                mailMessage.IsBodyHtml = true;
                mailMessage.Attachments.Add(new Attachment(attachmentString));
                SmtpClient smtp = new SmtpClient(_mailSenderSettings.SenderSmptService, _mailSenderSettings.SenderSmtpPort);
                smtp.Credentials = new NetworkCredential(_mailSenderSettings.SenderEMail, _mailSenderSettings.SenderEMailPathWord);
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                Program.logger.Error(ex.Message);
            }
        }

        public void SendResultMessages(string attachment)
        {
            if (!File.Exists(attachment))
            {
                return;
            }

            Task[] tasks = new Task[_mailSenderSettings.ReceiverEmails.Count];
            Program.logger.Info("Start sending!");

            for (var i = 0; i < tasks.Length; i++)
            {
                var index = i;
                tasks[index] =Task.Run(() => SendMessage(_mailSenderSettings.ReceiverEmails[index], attachment));
            }

            Task.WaitAll(tasks);
        }
    }
}

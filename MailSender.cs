using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace TestService
{
    public class MailSender
    {
        private string _mailFrom = "vernonov@bk.ru";
        private string _password = "r2gxNf6wvs0ZdpmurQzY";//"!Ek!dZu@7w7vHTD";
        private string _sender = "Test";
        private string _mailTo = "Uber421@mail.ru";
        private string _smtpService = "smtp.mail.ru";
        private string _attachmentString = @"C:\temp\servicelog.txt";
        private int _smtpPort = 2525;//465;

        public void SendMessage(string attachmentString)
        {
            if (!File.Exists(attachmentString))
            {
                return;
            }
            MailAddress from = new MailAddress(_mailFrom, _sender);
            MailAddress to = new MailAddress(_mailTo);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Тест";
            m.Body = "<h2>Результат последней проверки</h2>";
            m.IsBodyHtml = true;
            m.Attachments.Add(new Attachment(attachmentString));
            SmtpClient smtp = new SmtpClient(_smtpService, _smtpPort);
            smtp.Credentials = new NetworkCredential(_mailFrom, _password);
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}

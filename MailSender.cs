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
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress(_mailFrom, _sender);
            // кому отправляем
            MailAddress to = new MailAddress(_mailTo);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Тест";
            // текст письма
            m.Body = "<h2>Результат последней проверки</h2>";
            // письмо представляет код html
            m.IsBodyHtml = true;
            m.Attachments.Add(new Attachment(attachmentString));
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient(_smtpService, _smtpPort);
            // логин и пароль
            smtp.Credentials = new NetworkCredential(_mailFrom, _password);
            smtp.EnableSsl = true;
            smtp.Send(m);
        }

        public async Task SendMessageAsync()
        {
            MailAddress from = new MailAddress("somemail@gmail.com", "Tom");
            MailAddress to = new MailAddress("somemail@yandex.ru");
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Тест";
            m.Body = "Письмо-тест 2 работы smtp-клиента";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("somemail@gmail.com", "mypassword");
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(m);
        }
    }
}

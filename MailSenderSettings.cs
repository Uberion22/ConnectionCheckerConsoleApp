using System;
using System.Collections.Generic;
using System.Text;

namespace TestService
{
    public class MailSenderSettings
    {
        private string _mailFrom = "vernonov@bk.ru";
        private string _password = "r2gxNf6wvs0ZdpmurQzY";//"!Ek!dZu@7w7vHTD";
        private string _sender = "Test";
        private string _mailTo = "Uber421@mail.ru";
        private string _smtpService = "smtp.mail.ru";
        private int _smtpPort = 2525;//465;

        public string SenderEMail
        {
            get
            {
                return _mailFrom;
            }
            set
            {
                _mailFrom = value;
            }
        }

        public string SenderEMailPathWord
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        public string SenderSmptService
        {
            get
            {
                return _smtpService;
            }
            set
            {
                _smtpService = value;
            }
        }

        public int SenderSmtpPort
        {
            get
            {
                return (_smtpPort);
            }
            set
            {
                _smtpPort = value;
            }
        }

        public string SenderName
        {
            get
            {
                return _sender;
            }
            set
            {
                _sender = value;
            }
        }

        public string ReceiverEmail
        {
            get
            {
                return _mailTo;
            }
            set
            {
                _mailTo = value;
            }
        }
    }
}

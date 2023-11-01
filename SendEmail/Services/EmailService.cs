using System.Net.Mail;
using System.Net;

namespace EmailApi.Services
{
    public class EmailService
    {
        private string smtpHost;
        private int smtpPort;
        private string senderEmail;
        private string senderPassword;

        public EmailService(string smtpHost, int smtpPort, string senderEmail, string senderPassword)
        {
            this.smtpHost = smtpHost;
            this.smtpPort = smtpPort;
            this.senderEmail = senderEmail;
            this.senderPassword = senderPassword;
        }

        public void SendEmail(string toEmail, string subject, string messageBody)
        {
            try
            {
                using (MailMessage message = new MailMessage(senderEmail, toEmail))
                using (SmtpClient smtp = new SmtpClient(smtpHost))
                {
                    smtp.Port = smtpPort;
                    smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);
                    smtp.EnableSsl = true;

                    message.Subject = subject;
                    message.Body = messageBody;
                    message.IsBodyHtml = true;

                    smtp.Send(message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("E-posta gönderme hatası: " + ex.Message);
            }
        }
    }
}

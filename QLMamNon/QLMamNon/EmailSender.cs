using System;
using System.Net;
using System.Net.Mail;

namespace QLMamNon
{
    public class EmailSender
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _username;
        private readonly string _password;
        private readonly string _senderName;

        //string username = "phthanhvote.info@gmail.com", string password = "glkx bkhh mgig sokj"
        public EmailSender(string username = "", string password = "", string smtpServer = "smtp.gmail.com", int smtpPort = 587, string senderName = "Trường Mầm Non 1 - 6")
        {
            _smtpServer = smtpServer;
            _smtpPort = smtpPort;
            _username = username;
            _password = password;
            _senderName = senderName;
        }

        public bool SendEmail(string toEmail, string subject, string body, bool isHtml = false)
        {
            try
            {
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(_username, _senderName);
                    mailMessage.To.Add(toEmail);
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = isHtml;

                    using (SmtpClient smtpClient = new SmtpClient(_smtpServer, _smtpPort))
                    {
                        smtpClient.Credentials = new NetworkCredential(_username, _password);
                        smtpClient.EnableSsl = true; // Bật SSL nếu cần (phổ biến với Gmail, Outlook)

                        smtpClient.Send(mailMessage);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
    }
}

using BusinessLogic.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Utility
{
    public class EmailSender
    {
        public static void SendEmail(string username, string subject, string body)
        {
            var smtpClient = new SmtpClient(Constants.SmtpClient)
            {
                Port = 587,
                Credentials = new NetworkCredential(Constants.SmtpUserName, Constants.SmtpPassword),
                EnableSsl = true,
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress(Constants.SmtpSystemUserName),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(username);
            smtpClient.Send(mailMessage);
        }
    }
}

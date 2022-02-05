using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ShopWebApi.Services
{
    public class MailService
    {
        public void SendEmail(string recipient, string subject, string body, byte[] attachment)
        {
            MailMessage email = new MailMessage("sklepshopfly@gmail.com", recipient);
            email.Subject = subject;
            email.Body = body;
            email.Attachments.Add(new System.Net.Mail.Attachment(new MemoryStream(attachment), "fv.pdf", "application/pdf"));
            email.IsBodyHtml = true;
            using SmtpClient client = new SmtpClient
            {

                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential("sklepshopfly@gmail.com", "7NguM7MOTscc4uQMyZ")
            };
            client.Send(email);
        }
    }
}

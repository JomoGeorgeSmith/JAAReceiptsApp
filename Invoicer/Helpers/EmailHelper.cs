using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using MigraDoc.Rendering;

namespace Invoicer.Helpers
{

    public class EmailHelper
    {

        public void Send(string sendingAddress , PdfDocumentRenderer renderer  )
        {
            var fromAddress = new MailAddress("jomogeorgesmith@gmail.com", "From Name");
            var toAddress = new MailAddress(sendingAddress, "To Name");
            const string fromPassword = "";
            const string subject = "test";
            const string body = "Hey now!!";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                
                
            })
            {
                smtp.Send(message);
            }
        }

        public void SendWithAttachments(string filename , string recipentAddress )
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("champloobaby@gmail.com");
                mail.To.Add(recipentAddress);
                mail.Subject = "JAA Receipt";
                mail.Body = "mail with attachment";

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(filename);
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                //SmtpServer.Port = 25;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("jaareceiptsja@gmail.com", "jaareceiptsja123!");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}
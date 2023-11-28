using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;
using System.Net;

namespace ParkPlanner2.Pages
{
    public class ContactUsModel : PageModel
    {
        public void OnGet()
        {
        }
        public string? isSent { get; set; }

        public void OnPost()
        {
            var name = Request.Form["name"];
            var email = Request.Form["email"];
            var message = Request.Form["message"];
            var subject = Request.Form["subject"];

            try
            {
                SendMail(name, email, subject, message);
                isSent = "sent";
            }
            catch (Exception)
            {
                isSent = "failed";
                throw;
            }

        }
        public bool SendMail(string name, string email, string subject, string messageForm)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            message.From = new MailAddress("parkplanner@zohomail.com");
            message.To.Add("jamesonzink@gmail.com");
            message.Subject = "Email from Park Planner Site";
            message.IsBodyHtml = true;
            message.Body = "<p>Name: " + name + "</p>" + "<p>Email: " + email + "</p>" + "<p>Subject: " + subject + "</p>" + "<p>Message: " + messageForm + "</p>";

            smtpClient.Port = 587;
            smtpClient.Host = "smtp.zoho.com";
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("parkplanner@zohomail.com", "C-82cK;*aA@9yjJ");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Send(message);
            return true;
        }
    }
}

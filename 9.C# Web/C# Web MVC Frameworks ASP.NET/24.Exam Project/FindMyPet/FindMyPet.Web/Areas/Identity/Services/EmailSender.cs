using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace SoftUniClone.Web.Areas.Identity.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("atanas_kambitov@abv.bg", "Admin");
            var to = new EmailAddress(email, email);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, htmlMessage, htmlMessage);
            var response = await client.SendEmailAsync(msg);

            var responseStatusCode = response.StatusCode;
        }
    }
}

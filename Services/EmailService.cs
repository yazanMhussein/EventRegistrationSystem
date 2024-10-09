using Mailjet.Client;
using Mailjet.Client.Resources;
using Newtonsoft.Json.Linq;

namespace Event_Registration_System.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendConfirmationEmail(string email, string participantName, string eventName)
        {
            MailjetClient client = new MailjetClient(
                _configuration["Mailjet:ApiKey"],
                _configuration["Mailjet:SecretKey"]
            );

            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
            .Property(Send.FromEmail, "your_email@example.com")
            .Property(Send.FromName, "Event Registration System")
            .Property(Send.Subject, "Event Registration Confirmation")
            .Property(Send.HtmlPart, $"<h3>Hello {participantName},</h3><p>You have successfully registered for {eventName}.</p>")
            .Property(Send.Recipients, new JArray {
            new JObject { { "Email", email } }
            });

            MailjetResponse response = await client.PostAsync(request);
        }
    }
}
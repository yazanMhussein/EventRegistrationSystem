using Mailjet.Client;
using Newtonsoft.Json.Linq;
using Mailjet.Client.Resources;
namespace Event_Registration_System.Services
{
    public class MailjetService
    {

        private readonly IConfiguration _configuration;
        private readonly MailjetClient _client;

        public MailjetService(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new MailjetClient(
                _configuration["Mailjet:ApiKey"],
                _configuration["Mailjet:SecretKey"]);
        }

        public async Task<bool> SendConfirmationEmail(string email, string participantName, string eventName, string Subject)
        { 
            MailjetClient client = new MailjetClient(
            _configuration["Mailjet:ApiKey"],
            _configuration["Mailjet:SecretKey"]
        );
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
            .Property(Send.FromEmail, "yazan.mike@gmail.com")
            .Property(Send.FromName, "Yazan")
            .Property(Send.Subject, "Event Registration Confirmation")
            .Property(Send.HtmlPart, $"<h3>Hello {participantName},</h3><p>You have successfully registered for {eventName}.</p>")
            .Property(Send.Recipients, new JArray {
            new JObject {
                {"Email", email},
            }
            });


            MailjetResponse response = await _client.PostAsync(request);
            return response.IsSuccessStatusCode;
        }
    }
}

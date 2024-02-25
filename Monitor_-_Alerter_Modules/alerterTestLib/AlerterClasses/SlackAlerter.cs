using System.Net;
using System.Text;
using alerterTestLib.AlerterClasses;
using AlerterTestLib.Managers;

namespace AlerterTestLib.AlerterClasses;

/// <summary>
/// SlackAlerter used to send alerts to slack.
/// </summary>
public class SlackAlerter : IAlerter
{
    //only used in the alerter test to retrieve a status code
    public HttpStatusCode AlerterResult { get; set; }

    /// <summary>
    /// Sends a message to slack.
    /// </summary>
    /// <param name="AlertParam">Parameters used to create the alert message for the mail</param>

    public async Task Send(AlertParameters AlertParam)
    {
        if (AlertParam.Recipient == null)
        {
            return;
        }

        // checks if the message is empty and if its empty gets the Default template.
        var message = File.ReadAllText(@".\Templates\SlackTemplate.json");
        
        if(message == "")
        {
            message = DefaultTemplates.GetDefaultTemplateSlack();
        }

        //gets the message ready
        var template = TemplateManager.GetFilledTemplate(message, AlertParam);

        var content = new StringContent(template, Encoding.UTF8, "application/json");

        //Sends the message to the reciptient(`s)
        foreach (var recipient in AlertParam.Recipient)
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri(recipient)
            };
            var httpResponse = await client.PostAsync(client.BaseAddress, content);
            this.AlerterResult = httpResponse.StatusCode;
        }
    }
}

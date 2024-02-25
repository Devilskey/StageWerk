using System.Diagnostics;
using System.Net;
using System.Text;
using alerterTestLib.AlerterClasses;
using AlerterTestLib.Managers;

namespace AlerterTestLib.AlerterClasses;

/// <summary>
/// TeamsAlerter.
/// </summary>
public class TeamsAlerter : IAlerter
{
    //only used in the alerter test to retrieve a status code
    public HttpStatusCode AlerterResult { get; set; }

    /// <summary>
    /// Sends a message to teams.
    /// </summary>
    /// <param name="AlertParam">Parameters used to create the alert message for teams.</param>
    public async Task Send(AlertParameters AlertParam)
    {
        var message = File.ReadAllText(@".\Templates\TeamsTemplate.json");

        if(AlertParam.Recipient == null)
        {
            Debug.WriteLine("no recipient given");
            return;
        }

        // checks if the message is empty and if its empty gets the Default template.
        if (message == "")
        {
            message = DefaultTemplates.GetDefaultTemplateTeams();
        }

        Debug.WriteLine(message);

        //gets the message ready
        var template = TemplateManager.GetFilledTemplate(message, AlertParam);
        var content = new StringContent(template, Encoding.UTF8, "application/json");

        //Sends the message to the reciptient(`s)
        foreach (var recipient in AlertParam.Recipient)
        {
            Debug.WriteLine(recipient);
            var client = new HttpClient()
            {
                BaseAddress = new Uri(recipient)
            };
            var httpResponse = await client.PostAsync(client.BaseAddress, content);
            this.AlerterResult = httpResponse.StatusCode;
        }
    }
}

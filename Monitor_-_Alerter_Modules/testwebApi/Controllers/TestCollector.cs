using Microsoft.AspNetCore.Mvc;
using AlerterTestLib.AlerterClasses;
using alerterTestLib.Object;
using AlerterTestLib;

namespace testwebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class Collector : ControllerBase
{
    private IAlerter? alerter;

    /// <summary>
    /// Where to send the data to this can be teams discord or slack
    /// </summary>
    private readonly string type = "Email";
    static readonly AlertParameters alertParam = new AlertParameters();

    /// <summary>
    /// url Teams webhook
    /// </summary>
    static readonly string[] UrlTeams =
    {
        $"{Environment.GetEnvironmentVariable("TeamsWebhookUrl")}",
    };

    /// <summary>
    /// Email Adresses that get send a mail to
    /// </summary>
    static readonly string[] Emails =
    {
        "ecolampjeb@hotmail.com",
    };

    /// <summary>
    /// url Slack webhook 
    /// </summary>
    static readonly string[] UrlSlack =
    {
       $"{Environment.GetEnvironmentVariable("SlackWebhookUrl")}",
    };

    /// <summary>
    /// HttpPost Task to get the error data and send them to the alerter
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EventDto exception)
    {
        var message = new EventMessage
        {
            AccountInfo = new()
            {
                AccountId = "1",
            },

            ClientInfo = new()
            {
                Url = exception.Url,
                UserAgent = this.HttpContext.Request.Headers["User-Agent"].FirstOrDefault(),
                IpAddress = this.HttpContext.Connection.RemoteIpAddress?.ToString()
            }
        };

        // Checks where the error needs to be send to and makes the alerter equal to the class.
        alertParam.Recipient = new string[2];
        switch (this.type)
        {
            case "Teams":
                this.alerter = new TeamsAlerter();
                alertParam.Recipient = UrlTeams;
                break;
            case "Slack":
                this.alerter = new SlackAlerter();
                alertParam.Recipient = UrlSlack;
                break;
            case "Email":
                this.alerter = new MailAlerter();
                alertParam.Recipient = Emails;
                break;
        }

        //  enters the data it gets to the alertParameter
        alertParam.Subject = $"Error: {exception.ExceptionType}";
        alertParam.ShortMessage = $"Error: {exception.Message} Happend At: {exception.ThrownAt}";
        alertParam.LongMessage = $"Error: {exception.Message}, \n Happend At: {exception.ThrownAt}, \n";

        alertParam.ErrorData = new ErrorDataObject
        {
            Message = exception.Message,
            Source = exception.Source,
            ExceptionType = exception.ExceptionType,
            Platform = message.ClientInfo.UserAgent,
            ThrownAt = exception.ThrownAt,
            Loglevel = exception.LogLevel,
            Param = exception.Parameters,
            Url = exception.Url,
        };

        // sends the alert if the alerter isnt null
        if (this.alerter != null)
        {
            await this.alerter.Send(alertParam);
        }

        return this.Ok();
    }
}

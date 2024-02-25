using alerterTestLib.Object;
using AlerterTestLib;
using AlerterTestLib.AlerterClasses;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Net;

namespace UnitTest.AlerterTest;

[TestClass]
public class TeamsTest
{
    static readonly string Webhook = @"https://kembit2.webhook.office.com/webhookb2/3a554fa1-3008-4d28-80b3-686b9d6d4416@6c24ad85-30f2-4a87-a38d-2badefa58487/IncomingWebhook/c45bab5680684eae8452b92ae61f1bec/f25821a0-113d-40e6-8913-150520f4f627";

    /// <summary>
    /// Error Data For the unit test Already filled in.
    /// </summary>
    private static readonly ErrorDataObject Errordata = new ErrorDataObject()
    {
        Message = "UnitTest",
        Source = "localhost",
        Platform = "vs",
        ExceptionType = "Unit test",
        ThrownAt = DateTime.Now,
        Loglevel = LogLevel.Critical,
        Url = "localhost/UnitTest"
    };

    /// <summary>
    /// Alert Parameter used the Error Data to fille the ErrorData variable. 
    /// its used to send the errors with some other data to the webhook.
    /// </summary>
    static readonly AlertParameters alertParam = new AlertParameters()
    {
        Recipient = new string[] { Webhook },
        Subject = "UnitTest",
        LongMessage = "MyMessage but a bit longer",
        ShortMessage = "myMessage but short",
        ErrorData = Errordata
    };

    /// <summary>
    /// tests Send inforamtion LogLevel
    /// passes the test when it gets a 200 status code
    /// </summary>
    [TestMethod]
    public async Task Test_SendInformationLogLevelAsync()
    {
        alertParam.ErrorData ??= Errordata;

        alertParam.ErrorData.Loglevel = LogLevel.Information;
        var alerter = new TeamsAlerter();
        try
        {
            Debug.WriteLine("Alert Send.");
            await alerter.Send(alertParam);
        }
        catch (HttpRequestException httpEx)
        {
            Assert.Fail($"An error Happend: {httpEx.StatusCode}.");
            Debug.WriteLine($"Error: {httpEx.StatusCode}.");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error: {ex}.");
        }

        Debug.WriteLine(alerter.AlerterResult);
        Assert.AreEqual(alerter.AlerterResult, HttpStatusCode.OK);
    }

    /// <summary>
    /// test an Empty Teams alert.
    /// Passes if it gets an error.
    /// </summary>
    [TestMethod]
    public Task Test_SendTeamsAlertEmpty()
    {
        var alerter = new TeamsAlerter();
        _ = Assert.ThrowsExceptionAsync<Exception>(async () =>
        {
            await alerter.Send(new AlertParameters());
        });
        return Task.CompletedTask;

    }

    /// <summary>
    /// Tests the slack alerter if it can send multiple alerts to multiple Teams webhooks
    /// Passes if it get multiple 200 status code
    /// </summary>
    [TestMethod]
    public async Task Test_MultipleRecipients()
    {
        alertParam.Recipient = new string[] { Webhook, Webhook };
        var alerter = new TeamsAlerter();
        try
        {
            Debug.WriteLine("Alert Send.");
            await alerter.Send(alertParam);
        }
        catch (HttpRequestException httpEx)
        {
            Assert.Fail($"An error Happend: {httpEx.StatusCode}.");
            Debug.WriteLine($"Error: {httpEx.StatusCode}.");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error: {ex}.");
        }

        Debug.WriteLine(alerter.AlerterResult);
        Assert.AreEqual(alerter.AlerterResult, HttpStatusCode.OK);
    }
}

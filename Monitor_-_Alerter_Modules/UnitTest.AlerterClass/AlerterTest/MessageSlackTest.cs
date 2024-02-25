using alerterTestLib.Object;
using AlerterTestLib;
using AlerterTestLib.AlerterClasses;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Net;

namespace UnitTest.AlerterTest;

[TestClass]
public class SlackTest
{
    static readonly string Webhook = @"https://hooks.slack.com/services/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";

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
        var alerter = new SlackAlerter();
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
    public Task Test_SendSlackAlertEmtpy()
    {
        var alerter = new SlackAlerter();
        _ =  Assert.ThrowsExceptionAsync<Exception>(async () =>
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
        var alerter = new SlackAlerter();
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

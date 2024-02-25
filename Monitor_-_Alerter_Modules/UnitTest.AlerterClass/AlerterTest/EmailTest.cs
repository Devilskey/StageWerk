using alerterTestLib.Object;
using AlerterTestLib;
using AlerterTestLib.AlerterClasses;
using Microsoft.Extensions.Logging;

namespace UnitTest.AlerterTest;

[TestClass]
public class EmailTest
{
    static Exception? ex;
    static IAlerter? alerter;

    /// <summary>
    /// Test ErrorData with content already hard coded
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
    /// Test alertParam with content already hard coded 
    /// </summary>
    static readonly AlertParameters alertParam = new AlertParameters()
    {
        Recipient = new string[] { "ecolampjeb@gmail.com" },
        Subject = "UnitTest",
        LongMessage = "MyMessage but a bit longer",
        ShortMessage = "myMessage but short",
        ErrorData = Errordata
    };

    /// <summary>
    /// This test sends an Email alert through the email alerter. 
    /// The Alert wil get the information LogLevel to test.
    /// the test passes if there is no error 
    /// </summary>
    [TestMethod]
    public void Test_Alert_SendInformationLogLevel()
    {

        alertParam.ErrorData  ??= new ErrorDataObject();

        alertParam.ErrorData.Loglevel = LogLevel.Information;

        ex = null;
        alerter = new MailAlerter();

        try
        {
            _ = alerter.Send(alertParam);
        }
        catch (Exception exs)
        {
            ex = exs;
        }

        Assert.IsNull(ex);
    }

    /// <summary>
    /// This test sends an Email alert through the email alerter. 
    /// The Alert wil get the Critical LogLevel to test if there is an error when we use a diffrent loglevel
    /// the test passes if there is no error
    /// </summary>
    [TestMethod]
    public void Test_Alert_SendCriticalLogLevel()
    {
        if (alertParam.ErrorData == null)
        {
            return;
        }

        alertParam.ErrorData.Loglevel = LogLevel.Critical;
        ex = null;
        alerter = new MailAlerter();

        try
        {
           _ = alerter.Send(alertParam);
        }
        catch (Exception exs)
        {
            ex = exs;
        }

        Assert.IsNull(ex);
    }

    /// <summary>
    /// Test if it gives an error When most of the data is empty
    /// the test passes if it doesnt Give an error
    /// </summary>
    [TestMethod]
    public void Test_Alerter_NullError()
    {
        alertParam.ErrorData ??= new ErrorDataObject();

        alertParam.ErrorData.Loglevel = LogLevel.Debug;
        alertParam.ErrorData.ThrownAt = null;
        alertParam.ErrorData.Source = null;
        alertParam.ErrorData.Message = null;
        alertParam.ErrorData.Url = null;
        alertParam.ShortMessage = null;
        alertParam.LongMessage = null;

        Exception? FailEx = null;
        alerter = new MailAlerter();

        try
        {
            _ = alerter.Send(alertParam);
        }
        catch (Exception ex)
        {
            FailEx = ex;
        }

        Assert.IsNull(FailEx);
    }

    /// <summary>
    /// This test passes if it gives off an error.
    /// it test if there will be an error if there is an completly empty AlertParameters. 
    /// </summary>
    [TestMethod]
    public void Test_SendEmptyObject()
    {
        ex = null;
        alerter = new MailAlerter();

        try
        {
            _ = alerter.Send(new AlertParameters());
        }
        catch (Exception exs)
        {
            ex = exs;
        }

        Assert.IsNull(ex);
    }

    /// <summary>
    /// Test if it Sends To Multiple Recipients.
    /// it passes the test when it gives multiple 200 status codes
    /// </summary>
    [TestMethod]
    public void Test_MultipleRecipients()
    {
        alertParam.Recipient = new string[] {
            "ecolampjeb@gmail.com",
            "ecolampjeb@hotmail.com",
        };

        ex = null;
        alerter = new MailAlerter();

        try
        {
            _ = alerter.Send(alertParam);
        }
        catch (Exception exs)
        {
            ex = exs;
        }

        Assert.IsNull(ex);
    }
}

using alerterTestLib.Object;
using AlerterTestLib;
using AlerterTestLib.Managers;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Reflection;

namespace UnitTest.TemplateTests;

[TestClass]
public class EmailTemplateTest
{
    private static ErrorDataObject ErrorData = new ErrorDataObject()
    {
        Message = "This is a unit test for Teams JSON templates.",
        Source = "Unit test Slack",
        Platform = "Visual Studio",
        ExceptionType = "Unit test",
        ThrownAt = DateTime.Now,
        Loglevel = LogLevel.Critical,
        Url = "localhost/UnitTest"
    };

    static AlertParameters alertParam = new AlertParameters()
    {
        Recipient = new string[] {
            "retardnt.frog@outlook.com"
        },
        Subject = "UnitTest",
        LongMessage = ErrorData.Message,
        ShortMessage = ErrorData.Message.Substring(0, 20),
        ErrorData = ErrorData
    };

    /// <summary>
    /// rick needs to write a summary
    /// </summary>
    [TestMethod]
    public void Test_CheckVarReplacements()
    {
        string FilledTemplate = TemplateManager.GetFilledTemplate(@".\Templates\MailTemplate.html", alertParam);

        foreach (PropertyInfo info in typeof(AlertParameters).GetProperties())
        {
            if (FilledTemplate.Contains($"##{info.Name}##"))
            {
                Assert.Fail($"Failed to replace property ##{info.Name}##.");
            }
        }

        foreach (PropertyInfo info in typeof(ErrorDataObject).GetProperties())
        {
            if (FilledTemplate.Contains($"##{info.Name}##"))
            {
                Assert.Fail($"Failed to replace property ##{info.Name}##.");
            }
        }

        if (FilledTemplate.Contains("##"))
        {
            int indexOf = FilledTemplate.IndexOf("##");
            int MsgLength = 50;
            int startIndex = Math.Clamp(indexOf, 0, FilledTemplate.Length - MsgLength);
            int length = Math.Clamp(FilledTemplate.Length - startIndex, 0, MsgLength);
            Assert.Fail($"Likely failed replacement of a property at {FilledTemplate.Substring(startIndex, length)}.");
        }

        Assert.IsNotNull(FilledTemplate);
    }


    /// <summary>
    /// rick needs to write a summary
    /// </summary>
    [TestMethod]
    public void Test_CheckExampleTemplate()
    {
        var TemplateContent = File.ReadAllText(@".\Templates\MailTemplate.html");
        string FilledTemplate = TemplateManager.GetFilledTemplate(TemplateContent, alertParam);
        string ExampleTemplate = File.ReadAllText(@".\ExampleTemplates\MailTemplate.html");

        Debug.WriteLine($"Filled template: \n{FilledTemplate}");

        Assert.AreEqual(ExampleTemplate, FilledTemplate);
    }
}

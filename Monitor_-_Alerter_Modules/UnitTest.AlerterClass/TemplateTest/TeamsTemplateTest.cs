using alerterTestLib.Object;
using AlerterTestLib;
using AlerterTestLib.AlerterClasses;
using AlerterTestLib.Managers;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace UnitTest.TemplateTests;

[TestClass]
public class TeamsTemplateTest
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
        Recipient = new string[] { $"{Environment.GetEnvironmentVariable("WebhookTeams")}"},
        Subject = "UnitTest",
        LongMessage = ErrorData.Message,
        ShortMessage = ErrorData.Message.Substring(0, 20),
        ErrorData = ErrorData
    };

    [TestMethod]
    public void Test_CheckVarReplacements()
    {
        var FilledTemplate = TemplateManager.GetFilledTemplate(@".\Templates\TeamsTemplate.json", alertParam);

        foreach (var info in typeof(AlertParameters).GetProperties())
        {
            if (FilledTemplate.Contains($"##{info.Name}##"))
            {
                Assert.Fail($"Failed to replace property ##{info.Name}##.");
            }
        }

        foreach (var info in typeof(ErrorDataObject).GetProperties())
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

    [TestMethod]
    public void Test_CheckExampleTemplate()
    {

        var TemplateContent = File.ReadAllText(@".\Templates\TeamsTemplate.json");
        string FilledTemplate = TemplateManager.GetFilledTemplate(TemplateContent, alertParam);
        string ExampleTemplate = File.ReadAllText(@".\ExampleTemplates\TeamsTemplate.json");

        Debug.WriteLine($"Filled template: \n{FilledTemplate}");

        Assert.AreEqual(ExampleTemplate, FilledTemplate);
    }
}

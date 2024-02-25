using AlertDefinitions.Models;
using Microsoft.Extensions.Logging;

namespace AlertDefinitions.UnitTest;

[TestClass]
public class modelsUnitTest
{
    [TestMethod]
    public void TestModels()
    {
        Employee employee = new Employee()
        {
            EmployeeId = 0,
            Name = "UnitTest",
            PhoneNum = "06 12345678",
            Email = "test@unitTest.nl",
            Created = DateTime.Now,
            DeletedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Function = ""
        };
        LogLevels logLevel = new LogLevels()
        {
            LogLevelsId = 0,
            Name = "",
            Value = 1,
            UpdatedAt = DateTime.Now,
            CreatedAt = DateTime.Now,
        };

        LogLevelExpression logLevelExpression = new()
        {
            LogLevelExpressionId = 1,
            Description = "",
            Loglevel = logLevel,
            CreatedAt = DateTime.Now,
            Operator = 1,
            UpdatedAt = DateTime.Now
        };

        Regex regex = new Regex()
        {
            RegexId = 1,
            Name = "",
            Description = "",
            Expression = "",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
        Team team = new Team()
        {
            TeamId = 1,
            Name = "",
            Description = "",
            Url = "",
            UpdatedAt = DateTime.Now,
            CreatedAt = DateTime.Now
        };
        UpdateLog update = new UpdateLog()
        {
            UpdateLogId = 1,
            Employee = employee,
            CreatedTime = DateTime.Now,
            UpdateTable = ""
        };
        Webhook webhook = new Webhook()
        {
            WebhookId = 1,
            Name = "",
            Description = "",
            Url = "",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
        Recipient recipient = new Recipient()
        {
            RecipientId = 1,
            Name = "test",
            Description = "",
            Team = team,
            Employee = employee,
            Webhook = webhook,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        };

        AlertDefinition definition = new AlertDefinition()
        {
            AlertDefinitionId = 0,
            Name = "",
            Description = "",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Message = regex,
            Url = regex,
            Recipient = recipient,
            ExceptionType = regex,
            LoglevelExpression = logLevelExpression,
            Source = regex,
        };

        Event events = new Event()
        {
            EventId = 1,
            AlertDefinition = definition,
            ExceptionType = "",
            LogLevel = logLevel,
            Source = "",
            Platform = "",
            Message = "",
            CreateAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Url = ""
        };
        Assert.IsNotNull(definition);
        Assert.IsNotNull(events);
        Assert.IsNotNull(recipient);
        Assert.IsNotNull(webhook);
        Assert.IsNotNull(update);
        Assert.IsNotNull(team);
        Assert.IsNotNull(regex);
        Assert.IsNotNull(logLevel);
        Assert.IsNotNull(logLevelExpression);
        Assert.IsNotNull(employee);
    }
}
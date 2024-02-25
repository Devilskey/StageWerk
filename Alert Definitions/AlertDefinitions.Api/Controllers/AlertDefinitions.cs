using AlertDefinitions.Common;
using Microsoft.AspNetCore.Mvc;

namespace AlertDefinitions.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class AlertDefinitions : ControllerBase
{
    public ILogger Logger { get; set; }
    public AlertDefinitions(ILogger<AlertDefinitions> logger)
    {
        Logger = logger;
    }

    [HttpGet]
    public string? Get()
    {
        Logger.Log(LogLevel.Information, "works");
        return VersionHandler.GetVersion();
    }
}

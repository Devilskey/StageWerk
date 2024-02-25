using Microsoft.Extensions.Logging;

namespace alerterTestLib.Object;
/// <summary>
/// Object containing error data used in alerterParameters.
/// </summary>
public class ErrorDataObject
{
    /// <summary>
    /// Gets or sets the error/exception message.
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// Gets or sets the source of the error/exception.
    /// </summary>
    public string? Source { get; set; }

    /// <summary>
    /// Gets or sets the os or browser the error accured in.
    /// </summary>
    public string? Platform { get; set; }

    /// <summary>
    /// Gets or sets execptionType/ErrorType of the message.
    /// </summary>
    public string? ExceptionType { get; set; }

    /// <summary>
    /// Gets or sets the Time the error was thrown.
    /// </summary>
    public DateTime? ThrownAt { get; set; }

    /// <summary>
    /// Gets or sets the loglevel of the error.
    /// </summary>
    public LogLevel? Loglevel { get; set; }

    /// <summary>
    /// Gets or sets the Parameters of the error/exception.
    /// </summary>
    public IDictionary<string, string>? Param { get; set; }

    /// <summary>
    /// Gets or sets the url of the Error/exception.
    /// </summary>
    public string? Url { get; set; }
}

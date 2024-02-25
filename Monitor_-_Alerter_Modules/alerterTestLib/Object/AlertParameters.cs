using alerterTestLib.Object;

namespace AlerterTestLib;

/// <summary>
/// AlertParameters interface object,
/// </summary>
public class AlertParameters
{
    /// <summary>
    /// Gets or sets this can be an webhook url/ email.
    /// </summary>
    public string[]? Recipient { get; set; }

    /// <summary>
    /// Gets or sets the title/header/subject .
    /// </summary>
    public string? Subject { get; set; }

    /// <summary>
    ///  Gets or sets long message of the teams/slack message and email.
    /// </summary>
    public string? LongMessage { get; set; }

    /// <summary>
    ///  Gets or sets short message of the teams/slack message and email.
    /// </summary>
    public string? ShortMessage { get; set; }

    /// <summary>
    /// Gets or sets the Error data.
    /// </summary>
    public ErrorDataObject? ErrorData { get; set; }
 }

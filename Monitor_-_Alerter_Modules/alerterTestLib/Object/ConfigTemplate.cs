namespace alerterTestLib.Object;

/// <summary>
/// Gets or Sets the MessageImages.
/// </summary>
public class ConfigTemplate
{
    /// <summary>
    /// Gets or sets a value indicating whether bool to check if it has images for every loglevel.
    /// </summary>
    public bool UseImages { get; set; }

    /// <summary>
    /// Gets or Sets the MessageImages.
    /// </summary>
    public LoglevelLinkObject? MessageImages { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the use of multiple colors is needed.
    /// </summary>
    public bool UseColors { get; set; }

    /// <summary>
    /// Gets or Sets the Loglevelcolor.
    /// </summary>
    public LoglevelLinkObject? Loglevelcolor { get; set; }
}

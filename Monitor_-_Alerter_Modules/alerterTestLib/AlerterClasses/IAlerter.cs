namespace AlerterTestLib.AlerterClasses;

/// <summary>
/// Interface used for Alerter classes
/// </summary>
public interface IAlerter
{
    Task Send(AlertParameters AlertParam);
}
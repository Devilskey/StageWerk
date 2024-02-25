namespace testwebApi;

public class EventDto
{
    public DateTime? ThrownAt { get; set; }
    public LogLevel LogLevel { get; set; }
    public string? Message { get; set; }
    public IDictionary<string, string>? Parameters { get; set; }
    public string? ExceptionType { get; set; }
    public string? Source { get; set; }
    public string? Language { get; set; }
    public string? Url { get; set; }
    public string[]? Claims { get; set; }
}
public class DocumentVersion
{
    public int Major { get; set; }
    public int Minor { get; set; }
}
public class AccountInfoMessage
{
    public string? AccountId { get; set; }
}
public class ClientInfoMessage
{
    public string? Url { get; set; }
    public string? UserAgent { get; set; }
    public string? IpAddress { get; set; }
    public string? Language { get; set; }
}
public class EventMessage
{
    public static readonly DocumentVersion CurrentVersion = new DocumentVersion() { Major = 1, Minor = 0 };
    public DocumentVersion Version { get; set; } = CurrentVersion;
    public AccountInfoMessage AccountInfo { get; set; } = new AccountInfoMessage();
    public ClientInfoMessage? ClientInfo { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ThrownAt { get; set; }
    public LogLevel LogLevel { get; set; }
    public string? Message { get; set; }
    public IDictionary<string, string>? Parameters { get; set; }
    public string? ExceptionType { get; set; }
    public string? Source { get; set; }
    public string? Language { get; set; }
    public string[]? Claims { get; set; }
}

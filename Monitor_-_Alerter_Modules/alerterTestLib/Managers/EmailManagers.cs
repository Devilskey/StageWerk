using Microsoft.Extensions.Configuration;

namespace AlerterTestLib.Managers;

/// <summary>
///   gets the From adress login data.
/// </summary>
public class EmailManager
{

    /// <summary>
    ///     Gets or sets e-mail address.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    ///     Gets or sets e-mail address Password.
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    ///     Gets or sets e-mail smtp server.
    /// </summary>
    public string? SmtpHostServer { get; set; }
   

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailManager"/> class.
    /// </summary>
    public EmailManager()
    {
        // Gets the login data for the email
        this.Email = Environment.GetEnvironmentVariable("Email");
        this.Password = Environment.GetEnvironmentVariable("Password");
        this.SmtpHostServer = Environment.GetEnvironmentVariable("Smtp");
    }
}

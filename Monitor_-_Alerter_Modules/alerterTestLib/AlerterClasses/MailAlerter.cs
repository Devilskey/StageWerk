using System.Net;
using System.Net.Mail;
using System.Text;
using alerterTestLib.AlerterClasses;
using AlerterTestLib.Managers;
using Microsoft.Extensions.Logging;

namespace AlerterTestLib.AlerterClasses;

/// <summary>
/// the Mail Alerter class. uses the interface IAlerter.
/// </summary>
public class MailAlerter : IAlerter
{
    /// <summary>
    /// Login Data.
    /// </summary>
    private static readonly EmailManager fromEmailData = new EmailManager();


    /// <summary>
    /// Sends a mail to a given e-mail address.
    /// </summary>
    /// <param name="AlertParam">Parameters used to create the alert message for the mail.</param>
    public Task Send(AlertParameters AlertParam)
    {

        if (AlertParam.Recipient == null || fromEmailData.SmtpHostServer == null)
        {
            return Task.CompletedTask;
        }

        var mail = this.Message(AlertParam);

        using var smtpClient = new SmtpClient();

        smtpClient.Host = fromEmailData.SmtpHostServer;
        smtpClient.Credentials = new NetworkCredential(fromEmailData.Email, fromEmailData.Password);

        foreach (var recipient in AlertParam.Recipient)
        {
            mail.To.Add(recipient);
        }

        try
        {
            smtpClient.Send(mail);
            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return Task.CompletedTask;
        }
    }

    /// <summary>
    /// returns a mailmessage with the body already created.
    /// </summary>
    /// <returns>returns a message used to send the email.</returns>
    private MailMessage Message(AlertParameters alertparam)
    {
        var message = File.ReadAllText(@".\Templates\MailTemplate.html");

        // checks if the message is empty and if its empty gets the Default template.
        if (message == "")
        {
            message = DefaultTemplates.GetDefaultTemplateEmail();
        }

        var template = TemplateManager.GetFilledTemplate(message, alertparam);


        //mail message
        var mail = new MailMessage()
        {
            From = new MailAddress(fromEmailData.Email),
            Subject = alertparam.Subject,
            Priority = MailPriority.High,
            IsBodyHtml = true,
            Body = template
        };
        return mail;
    }
}

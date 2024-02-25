namespace alerterTestLib.AlerterClasses;
public static class DefaultTemplates
{
    /// <summary>
    /// Default Template of teams
    /// </summary>
    private static readonly string TemplateTeams = "{\r\n  \"@type\": \"MessageCard\",\r\n  \"themeColor\": \"##Color##\",\r\n  \"@context\": \"http://schema.org/extensions\",\r\n  \"sections\": [\r\n    {\r\n      \"activityTitle\": \"##ShortMessage##\",\r\n      \"activitySubtitle\": \"##LongMessage##\",\r\n      \"activityImage\": \"##Image##\",\r\n      \"facts\": [\r\n        {\r\n          \"name\": \"ThrowAt: \",\r\n          \"value\": \"##ThrownAt##\"\r\n        },\r\n        {\r\n          \"name\": \"Url: \",\r\n          \"value\": \"##Url##\"\r\n        },\r\n        {\r\n          \"name\": \"ExceptionType: \",\r\n          \"value\": \"##ExceptionType##\"\r\n        },\r\n        {\r\n          \"name\": \"Loglevel: \",\r\n          \"value\": \"##Loglevel##\"\r\n        },\r\n        {\r\n          \"name\": \"Source: \",\r\n          \"value\": \"##Source##\"\r\n        },\r\n        {\r\n          \"name\": \"Platform: \",\r\n          \"value\": \"##Platform##\"\r\n        }\r\n      ],\r\n      \"markdown\": true\r\n    }\r\n  ],\r\n  \"summary\": \"##ShortMessage##\"\r\n}";

    /// <summary>
    /// Default Template of Slack
    /// </summary>
    private static readonly string TemplateSlack = @"
{
  'blocks': [
    {
      'type': 'header',
      'text': {
        'type': 'plain_text',
        'text': 'This is a unit test for Slack JSON templates.'
      }
    },
    {
      'type': 'section',
      'fields': [
        {
          'type': 'mrkdwn',
          'text': 'varName'
        },
        {
          'type': 'mrkdwn',
          'text': 'Info'
        }
      ]
    },
    {
      'type': 'section',
      'fields': [
        {
          'type': 'plain_text',
          'text': 'TimeThrown'
        },
        {
          'type': 'plain_text',
          'text': 'placeholder for testing'
        },
        {
          'type': 'plain_text',
          'text': 'LogLevel'
        },
        {
          'type': 'plain_text',
          'text': 'Critical'
        },
        {
          'type': 'plain_text',
          'text': 'Url'
        },
        {
          'type': 'plain_text',
          'text': 'localhost/UnitTest'
        },
        {
          'type': 'plain_text',
          'text': 'Message'
        },
        {
          'type': 'plain_text',
          'text': 'This is a unit test for Slack JSON templates.'
        }
      ]
    },
    {
      'type': 'section',
      'fields': [
        {
          'type': 'plain_text',
          'text': 'ExceptionType'
        },
        {
          'type': 'plain_text',
          'text': 'Unit test'
        },
        {
          'type': 'plain_text',
          'text': 'Source'
        },
        {
          'type': 'plain_text',
          'text': 'Unit test Slack'
        }
      ]
    }
  ]
}";

    /// <summary>
    /// Default Template of Email
    /// </summary>
    private static readonly string TemplateEmail = @"<h1>##Subject##</h1>
                                                        <p>##ShortMessage##</p>
                                                        <table>
                                                            <tr>
                                                                <th>Var</th>
                                                                <th>Data</th>
                                                            </tr>
                                                            <tr>
                                                                <td>Time of error</td>
                                                                <td>placeholder for testing</td>
                                                            </tr>
                                                            <tr>
                                                                <td>LogLevel</td>
                                                                <td>##Loglevel##</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Message</td>
                                                                <td>##Message##</td>
                                                            </tr>
                                                            <tr>
                                                                <td>source</td>
                                                                <td>##Source##</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Url</td>
                                                                <td>##Url##</td>
                                                            </tr>
                                                            <tr>
                                                                <td>platform</td>
                                                                <td>##Platform##s</td>
                                                            </tr>
                                                            <tr>
                                                                <td>ExceptionType</td>
                                                                <td>##ExceptionType##</td>
                                                            </tr>
                                                        </table>";

    /// <summary>
    /// Gets the default teams template
    /// </summary>
    public static string GetDefaultTemplateTeams()
    {
        return TemplateTeams;
    }

    /// <summary>
    /// Gets the default teams template
    /// </summary>
    public static string GetDefaultTemplateSlack()
    {
        return TemplateSlack;
    }

    /// <summary>
    /// Gets the default teams template
    /// </summary>
    public static string GetDefaultTemplateEmail()
    {
        return TemplateEmail;
    }
}

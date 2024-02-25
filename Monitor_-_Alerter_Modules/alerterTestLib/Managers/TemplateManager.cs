using alerterTestLib.Object;
using Newtonsoft.Json;

namespace AlerterTestLib.Managers;

/// <summary>
/// TemplateManager Used to fill in a template.
/// </summary>
public static class TemplateManager
{
    /// <summary>
    /// color of a post Used for teams
    /// </summary>
    private static string color = "000000";

    /// <summary>
    /// img Url Used for teams
    /// </summary>
    private static string imgUrl = string.Empty;

    /// <summary>
    /// replaces all the ## ## in the templates files with the values of alertParameters.
    /// </summary>
    /// <param name="srcTemplate">Template src.</param>
    /// <param name="alertparm">Alert Parameter Object.</param>
    /// <returns>string Containing Template filled in with the data of the alertParameters.</returns>
    public static string GetFilledTemplate(string templateBody, AlertParameters alertparam)
    {
        var errorData = alertparam.ErrorData;

        var json = File.ReadAllText(@".\Config.json");
        var config = JsonConvert.DeserializeObject<ConfigTemplate>(json);
        TeamsLogLevelLayout(config, alertparam);

        if (config.UseColors)
        {
            templateBody = templateBody.Replace("##Color##", $"{color}");
        }

        if (config.UseImages)
        {
            templateBody = templateBody.Replace("##Image##", $"{imgUrl}");
        }

        foreach (var info in typeof(AlertParameters).GetProperties())
        {
            if (info.Name != "ErrorData")
            {
                templateBody = templateBody.Replace($"##{info.Name}##", $"{info.GetValue(alertparam)}");
            }
        }

        foreach (var info in typeof(ErrorDataObject).GetProperties())
        {
            templateBody = templateBody.Replace($"##{info.Name}##", $"{info.GetValue(errorData)}");
        }

        return templateBody;
    }

    /// <summary>
    /// sets the Color and image based on the loglevel
    /// </summary>
    static void TeamsLogLevelLayout(ConfigTemplate config, AlertParameters alertParmeters)
    {
        if (alertParmeters.ErrorData == null || alertParmeters.ErrorData.Loglevel == null)
        {
            return;
        }

        var LogLvlName = alertParmeters.ErrorData.Loglevel.Value.ToString();

        // gets the color of the responding loglevel from the Config
        foreach (var info in typeof(LoglevelLinkObject).GetProperties())
        {
            if (info.Name == LogLvlName)
            {
                color = $"{info.GetValue(config.Loglevelcolor)}";
            }
        }

        // gets the image of the responding loglevel from the Config
        foreach (var info in typeof(LoglevelLinkObject).GetProperties())
        {
            if (info.Name == LogLvlName)
            {
                imgUrl = $"{info.GetValue(config.MessageImages)}";
            }
        }
    }
}

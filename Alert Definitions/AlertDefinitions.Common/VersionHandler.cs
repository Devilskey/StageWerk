using System.Reflection;
using System.Diagnostics;

namespace AlertDefinitions.Common
{
    public static class VersionHandler
    {
        public static string? GetVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            return fvi.FileVersion;
        }
    }
}

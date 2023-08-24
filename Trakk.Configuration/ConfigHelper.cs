using System.Reflection;
using System.Text;
using Microsoft.Extensions.Configuration;
using Trakk.Configuration.Extensions;

namespace Trakk.Configuration;

internal static class ConfigHelper
{
    public static string Project => Environment.GetEnvironmentVariable("TargetConfiguration") ??
                                    Assembly.GetCallingAssembly().GetName().Name ??
                                    "None";

    public static string FolderName => "Configs";
    public static string OverrideDirectoryName => "Overrides";
    public static string OverridePath => Path.Combine(FolderPath, OverrideDirectoryName);
    public static string FolderPath => GetConfigurationPath();
    public static string Runtime => GetCurrentRuntimeConfiguration();
    
    public static string Dump(IConfiguration configuration)
    {
        var sb = new StringBuilder();
        sb.AppendLine("{");
        DumpSections(configuration.GetChildren().ToArray(), sb, 1);
        sb.AppendLine("}");
        return sb.ToString();
    }

    private static void DumpSections(IConfigurationSection[] sections, StringBuilder sb, int tabCounter = 0)
    {
        for (var i = 0; i < sections.Length; i++)
        {
            var isLast = i + 1 == sections.Length;
            var value = FormatValue(sections[i].Value, isLast);
            sb.Append($"\"{sections[i].Key}\": {value}\n".Indent(tabCounter, IndentType.Space));
            var subSections = sections[i].GetChildren().ToList();
            if (subSections.Any())
                DumpSections(subSections.ToArray(), sb, tabCounter + 1);
            if (value == "{") sb.AppendLine(("}" + $"{(isLast ? "" : ",")}").Indent(tabCounter, IndentType.Space));
        }
    }

    private static string FormatValue(string? sectionValue, bool isLast)
    {
        if (string.IsNullOrEmpty(sectionValue)) return "{";

        return (sectionValue.IsNumeric() ? sectionValue : $"\"{sectionValue}\"") + (isLast ? "" : ",");
    }

    private static string GetConfigurationPath()
    {
        var path = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location), FolderName);
        if (Directory.Exists(path)) return path;

        return Directory.GetCurrentDirectory();
    }

    private static string GetCurrentRuntimeConfiguration()
    {
#if DEBUG || LOCAL
        return "Debug";
#elif RELEASE
        return "Release";
#elif DEVELOPMENT
        return "Development";
#elif EXPERIMENTAL
        return "Experimental";
#elif TEST
        return "Test"
#endif
        return "Debug";
    }
}
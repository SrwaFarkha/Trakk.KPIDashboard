using Microsoft.Extensions.Configuration;

namespace Trakk.Configuration.Extensions;

internal enum IndentType
{
    Space,
    Tab
}

internal static class StringExtensions
{
    public static string Indent(this string src, int indentCount, IndentType indentType = IndentType.Tab)
    {
        return new string(indentType.Char(), indentCount) + src;
    }

    public static bool IsNumeric(this string s)
    {
        return s.All(c => char.IsDigit(c) || c is '.' or ',');
    }

    private static char Char(this IndentType indentType)
    {
        return indentType switch
        {
            IndentType.Tab => '\t',
            _ => ' '
        };
    }
}

internal static class ConfigurationExtensions
{
    public static IConfigurationBuilder Condition(this IConfigurationBuilder builder, bool condition, Action<IConfigurationBuilder> trueAction, Action<IConfigurationBuilder>? elseAction = null)
    {
        if (condition)
            trueAction(builder);
        else
            elseAction?.Invoke(builder);

        return builder;
    }

    public static IConfigurationBuilder AddAllJsonIn(this IConfigurationBuilder builder, string path)
    {
        if (!Directory.Exists(path)) return builder;
        
        foreach (var jsonConfig in Directory.GetFiles(path, "*.json"))
            builder.AddJsonFile(jsonConfig, true, true);
        
        return builder;
    }

    public static IConfigurationBuilder AddProject(this IConfigurationBuilder builder, ProjectConfig projectConfig)
    {
        builder.AddJsonFile($"appsettings.{ConfigHelper.Runtime}.{projectConfig.ToString()}.json", true, true);
        return builder;
    }
    
    public static IConfigurationBuilder AddProjects(this IConfigurationBuilder builder, params ProjectConfig[] projectConfigs)
    {
        foreach (var config in projectConfigs)
            builder.AddProject(config);
        
        return builder;
    }
}
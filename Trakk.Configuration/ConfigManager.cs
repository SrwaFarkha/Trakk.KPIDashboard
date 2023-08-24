using Microsoft.Extensions.Configuration;
using Trakk.Configuration.Extensions;

namespace Trakk.Configuration;

public enum ProjectConfig
{
    Api,
    Server,
    Services,
    Manager
}

public class ConfigManager
{
    private static ConfigManager? _instance;

    public ConfigManager(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    /// <summary>
    ///     ConfigManager singleton.
    /// </summary>
    /// <exception cref="NullReferenceException">ConfigManager has not been initialized.</exception>
    public static ConfigManager Instance =>
        _instance ?? throw
            new NullReferenceException($"{nameof(ConfigManager)} has not been initialized. " +
                                       $"Use '{nameof(ConfigManager)}.{nameof(Setup)}' " +
                                       $"to initialize '{nameof(ConfigManager)}.{nameof(Instance)}'");

    public string? this[string key] => Configuration[key];

    public IConfiguration Configuration { get; }

    /// <summary>
    ///     Tries to map a section as TModel
    /// </summary>
    /// <param name="sectionKey">key of model</param>
    /// <typeparam name="TModel">model</typeparam>
    /// <returns>TModel or null.</returns>
    public TModel? Get<TModel>(string sectionKey)
    {
        return Configuration.GetSection(sectionKey).Get<TModel>();
    }

    public string GetConnectionString(string key)
    {
        return Configuration.GetConnectionString(key)??"";
    }

    /// <summary>
    ///     Calls Get(nameof(TModel)) use this if sectionKey is the same name as TModel.
    /// </summary>
    /// <typeparam name="TModel">model</typeparam>
    /// <returns>TModel or null.</returns>
    public TModel? Get<TModel>()
    {
        return Get<TModel>(typeof(TModel).Name);
    }

    /// <summary>
    ///     Dumps all the current loaded entries as a they would appear in a appsettings.json file.
    /// </summary>
    /// <returns>current configuration json</returns>
    public string Dump()
    {
        return ConfigHelper.Dump(Configuration);
    }

    /// <summary>
    ///     Calls Setup(string name) with environment variable 'TargetConfiguration'.
    /// </summary>
    /// <remarks>falls back to Assembly project name if not found.</remarks>
    public static void Setup()
    {
        Setup(ConfigHelper.Project);
    }
    
    /// <summary>
    ///     Loads 'appsetting.json', 'appsettings.RuntimeConfiguration.json', 'appsettings.RuntimeConfiguration.project.json'
    /// </summary>
    /// <param name="project">project name to load.</param>
    public static void Setup(ProjectConfig project) => Setup(project.ToString());

    /// <summary>
    ///     Loads 'appsetting.json', 'appsettings.RuntimeConfiguration.json', 'appsettings.RuntimeConfiguration.project.json'
    /// </summary>
    /// <param name="project">project name to load.</param>
    public static void Setup(string project)
    {
        Setup(x => x
            .SetBasePath(ConfigHelper.FolderPath)
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{ConfigHelper.Runtime}.json", true, true)
            .AddJsonFile($"appsettings.{ConfigHelper.Runtime}.{project}.json", true, true)
            .AddEnvironmentVariables("TRAKK_")
            .AddAllJsonIn(ConfigHelper.OverridePath)
        );
    }

    /// <summary>
    ///     Loads configuration and assigns it to 'Instance'.
    /// </summary>
    /// <param name="configure">Configure method</param>
    public static void Setup(Action<IConfigurationBuilder> configure)
    {
        var builder = new ConfigurationBuilder();
        configure(builder);
        _instance = new ConfigManager(builder.Build());
    }

    public static void SetupAll()
    {
        Setup(x => x
            .SetBasePath(ConfigHelper.FolderPath)
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{ConfigHelper.Runtime}.json", true, true)
            .AddJsonFile($"appsettings.{ConfigHelper.Runtime}.{ProjectConfig.Server.ToString()}.json", true, true)
            .AddJsonFile($"appsettings.{ConfigHelper.Runtime}.{ProjectConfig.Api.ToString()}.json", true, true)
            .AddJsonFile($"appsettings.{ConfigHelper.Runtime}.{ProjectConfig.Manager.ToString()}.json", true, true)
            .AddEnvironmentVariables("TRAKK_")
            .AddAllJsonIn(ConfigHelper.OverridePath)
        );
    }
}
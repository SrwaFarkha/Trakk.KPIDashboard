using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;

namespace Trakk.Utils.Helpers.Logging;

public static class LoggerHelper
{
    
    private static ILoggerFactory? _Factory;

    public static ILoggerFactory ConfigureLogger(ILoggerFactory? factory = null) =>
        _Factory = factory ?? new NLogLoggerFactory();
 

    public static ILoggerFactory LoggerFactory => _Factory ??= ConfigureLogger();
    public static ILogger<T> CreateLogger<T>() => LoggerFactory.CreateLogger<T>();
}
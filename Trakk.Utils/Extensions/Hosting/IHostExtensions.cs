using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Trakk.Utils.Extensions.Hosting;

public static class HostExtensions
{
    /// <summary>
    /// Extension for cleaner access to 'Services.GetRequiredService()'
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IHost SetupService<T>(this IHost host, Action<T> func) where T : notnull
    {
        func(host.Services.GetRequiredService<T>());
        return host;
    }
    /// <summary>
    /// Extension for cleaner async access to 'Services.GetRequiredService()'
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IHost SetupServiceAsync<T>(this IHost host, Func<T,Task> func) where T : notnull
    {
        func(host.Services.GetRequiredService<T>()).Wait();
        return host;
    }
}
namespace Trakk.Configuration.Models;

public class RabbitOptions
{ 
    public string Username { get; set; } = "guest";
    public string Password { get; set; } = "guest";
    public string ConnectionString { get; set; } = "localhost";
    public int RetryCount { get; set; } = 3;
    public Dictionary<string, int> MaxConcurrent { get; set; } = new Dictionary<string, int> { { "default", 5 } };
    public ushort Prefetch { get; set; } = 20;
    public string ClientName { get; set; } = AppDomain.CurrentDomain.FriendlyName;
    public string PropsPrefix { get; set; } = "";
    public static RabbitOptions Default => new();

    public int GetMaxConcurrent(string queueName)
    {
        if (MaxConcurrent.TryGetValue(queueName, out var concurrent))
            return concurrent;
        
        return MaxConcurrent.TryGetValue("default", out var defaultConcurrent) ? defaultConcurrent : 1;
    }
}
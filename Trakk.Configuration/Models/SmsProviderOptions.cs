namespace Trakk.Configuration.Models;

public class SmsProviderOptions
{
    public string Name { get; set; }
    public string Key {get;set;} 
    public string Secret {get;set;}
    public string BaseAddress {get;set;}
}
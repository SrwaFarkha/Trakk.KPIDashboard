namespace Trakk.Configuration.Models;

public enum ServerType
{
    Tcp,
    Mqtt
}

public enum MqttType
{
    Netmore,
    Helium,
    Yggio
}
public enum TcpServerType
{
    Default,
    Taggr
}
public class TcpSetting
{
    public string Alias { get; set; }
    public int Port { get; set; }
    public TcpServerType Type { get; set; }
}

public class TcpSettings
{
    public List<TcpSetting> Settings { get; set; }
}

public class MqttSettings
{
    public List<MqttSetting> Settings { get; set; }

}

public class MqttSetting
{
    public MqttType Type { get; set; }
    public string Topic { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string ClientId { get; set; }
    public string TcpIp { get; set; }
    public int TcpPort { get; set; }
    public string ApiUrl { get; set; }
    public string ApiUsername { get; set; }
    public string ApiPassword { get; set; }


}
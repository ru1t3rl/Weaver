namespace Weaver.AppHost;

public class WebAppConfiguration
{
    public const string Key = "WebApp";
    
    public string AppEnvPrefix { get; init; } = "WEAVER_";
}
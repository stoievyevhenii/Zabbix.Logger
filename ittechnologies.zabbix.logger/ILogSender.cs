using ItTechnologies.Zabbix.Logger.Models;

namespace ItTechnologies.Zabbix.Logger
{
    public interface ILogSender
    {
        LogSender InitConnection(ServerConfigurations config);

        Task<bool> LogAsync(string value, string logLevel);
    }
}
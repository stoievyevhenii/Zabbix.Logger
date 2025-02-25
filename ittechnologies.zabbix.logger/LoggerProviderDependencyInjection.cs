using ItTechnologies.Zabbix.Logger.Models;

using Microsoft.Extensions.DependencyInjection;

namespace ItTechnologies.Zabbix.Logger
{
    public static class LoggerProviderDependencyInjection
    {
        public static void AddZabbixLogger(this IServiceCollection services)
        {
            services.AddSingleton<ILogSender, LogSender>();
        }

        public static void AddZabbixLogger(this IServiceCollection services, ServerConfigurations serverConfigurations)
        {
            services.AddSingleton<ILogSender>(new LogSender(serverConfigurations));
        }
    }
}
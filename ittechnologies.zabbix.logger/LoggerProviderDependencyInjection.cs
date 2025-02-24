using Microsoft.Extensions.DependencyInjection;

namespace ItTechnologies.Zabbix.Logger
{
    public static class LoggerProviderDependencyInjection
    {
        public static void AddZabbixLogger(this IServiceCollection services)
        {
            services.AddSingleton<ILogSender, LogSender>();
        }
    }
}
using ItTechnologies.Zabbix.Logger.Models;

using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ItTechnologies.Zabbix.Logger
{
    public class LogSender : ILogSender
    {
        private HttpClient _httpClient = new();

        private Request _request = new();

        private JsonSerializerOptions _serializeOptions = new();

        public LogSender()
        {
        }

        public LogSender(ServerConfigurations config)
        {
            InitConnection(config);
        }

        public LogSender InitConnection(ServerConfigurations config)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(config.Url + "/api_jsonrpc.php"),
                DefaultRequestHeaders = {
                    Authorization = new AuthenticationHeaderValue("Bearer", config.ApiKey)
                }
            };

            _request = new()
            {
                Params = [
                    new Params
                    {
                        Host = config.Host
                    }
                ]
            };

            _serializeOptions = new()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = false
            };

            return this;
        }

        public async Task<bool> LogAsync(string value, string logLevel)
        {
            _request.Params[0].Value = value;
            _request.Params[0].Key = logLevel;

            return await SendAsync(_request);
        }

        private async Task<bool> SendAsync(Request request)
        {
            var jsonContent = JsonSerializer.Serialize(request, _serializeOptions);
            var response = await _httpClient
                .PostAsync("", new StringContent(jsonContent, Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
            return true;
        }
    }
}
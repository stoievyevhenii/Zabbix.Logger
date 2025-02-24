namespace ItTechnologies.Zabbix.Logger.Models
{
    internal class Request
    {
        public string Jsonrpc { get; set; } = "2.0";
        public string Method { get; set; } = "history.push";
        public Params[] Params { get; set; } = [];
    }
}
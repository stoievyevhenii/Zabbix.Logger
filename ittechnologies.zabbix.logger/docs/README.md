# Zabbix Logging Interface

## Overview

The Zabbix Logging Interface is a NuGet library designed to facilitate the logging of data to a Zabbix server. This library provides a simple and efficient way to send log messages from your .NET applications to a Zabbix server for monitoring and alerting.

## ZABBIX configuration

First of all , you need to configure the Zabbix server to receive logs from the Zabbix Logging Interface. How to do this is described in the [Stackverflow question](https://stackoverflow.com/questions/21938132/log-exceptions-from-net-application-to-zabbix).

## Usage

Here's a basic example of how to use the Zabbix Logging Interface:

### Register DI service

```csharp
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddOpenApi();
            builder.Services.AddZabbixLogger();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
```

OR

```csharp
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddOpenApi();
            builder.Services.AddZabbixLogger(new ServerConfigurations()
            {
                ApiKey = "XXXXXXXXXXX",
                Host = "LogStore",
                Url = "https://zabbix.personalservices.com"
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
```


### Usage
```csharp
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var zabbixServerConfiguration = new ServerConfigurations
        {
            ApiKey = "XXXXXXXXXXX",
            Host = "LogStore",
            Url = "https://zabbix.personalservices.com"
        };

        var result = await _logSender
            .InitConnection(zabbixServerConfiguration)
            .LogAsync("Test from DI", LogLevelValues.Information);

        return Ok(result);
    }
```

### LogLevelValues class
Default values for log level. You can pass every Item name, which was created in Zabbix server.
```csharp
    public static class LogLevelValues
    {
        public const string Information = "Information";
        public const string Warning = "Warning";
        public const string Error = "Error";
        public const string Debug = "Debug";
        public const string Critical = "Critical";
    }
```

## Configuration

You can customize the Zabbix logger configuration by modifying the `ServerConfigurations` object. Here are some of the available settings:

- `ApiKey`: The API key of your Zabbix server.
- `Host`: The host name for log store
- `Url`: The name of the host on the Zabbix server.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.

## Contributing

Contributions are welcome! Please feel free to submit issues or pull requests to improve the library.

## Contact

For any questions or inquiries, please contact [y.stoiev@it-technologies.com.ua](mailto:y.stoiev@it-technologies.com.ua).

---

Let me know if you need any additional changes!
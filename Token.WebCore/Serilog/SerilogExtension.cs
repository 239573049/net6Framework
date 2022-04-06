using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;

namespace Management.WebCore.Serilog;

public static class SerilogExtension
{
    public static IServiceCollection AddSerilog(this IServiceCollection services)
    {
        Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Information()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                    .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "/log/", "log"),rollingInterval:RollingInterval.Day)
                    .ReadFrom.Configuration(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build())
                    .CreateLogger();
        services.AddSingleton(Log.Logger);
        return services;
    }
}

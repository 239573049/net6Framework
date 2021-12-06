using Autofac.Extensions.DependencyInjection;
using System.Security.Authentication;

namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(kestrelOptions =>
                    {
                        kestrelOptions.Limits.MaxRequestBodySize = 50 * 1024 * 1024;
                        kestrelOptions.ConfigureHttpsDefaults(s => s.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls13);
                    });
                    webBuilder.UseStartup<Startup>();
                    if (args.Length > 0)
                    {
                        webBuilder.UseUrls(args[0]);
                    }
                });
    }
}
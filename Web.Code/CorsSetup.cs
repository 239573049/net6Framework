using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Web.Code
{
    public static class CorsSetup
    {
        public static void AddCorsSetup(this IServiceCollection service)
        {
            if (service == null)
            {
                throw new ArgumentNullException("service");
            }
            service.AddCors(delegate (CorsOptions options)
            {
                options.AddPolicy("CorsSetup", delegate (CorsPolicyBuilder corsBuilder)
                {
                    corsBuilder.SetIsOriginAllowed((string _) => true).AllowAnyMethod().AllowAnyHeader()
                        .AllowCredentials();
                });
            });
        }
    }
}
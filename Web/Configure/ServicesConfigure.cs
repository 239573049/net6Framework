using Web.Global;
using Util;
using Web.Code;

namespace Web.Configure
{
    public class ServicesConfigure
    {
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="env"></param>
        public static void Configure(IServiceCollection services, IWebHostEnvironment env)
        {
            services.AddSingleton(new AppSettings(env.ContentRootPath));
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddCorsSetup();
            services.AddControllers(o =>
            {
                o.Filters.Add(typeof(GlobalExceptionsFilter));
                o.Filters.Add(typeof(GlobalResponseFilter));
                o.Filters.Add(typeof(GlobalModelStateValidationFilter));
            });

        }
    }
}

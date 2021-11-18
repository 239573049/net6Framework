﻿using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Core;
using Repository.Repositorys;
using System.Reflection;
using Web.Global;

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
            services.AddDbContext<MasterDbContext>(option =>option.UseMySql(AppSettings.App("mysqll"),new MySqlServerVersion(new Version(5,7,29))));
            services.AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddTransient(typeof(IMasterDbRepositoryBase<,>), typeof(MasterDbRepositoryBase<,>));
            services.AddControllers();
            services.AddSwaggerSetup("1", "Web Api", "Web API", new SwaggerSetup.Contact { Email = "239573049@qq.com", Name = "XiaoHu", Url = new Uri("https://gitee.com/hejiale010426") });
            services.AddAutoMapper(new List<Assembly> {Assembly.Load("Service"), Assembly.Load("Web.Code") });
            services.AddEndpointsApiExplorer();
            services.AddCors(delegate (CorsOptions options)
            {
                options.AddPolicy("CorsSetup", delegate (CorsPolicyBuilder corsBuilder)
                {
                    corsBuilder.SetIsOriginAllowed((string _) => true).AllowAnyMethod().AllowAnyHeader()
                        .AllowCredentials();
                });
            });
            services.AddControllers(o =>
            {
                o.Filters.Add(typeof(GlobalExceptionsFilter));
                o.Filters.Add(typeof(GlobalResponseFilter));
                o.Filters.Add(typeof(GlobalModelStateValidationFilter));
            });

        }
    }
}

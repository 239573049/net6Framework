﻿using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Core;
using Repository.Repositorys;
using System.Reflection;
using Util;
using Web.Global;
using static Web.Configure.SwaggerSetup;

namespace Web.Configure
{
    /// <summary>
    /// 
    /// </summary>
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
            services.AddSingleton<IRedis, Redis>();//Ioc控制反转
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IPrincipalAccessor, PrincipalAccessor>();
            services.AddDbContext<MasterDbContext>(option => option.UseSqlServer(AppSettings.App("sqlservice")));
            //services.AddDbContext<MasterDbContext>(option => option.UseMySql(AppSettings.App("mysql"), new MySqlServerVersion(new Version(5, 0, 26))));
            services.AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddTransient(typeof(IMasterDbRepositoryBase<,>), typeof(MasterDbRepositoryBase<,>));
            services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);//禁止不可为空的引用类型和必须属性
            services.AddSwaggerSetup("1", "Web Api", "Web API", new Contact { Email = "239573049@qq.com", Name = "XiaoHu", Url = new Uri("https://gitee.com/hejiale010426") });
            services.AddAutoMapper(new List<Assembly> { Assembly.Load("Service"), Assembly.Load("Web.Code") });
            RedisHelper.Initialization(new CSRedis.CSRedisClient(AppSettings.App("redis")));//redis工具
            services.AddSignalR().AddRedis(AppSettings.App("redis"));
            services.AddEndpointsApiExplorer();
            services.AddCors(delegate (CorsOptions options)
            {
                options.AddPolicy("CorsPolicy", delegate (CorsPolicyBuilder corsBuilder)
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

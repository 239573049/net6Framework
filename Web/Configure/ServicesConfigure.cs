using MessagePack;
using Microsoft.AspNetCore.Cors.Infrastructure;
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
            services.AddSingleton<IRedis, Redis>();
            services.AddDbContext<MasterDbContext>(option =>option.UseMySql(AppSettings.App("mysql"),new MySqlServerVersion(new Version(6,0,0))));
            services.AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddTransient(typeof(IMasterDbRepositoryBase<,>), typeof(MasterDbRepositoryBase<,>));
            services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);//禁止不可为空的引用类型和必须属性
            services.AddSwaggerSetup("1", "Web Api", "Web API", new SwaggerSetup.Contact { Email = "239573049@qq.com", Name = "XiaoHu", Url = new Uri("https://gitee.com/hejiale010426") });
            services.AddAutoMapper(new List<Assembly> {Assembly.Load("Service"), Assembly.Load("Web.Code") });
            RedisHelper.Initialization(new CSRedis.CSRedisClient(AppSettings.App("redis")));
            services.AddSignalR(a =>
            {
                a.MaximumReceiveMessageSize = 60 * 1024 * 1024;//传输大小
            })
                .AddMessagePackProtocol()//启用传输协议
                .AddRedis(AppSettings.App("redis"));
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

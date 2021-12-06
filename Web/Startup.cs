using Autofac;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Core;
using Repository.Repositorys;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using Util;
using Web.Code.ChatHubs;
using Web.Configure;
using Web.Global;
using static Web.Configure.SwaggerSetup;

namespace Web
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 人口
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="env"></param>
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        /// <summary>
        /// appsettings文件
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        ///
        /// </summary>
        public IWebHostEnvironment Env { get; }
        /// <summary>
        ///
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(new AppSettings(Env.ContentRootPath));
            services.AddSingleton<IRedis, Redis>();//Ioc控制反转
            services.AddSingleton<IPrincipalAccessor, PrincipalAccessor>();
            services.AddDbContext<MasterDbContext>(option => option.UseMySql(AppSettings.App("mysql"), new MySqlServerVersion(new Version(5, 0, 26))));
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

        /// <summary>
        /// 管道
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="log"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory log)
        {
            if (app == null) throw new Exception("WebApplication is NUll");

            app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/1/swagger.json", "Web Api");
                c.DocExpansion(DocExpansion.None);
                c.DefaultModelsExpandDepth(-1);
            });
            app.UseCors("CorsPolicy");//CORS strategy
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("chatHub");
            });
        }

        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;

            var servicesDllFile = Path.Combine(basePath, "Service.dll");//需要依赖注入的项目生成的dll文件名称
            var repositoryDllFile = Path.Combine(basePath, "Repository.dll");
            var assemblysServices = Assembly.LoadFrom(servicesDllFile);
            builder.RegisterAssemblyTypes(assemblysServices)
                .Where(x => x.FullName!=null&& x.FullName.EndsWith("Service"))//对比名称最后是否相同然后注入
                      .AsImplementedInterfaces()
                      .InstancePerDependency();
            var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
            builder.RegisterAssemblyTypes(assemblysRepository)
                .Where(x => x.FullName!=null&& x.FullName.EndsWith("Repository"))
                      .AsImplementedInterfaces()
                      .InstancePerDependency();
        }

    }
}

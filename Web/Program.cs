using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MongoDBRepository.Repositorys;
using Repository;
using Repository.Core;
using Repository.Repositorys;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using Util;
using Web.Code.ChatHubs;
using Web.Global;
using static Web.Global.SwaggerSetup;

var builder = WebApplication.CreateBuilder(args);
#region service
var services = builder.Services;
services.AddSingleton(new AppSettings(builder.Environment.ContentRootPath));
services.AddSingleton<IRedis, Redis>();//Ioc控制反转
services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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
    options.AddPolicy("CorsPolicy", corsBuilder=>
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
#endregion

#region 依赖注入
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());//覆盖用于创建服务提供者的工厂
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>//依赖注入
{
    var basePath = AppDomain.CurrentDomain.BaseDirectory;

    var servicesDllFile = Path.Combine(basePath, "Service.dll");//需要依赖注入的项目生成的dll文件名称
    var repositoryDllFile = Path.Combine(basePath, "Repository.dll");
    var mongoDBRepositoryDllFile = Path.Combine(basePath, "MongoDBRepository.dll");
    var assemblysServices = Assembly.LoadFrom(servicesDllFile);
    containerBuilder.RegisterAssemblyTypes(assemblysServices)
        .Where(x => x.FullName != null && x.FullName.EndsWith("Service"))//对比名称最后是否相同然后注入
              .AsImplementedInterfaces()
              .InstancePerDependency();
    var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
    containerBuilder.RegisterAssemblyTypes(assemblysRepository)
        .Where(x => x.FullName != null && x.FullName.EndsWith("Repository"))
              .AsImplementedInterfaces()
              .InstancePerDependency();
    var assemblysmongoDBRepository = Assembly.LoadFrom(mongoDBRepositoryDllFile);
    containerBuilder.RegisterAssemblyTypes(assemblysmongoDBRepository)
        .Where(x => x.FullName != null && x.FullName.EndsWith("Repository"))
              .AsImplementedInterfaces()
              .InstancePerDependency();
    containerBuilder.RegisterType<MongoDBContext>()
                .As<MongoDBContext>();
});
#endregion

#region App
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseRouting();
app.UseStaticFiles();
app.MapControllers();
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
app.Run();//Run App
#endregion
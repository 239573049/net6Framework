using Autofac;
using Autofac.Extensions.DependencyInjection;
using Management.WebCore.Serilog;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MongoDBRepository.Repositorys;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using Token.EntityFrameworkCore;
using Token.EntityFrameworkCore.Core;
using Token.EntityFrameworkCore.Repositorys;
using Token.Infrastructure;
using Token.PCWebApi.Global;
using Token.WebCore.ChatHubs;
using static Token.PCWebApi.Global.SwaggerSetup;

var builder = WebApplication.CreateBuilder(args);
#region service
var services = builder.Services;
services.AddSerilog()
    .AddSingleton(new AppSettings(builder.Environment.ContentRootPath))
    .AddSingleton<IRedis, Redis>()//Ioc���Ʒ�ת
    .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
    .AddSingleton<IPrincipalAccessor, PrincipalAccessor>()
    .AddDbContext<MasterDbContext>(option => option.UseMySql(AppSettings.App("mysql"), new MySqlServerVersion(new Version(5, 0, 26))))
    .AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>))
    .AddTransient(typeof(IMasterDbRepositoryBase<,>), typeof(MasterDbRepositoryBase<,>))
    .AddSwaggerSetup("1", "Web Api", "Web API", new Contact { Email = "239573049@qq.com", Name = "Token", Url = new Uri("https://gitee.com/hejiale010426") })
    .AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
services.AddAutoMapper(new List<Assembly> { Assembly.Load("Token.Application"), Assembly.Load("Token.WebCore") });
RedisHelper.Initialization(new CSRedis.CSRedisClient(AppSettings.App("redis")));//redis����
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

#region ����ע��
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());//�������ڴ��������ṩ�ߵĹ���
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>//����ע��
{
    var basePath = AppDomain.CurrentDomain.BaseDirectory;

    var servicesDllFile = Path.Combine(basePath, "Token.Application.dll");//��Ҫ����ע�����Ŀ���ɵ�dll�ļ�����
    var repositoryDllFile = Path.Combine(basePath, "Token.EntityFrameworkCore.dll");
    var mongoDBRepositoryDllFile = Path.Combine(basePath, "Token.MongoDBRepository.dll");
    var assemblysServices = Assembly.LoadFrom(servicesDllFile);
    containerBuilder.RegisterAssemblyTypes(assemblysServices)
        .Where(x => x.FullName != null && x.FullName.EndsWith("Service"))//�Ա���������Ƿ���ͬȻ��ע��
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
if (app.Environment.IsDevelopment())//����ģʽ
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/1/swagger.json", "Web Api");
        c.DocExpansion(DocExpansion.None);
        c.DefaultModelsExpandDepth(-1);
    });
}
app.UseRouting();
app.UseStaticFiles();
app.MapControllers();
app.UseCors("CorsPolicy");//CORS strategy
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<ChatHub>("chatHub");
});
app.Run();//Run App
#endregion
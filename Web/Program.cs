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
services.AddSingleton<IRedis, Redis>();//Ioc���Ʒ�ת
services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
services.AddSingleton<IPrincipalAccessor, PrincipalAccessor>();
services.AddDbContext<MasterDbContext>(option => option.UseMySql(AppSettings.App("mysql"), new MySqlServerVersion(new Version(5, 0, 26))));
services.AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
services.AddTransient(typeof(IMasterDbRepositoryBase<,>), typeof(MasterDbRepositoryBase<,>));
services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);//��ֹ����Ϊ�յ��������ͺͱ�������
services.AddSwaggerSetup("1", "Web Api", "Web API", new Contact { Email = "239573049@qq.com", Name = "XiaoHu", Url = new Uri("https://gitee.com/hejiale010426") });
services.AddAutoMapper(new List<Assembly> { Assembly.Load("Service"), Assembly.Load("Web.Code") });
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

    var servicesDllFile = Path.Combine(basePath, "Service.dll");//��Ҫ����ע�����Ŀ���ɵ�dll�ļ�����
    var repositoryDllFile = Path.Combine(basePath, "Repository.dll");
    var mongoDBRepositoryDllFile = Path.Combine(basePath, "MongoDBRepository.dll");
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
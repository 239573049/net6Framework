using Autofac;
using Autofac.Extensions.DependencyInjection;
using System.Reflection;

namespace Web.Configure
{
    public class ContainerConfigure
    {
        /// <summary>
        /// 容器
        /// </summary>
        /// <param name="host"></param>
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());//覆盖用于创建服务提供者的工厂
            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>//依赖注入
            {
                var basePath = AppDomain.CurrentDomain.BaseDirectory;

                var servicesDllFile = Path.Combine(basePath, "Service.dll");
                
                var assemblysServices = Assembly.LoadFrom(servicesDllFile);
                containerBuilder.RegisterAssemblyTypes(assemblysServices)
                    .Where(x => x.FullName.EndsWith("Service"))
                          .AsImplementedInterfaces()
                          .InstancePerDependency();
            });
        }
    }
}

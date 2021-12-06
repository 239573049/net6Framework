using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Reflection;

namespace Service.Services
{
    public interface IRouteReflectionService
    {
        /// <summary>
        /// 获取Controller的所有接口，请使用[Description("")]才能获取到接口的注释
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        Task<List<PathTree>> GetPathAll();
    }
    public class RouteReflectionService : IRouteReflectionService
    {
        public RouteReflectionService(
            )
        { 
        }
        public async Task<List<PathTree>> GetPathAll()
        {
            var result = new List<PathTree>();
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var WebDllFile = Path.Combine(basePath, "Web.dll");//Controller所在的dll
            var assemblysServices = Assembly.LoadFrom(WebDllFile);
            foreach (var d in assemblysServices.GetTypes().Where(a => a.Name.EndsWith("Controller")).ToList())
            {
                var name = d.Name.Replace("Controller", "");
                var pathTree = new PathTree
                {
                    Name = name,
                    Description = d.GetCustomAttribute<DescriptionAttribute>()?.Description,
                    Path = "/api/" + d.Name
                };
                try
                {
                    ///过滤继承类的方法
                    var classData = d.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public).Select(a=>new PathTree
                    {
                        Name=a.Name,
                        Path= "/api/" + name + "/" + a.Name,
                        Description= a.GetCustomAttribute<DescriptionAttribute>()?.Description,
                        parentId = name
                    }).ToList();
                    pathTree.Children.AddRange(classData);
                    result.Add(pathTree);
                }
                catch (Exception)
                {
                }
            }
            return result;
        }
    }
    public class Swagger
    {
        public JObject Paths { get; set; }
        public List<Tags> Tags { get; set; } = new List<Tags>();
    }
    public class Tags
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// 注释
        /// </summary>
        public string? Description { get; set; }
    }

    public class PathTree
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Path { get; set; }
        public string? parentId { get; set; }
        public List<PathTree> Children { get; set; } = new List<PathTree>();
    }
}

using System.ComponentModel;
using System.Reflection;

namespace Util
{
    public class RouteReflection
    {
        /// <summary>
        /// 获取所有接口
        /// </summary>
        /// <returns></returns>
        public static List<PathTree> GetPathAll()
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
                    Path = "/api/" + name
                };
                if (string.IsNullOrEmpty(pathTree.Description)) continue;
                var classData = d.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public).Select(a => new PathTree
                {
                    Name = a.Name,
                    Path = "/api/" + name + "/" + a.Name,
                    Description = a.GetCustomAttribute<DescriptionAttribute>()?.Description,
                    ParentId = name
                }).ToList();
                pathTree.Children.AddRange(classData);
                result.Add(pathTree);
            }
            return result;
        }
    }
    public class PathTree
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Path { get; set; }
        public string? ParentId { get; set; }
        public List<PathTree> Children { get; set; } = new List<PathTree>();
    }
}

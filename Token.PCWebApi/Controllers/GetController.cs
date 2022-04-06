using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using Token.Infrastructure;
using Token.WebCore;

namespace Token.PCWebApi.Controllers
{
    /// <summary>
    /// 获取所有接口
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Description("获取所有接口")]
    [Authorization]
    public class GetController : ControllerBase
    {
        /// <summary>
        /// 获取全部接口树形和注释
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Description("获取全部接口树形和注释")]
        public List<PathTree> GetPathAll()
        {
            return RouteReflection.GetPathAll();
        }
    }
}

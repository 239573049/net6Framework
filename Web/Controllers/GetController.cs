using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using Util;
using Web.Code;

namespace Web.Controllers
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
        public GetController(
            )
        {
        }
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

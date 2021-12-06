using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using System.ComponentModel;

namespace Web.Controllers
{
    /// <summary>
    /// 获取所有接口
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Description("获取所有接口")]
    public class GetController : ControllerBase
    {
        private readonly IRouteReflectionService _routeReflectionService;
        public GetController(
            IRouteReflectionService routeReflectionService
            )
        {
            _routeReflectionService = routeReflectionService;
        }
        /// <summary>
        /// 获取全部接口树形和注释
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Description("获取全部接口树形和注释")]
        public async Task<List<PathTree>> GetPathAll()
        {
            return await _routeReflectionService.GetPathAll();
        }
    }
}

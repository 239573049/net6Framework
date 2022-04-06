using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Token.WebCore;

namespace Token.PCWebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorization]
    public class HelperController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Log()
        {
            return "";
        }
    }
}

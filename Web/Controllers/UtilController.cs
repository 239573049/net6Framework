using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Code;

namespace Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorization]
    public class UtilController : ControllerBase
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

using Microsoft.AspNetCore.Mvc;
using Service;

namespace Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IDataService _dataService;
        public ServiceController(
            IDataService dataService
            )
        {
            _dataService = dataService;
        }
        /// <summary>
        /// Get test data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<string> GetData()
        {
            return _dataService.GetData();
        }
    }
}

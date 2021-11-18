using Service.Dto;
using Service.Services;

namespace Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(
            IUserService userService
            )
        {
            _userService = userService;
        }
        /// <summary>
        /// 添加好友
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Guid> CreateUser(UserDto user)
        {
            return await _userService.CreateUser(user);
        }
    }
}

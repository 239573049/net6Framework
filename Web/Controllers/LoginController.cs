using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using Util;
using Web.Code;
using Web.Code.ModelVM;

namespace Web.Controllers
{
    /// <summary>
    /// 登录模块
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : WebController
    {
        private readonly IRedis _redis;
        private readonly IUserService _userService;
        public LoginController(
            IRedis redis,
            IUserService userService
            )
        {
            _redis = redis;
            _userService =userService; 
        }
        /// <summary>
        /// 登录接口
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(string user,string pass)
        {
            var userData=await _userService.GetUserDto(user);
            if (userData.Password != pass) return new ModelStateResult("账号或者密码错误", 400);
            var token = Guid.NewGuid().ToString()+Guid.NewGuid();
            await _redis.SetAsync(token,userData, DateTime.Now.AddMinutes(30));
            return new OkObjectResult(new { user= userData,token});
        }
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> ExitLogin()
        {
            _ = await _redis.DeleteAsync(UserToken);
            return new OkObjectResult("退出成功");
        }
        /// <summary>
        /// 刷新登录时间
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Refresh()
        {
            await _redis.SetDateAsync(UserToken, DateTime.Now.AddMinutes(30));
            return new OkObjectResult("刷新成功");
        }
    }
}

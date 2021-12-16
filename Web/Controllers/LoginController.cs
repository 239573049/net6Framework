using Microsoft.AspNetCore.Mvc;
using Service.Services;
using System.ComponentModel;
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
    [Description("登录模块")]
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
        [Description("登录接口")]
        public async Task<IActionResult> Login(string user,string pass)
        {
            var userData=await _userService.GetUserDto(user, pass);
            var token = StringUtil.GetString(130) ;
            await _redis.SetAsync(token,userData, DateTime.Now.AddMinutes(30));
            return new OkObjectResult(new { user= userData,token});
        }
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Description("退出登录")]
        public async Task<IActionResult> ExitLogin()
        {
            var res = await _redis.DeleteAsync(UserToken);
            if (!res) return new ModelStateResult("退出失败", 400);
            return new OkObjectResult("退出成功");
        }
        /// <summary>
        /// 刷新登录时间
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Description("刷新登录时间")]
        public async Task<IActionResult> Refresh()
        {
            var res = await _redis.SetDateAsync(UserToken, DateTime.Now.AddMinutes(30));
            if (!res) return new ModelStateResult("刷新登陆时间失败", 400);
            return new OkObjectResult("刷新成功");
        }
    }
}

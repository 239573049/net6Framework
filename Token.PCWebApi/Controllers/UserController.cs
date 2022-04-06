using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using Token.Application.Dto;
using Token.Application.Services;

namespace Token.PCWebApi.Controllers
{
    /// <summary>
    /// 用户模块
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Description("用户模块")]
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
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("添加用户")]
        public async Task<Guid> CreateUser(UserDto user)
        {
            return await _userService.CreateUser(user);
        }
        /// <summary>
        /// 通过名称搜索用户
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Description("通过名称搜索用户")]
        public async Task<List<UserDto>> GetAllUsers(string name)
        {
            return await _userService.GetAllUsers(name);
        }
    }
}

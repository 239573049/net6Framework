using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using Token.Application.Dto;
using Token.Infrastructure;

namespace Token.WebCore
{
    /// <summary>
    /// 只有配置这个注解才会验证路由权限
    /// 不使用注解就相当于都可以访问不做权限处理
    /// </summary>
    public class AuthorizationAttribute : ActionFilterAttribute
    {
        public AuthorizationAttribute()
        {

        }
        /// <summary>
        /// 权限拦截
        /// </summary>
        /// <param name="httpContext"></param>
        [DebuggerStepThrough]//调试不进入
        public override void OnActionExecuting(ActionExecutingContext httpContext)
        {
            string authorization = httpContext.HttpContext.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(authorization)) throw new BusinessLogicException(401, "请先登录账号");
            var path = httpContext.HttpContext.Request.Path.Value;
            var userDto = RedisHelper.Get<UserDto>(authorization);
            if (userDto == null) throw new BusinessLogicException(401, "请先登录账号");
            if (userDto.RoleFunctions.Any(a => path!.Contains(a!.Route!))) return;//存在就跳出
            throw new BusinessLogicException(403,"权限不足");
        }

    }
}

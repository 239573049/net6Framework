using Core.Entitys;
using Microsoft.AspNetCore.Mvc.Filters;
using Service.Dto;
using Util;

namespace Web.Code
{
    public class AuthorizationAttribute : ActionFilterAttribute
    {
        private PowerEnum? _power;
        public AuthorizationAttribute(PowerEnum? power)
        {
            _power = power;
        }
        /// <summary>
        /// 权限拦截
        /// </summary>
        /// <param name="httpContext"></param>
        public override void OnActionExecuting(ActionExecutingContext httpContext)
        {
            string authorization = httpContext.HttpContext.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(authorization)) throw new BusinessLogicException(401, "请先登录账号");
            var path = httpContext.HttpContext.Request.Path.Value;
            var userDto = new Redis().Get<UserDto>(authorization);
            if (userDto == null) throw new BusinessLogicException(401, "请先登录账号");
            if (_power != null)
            {
                if ((sbyte)userDto.Status>(sbyte)_power)
                {
                    throw new BusinessLogicException(403, $"您没有权限访问{path}接口！");
                }
            }
        }

    }
}

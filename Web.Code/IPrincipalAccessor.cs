using Microsoft.AspNetCore.Http;

namespace Web.Code
{
    public interface IPrincipalAccessor
    {
        /// <summary>
        /// 获取用户id
        /// </summary>
        /// <returns></returns>
        Guid? GetId();
        /// <summary>
        /// 获取令牌
        /// </summary>
        /// <returns></returns>
        string GetToken();
    }
    public class PrincipalAccessor : IPrincipalAccessor
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public PrincipalAccessor(
            IHttpContextAccessor contextAccessor
            )
        {
            _contextAccessor = contextAccessor;
        }

        public Guid? GetId()
        {
            var id = _contextAccessor.HttpContext.Request.Cookies["id"]==null?"": _contextAccessor.HttpContext.Request.Cookies["id"].ToString();
            return string.IsNullOrEmpty(id) ? null : Guid.Parse(id);
        }

        public  string GetToken()
        {
            return _contextAccessor.HttpContext.Request.Headers["Authorization"].ToString();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Util;

namespace Web.Code
{
    public class WebController: ControllerBase
    {
        public string UserToken { get
            {
                var token= HttpContext.Request.Headers["Authorization"].ToString();
                if (string.IsNullOrEmpty(token)) throw new BusinessLogicException(401,"请先登录");
                return token!;
            } }
    }
}

using Microsoft.AspNetCore.Mvc;
using Token.Infrastructure;

namespace Token.WebCore
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

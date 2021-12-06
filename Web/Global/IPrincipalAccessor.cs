namespace Web.Global
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPrincipalAccessor
    {

        /// <summary>
        /// 获取请求头Token
        /// </summary>
        /// <returns></returns>
        string? GetToken();

        /// <summary>
        /// 获取当前cookie用户id
        /// </summary>
        /// <returns></returns>
        Guid? GetId();
    }
    /// <summary>
    /// 
    /// </summary>
    public class PrincipalAccessor : IPrincipalAccessor
    {
        private readonly IHttpContextAccessor _contextAccessor;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessor"></param>
        public PrincipalAccessor(IHttpContextAccessor accessor)
        {
            _contextAccessor = accessor;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string? GetToken()
        {
            var token = _contextAccessor?.HttpContext?.Request.Headers["Authorization"].ToString();
            return token;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Guid? GetId()
        {
            var id = _contextAccessor?.HttpContext?.Request.Cookies["id"];
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }
            return Guid.Parse(id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using Web.Code.ModelVM;
using Newtonsoft.Json;
namespace Web.Global
{
    /// <summary>
    /// 全局异常拦截器
    /// </summary>
    public class GlobalExceptionsFilter : ExceptionFilterAttribute
    {
        private readonly IWebHostEnvironment _env;

        private readonly ILogger<GlobalExceptionsFilter> _loggerHelper;

        public GlobalExceptionsFilter(IWebHostEnvironment env, ILogger<GlobalExceptionsFilter> loggerHelper)
        {
            _env = env;
            _loggerHelper = loggerHelper;
        }

        [DebuggerStepThrough]
        public override void OnException(ExceptionContext context)
        {
            if (context.ExceptionHandled == false)
            {
                ModelStateResult response = new ModelStateResult
                {
                    StatusCode = 500,
                    Message = context.Exception.Message
                };
                _loggerHelper.LogError(context.HttpContext.Request.Path, context.Exception,context.HttpContext.Request.Body);
                context.Result = new ContentResult
                {
                    Content = JsonConvert.SerializeObject(response),
                    StatusCode=500,
                    ContentType="application/json;charset=utf-8"
                };
            }
            context.ExceptionHandled = true;
        }
    }
}

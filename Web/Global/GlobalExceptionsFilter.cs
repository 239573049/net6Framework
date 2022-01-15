﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using Web.Code.ModelVM;
using Newtonsoft.Json;
using Util;

namespace Web.Global
{
    /// <summary>
    /// 全局异常拦截器
    /// </summary>
    public class GlobalExceptionsFilter : ExceptionFilterAttribute
    {
        private readonly IWebHostEnvironment _env;

        private readonly ILogger<GlobalExceptionsFilter> _loggerHelper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="env"></param>
        /// <param name="loggerHelper"></param>
        public GlobalExceptionsFilter(IWebHostEnvironment env, ILogger<GlobalExceptionsFilter> loggerHelper)
        {
            _env = env;
            _loggerHelper = loggerHelper;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        [DebuggerStepThrough]
        public override void OnException(ExceptionContext context)
        {
            if (context.ExceptionHandled == false)
            {
                var ex= context.Exception as BusinessLogicException;
                ModelStateResult response = new ModelStateResult
                {
                    StatusCode = ex.Code,
                    Message = ex.Message
                };
                _loggerHelper.LogError(context.HttpContext.Request.Path, context.Exception,context.HttpContext.Request.Body);
                context.Result = new ContentResult
                {
                    Content = JsonConvert.SerializeObject(response),
                    StatusCode=200,
                    ContentType="application/json;charset=utf-8"
                };
            }
            context.ExceptionHandled = true;
        }
    }
}

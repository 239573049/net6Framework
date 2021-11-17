﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using Web.Code.ModelVM;

namespace Web.Global
{
    public class GlobalResponseFilter : ActionFilterAttribute
    {
        [DebuggerStepThrough]
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result != null)
            {
                if (context.Result is ObjectResult)
                {
                    ObjectResult? objectResult = context.Result as ObjectResult;
                    if (objectResult?.GetType().Name == "BadRequestObjectResult")
                    {
                        context.Result = new JsonResult(new
                        {
                            StatusCode = objectResult.StatusCode,
                            Data = new
                            {

                            },
                            Message = objectResult.Value
                        });
                    }
                    else if (objectResult?.Value?.GetType().Name == "ModelStateResult")
                    {
                        ModelStateResult? modelStateResult = objectResult.Value as ModelStateResult;
                        context.Result = new JsonResult(new
                        {
                            StatusCode = modelStateResult?.StatusCode,
                            Data = new
                            {

                            },
                            Message = modelStateResult?.Message
                        });
                    }
                    else
                    {
                        context.Result = new JsonResult(new
                        {
                            StatusCode = 200,
                            Data = objectResult?.Value
                        });
                    }
                }
                else if (context.Result is EmptyResult)
                {
                    context.Result = new JsonResult(new
                    {
                        StatusCode = 200,
                        Data = new
                        {

                        }
                    });
                }
                else if (context.Result is ModelStateResult)
                {
                    ModelStateResult? modelStateResult2 = context.Result as ModelStateResult;
                    context.Result = new JsonResult(new
                    {
                        StatusCode = modelStateResult2?.StatusCode,
                        Data = new
                        {

                        },
                        Message = modelStateResult2?.Message
                    });
                }
            }

            base.OnActionExecuted(context);
        }
    }
}

using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using Token.WebCore.ModelVM;
using System.Diagnostics;

namespace Token.PCWebApi.Global;

/// <summary>
/// 
/// </summary>
public class GlobalModelStateValidationFilter : ActionFilterAttribute
{

    [DebuggerStepThrough]
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ModelState.IsValid)
        {
            return;
        }

        ModelStateResult modelStateResult = new ModelStateResult();
        foreach (ModelStateEntry value in context.ModelState.Values)
        {
            foreach (ModelError error in value.Errors)
            {
                modelStateResult.Message = modelStateResult.Message + error.ErrorMessage + "|";
            }
        }
        context.Result = new ObjectResult(modelStateResult);
    }

}

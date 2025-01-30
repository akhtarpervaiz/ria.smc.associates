using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ria.smc.associates.UI.Utilities.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAuthAttribute : Attribute, IAuthorizationFilter, IActionFilter
{  
    public void OnAuthorization(AuthorizationFilterContext context) 
    {
        if (context.HttpContext.User.Identity.IsAuthenticated)
        {
             return;       
        }
        else
        {
            context.Result = new RedirectResult(AppConstants.URL_Loginin_Index);
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }

    public void OnActionExecuting(ActionExecutingContext filterContext)
    {
    }
}
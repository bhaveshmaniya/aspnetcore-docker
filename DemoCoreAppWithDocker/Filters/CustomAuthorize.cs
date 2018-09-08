using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System;

namespace DemoCoreAppWithDocker.Filters
{
    public class CustomAuthorize : ActionFilterAttribute
    { 
        public CustomAuthorize() : base()
        {           
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var headers = context.HttpContext.Request.Headers;
            bool isAuthorized = false;
                    
            if (headers.Keys.Contains("auth_key"))
            {
                var header = headers.FirstOrDefault(x => x.Key == "auth_key").Value.FirstOrDefault();
                if (header != null)
                    isAuthorized = header.Equals("core",StringComparison.InvariantCultureIgnoreCase);
            }

            if (!isAuthorized)
            {
                context.Result = new ContentResult()
                {
                    Content = "Authorization has been denied!!",
                    ContentType = "text/plain",
                    StatusCode = 401
                };
            }
        }
    }
}
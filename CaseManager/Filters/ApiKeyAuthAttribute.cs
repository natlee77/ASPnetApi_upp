using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManager.Filters
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAuthAttribute : Attribute, IAsyncActionFilter
    {

      
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
         

            if (!context.HttpContext.Request.Query.TryGetValue("Key", out var providedApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();//   Iconfiguration som DI-- i startup
            var apiKey = configuration.GetValue<string>(key: "SecretKey");//hämta   key-constant(appsettings)

            if (!apiKey.Equals(providedApiKey))//om de !lika-->unauthor
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            //att go to next MIDDELWEAR=app. del-i startup
            await next();
        }
    }
} //-->controller att använda
 
   
        
      
           
         
           
  
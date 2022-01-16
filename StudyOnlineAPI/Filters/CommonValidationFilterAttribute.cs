using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace StudyOnlineAPI.Filters
{
    public class CommonValidationFilterAttribute : IAsyncActionFilter
    {
        public ILogger<CommonValidationFilterAttribute> logger { get; }
        public CommonValidationFilterAttribute(ILogger<CommonValidationFilterAttribute> logger)
        {
            this.logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.Where(t => t.Errors.Count > 0)
                         .SelectMany(t => t.Errors)
                         .Select(t => t.ErrorMessage)
                         .ToList();
                context.Result = new BadRequestObjectResult(new
                {
                    Reason = "Validation Failed",
                    Errors = errors
                });

                logger.LogError($"Validation error !! Error message : {errors}");
                return;
            }
            await next.Invoke();
        }
    }
}

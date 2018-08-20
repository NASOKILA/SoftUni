using FiltersLesson.Services;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersLesson.Filters
{
    //to create a filter in this clas and not in the actul cinstructor we need to inherite ActionFilterAttribute
    public class LoggingFilter : IActionFilter
    {
        private readonly LoggingInfoService loggingInfoService;

        public LoggingFilter(LoggingInfoService loggingInfoService)
        {
            this.loggingInfoService = loggingInfoService;
        }
        

        //this will run right after the constructor, before any action
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //we have access to everything about the request here
            string displayName = context.ActionDescriptor.DisplayName; //action and controller name
            string method = context.HttpContext.Request.Method; //method

            this.loggingInfoService.Messages.Add($"Executing {displayName} with method {method}.");
        }


        //Runs After An ACtion
        public void OnActionExecuted(ActionExecutedContext context)
        {

            //we have access to everything about the request here
            string displayName = context.ActionDescriptor.DisplayName; //action and controller name
            string method = context.HttpContext.Request.Method; //method

            this.loggingInfoService.Messages.Add($"Executing {displayName} with method {method}.");
        }

    }
}

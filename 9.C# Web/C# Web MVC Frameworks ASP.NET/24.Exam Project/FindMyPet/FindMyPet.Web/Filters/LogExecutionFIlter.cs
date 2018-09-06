using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace FindMyPet.Web.Filters
{
    public class LogExecutionFIlter : IPageFilter, IActionFilter
    {
        private ILogger<LogExecutionFIlter> logger;
        private Stopwatch stopwatch;
        
        public LogExecutionFIlter(ILogger<LogExecutionFIlter> logger, Stopwatch stopwatch)
        {
            this.logger = logger;
            this.stopwatch = stopwatch;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            this.LogEnteringMessage(context.HttpContext.Request.Method, context.ActionDescriptor.DisplayName, context.ModelState.IsValid);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            this.LogLeavingMessage();
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            //dont need to implement this
        }

        private void LogEnteringMessage(string httpMethod, string actionName, bool isModelValid)
        {
            this.logger.LogInformation($"Executing {httpMethod} {actionName}.");
            this.logger.LogInformation($"Model state {(isModelValid ? "is" : "is not")} valid.");

            this.stopwatch.Start();
        }
        
        private void LogLeavingMessage()
        {
            this.stopwatch.Stop();
            var time = this.stopwatch.Elapsed.TotalSeconds;
        }
    }
}

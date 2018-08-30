using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace FindMyPet.Web.Filters
{
    public class LogExecutionFIlter : IPageFilter, IActionFilter
    {
        private ILogger<LogExecutionFIlter> logger;
        private Stopwatch stopwatch;

        //we need the logger from the current class
        public LogExecutionFIlter(ILogger<LogExecutionFIlter> logger, Stopwatch stopwatch)
        {
            this.logger = logger;
            this.stopwatch = stopwatch;
        }

        //action Filters
        public void OnActionExecuting(ActionExecutingContext context)
        {                                            //Method                       Action                          ModelStae
            this.LogEnteringMessage(context.HttpContext.Request.Method, context.ActionDescriptor.DisplayName, context.ModelState.IsValid);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            this.LogLeavingMessage();
        }


        //page filters
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

            //use the logger to log the information for the action used

            this.logger.LogInformation($"Executing {httpMethod} {actionName}.");
            this.logger.LogInformation($"Model state {(isModelValid ? "is" : "is not")} valid.");

            //we start the timer on every request
            this.stopwatch.Start();
        }
        
        private void LogLeavingMessage()
        {
            //we stop the timer after every request
            this.stopwatch.Stop();
            var time = this.stopwatch.Elapsed.TotalSeconds;
        }
    }
}

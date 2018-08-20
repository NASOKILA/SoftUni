using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SoftUniClone.Web.Filters
{
    //filter for pages and actions
    //add it to Startup.cs services
    public class LogExecution : IPageFilter, IActionFilter
    {
        private ILogger<LogExecution> logger;
        private Stopwatch stopwatch;

        //we need the logger from the current class
        public LogExecution(ILogger<LogExecution> logger, Stopwatch stopwatch)
        {
            this.logger = logger;   
            this.stopwatch = stopwatch;
        }
        
        public void OnActionExecuting(ActionExecutingContext context)
        {                                            //Method                       Action                          ModelStae
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
        
        //for the currently running action
        private void LogEnteringMessage(string httpMethod, string actionName, bool isModelValid) {
            
            
            //use the logger to log the information for the action used

            this.logger.LogInformation($"Executing {httpMethod} {actionName}.");
            this.logger.LogInformation($"Model state {(isModelValid ? "is" : "is not")} valid.");

            //we start the timer on every request
            this.stopwatch.Start();
        }


        //for the action that was just executed
        private void LogLeavingMessage()
        {   
            //we stop the timer after every request
            this.stopwatch.Stop();
            var time = this.stopwatch.Elapsed.TotalSeconds;
        }

    }
}

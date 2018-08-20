using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Web.Filters
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)] //We declare that we will use this filter only for classes and methods
    public class AuthorizeAttribute : Attribute, IPageFilter, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            throw new NotImplementedException();
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            throw new NotImplementedException();
        }
    }
}

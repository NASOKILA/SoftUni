namespace RazorPagesArchitecture.Pages
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System;

    //This is the default page

    public class IndexModel : PageModel 
    {//This class has to inherit the PageModel class

       
        /*
        public void OnGet()
        {
            //This method i executed when the page loads.
            
            //Link
            string pageRoute = Url.Page("About"); //  /About   
        }
        */


        //We can have an IActionResult which returns something
        public IActionResult OnGet()
        {
            //This method i executed when the page loads.


            //we can do many other things like redirect
            //return RedirectToPage("About");

            this.Boxing();

            return Page(); //returns the current page
        }
        
        public void OnPostMessageOne()
        {
            ViewData["Message"] = "Message One!";
        }

        public void OnPostMessageTwo()
        {
            ViewData["Message"] = "Message Two!";
        }
        
        public void OnPostParametersPassed(string name)
        {
            ViewData["Greeting"] = "Hello, " + name;
        }





        //HANDLERS

        //new Handlers created by us
        public void OnGetLinkClicked()
        {
            ViewData["LinkMessage"] += "Link is clicked.";
        }

        //The buildIn Handlers have to be overrwitten to be accessed

        public override void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            //This Hander is alwais first

            ViewData["LinkMessage"] += "OnPageSelected " + context.HandlerMethod.Name;
            base.OnPageHandlerSelected(context);
        }

        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            //This Hander runs BEFORE OnGet(){ } method

            ViewData["LinkMessage"] += "OnPageExecuting " + context.HandlerMethod.Name;
            base.OnPageHandlerExecuting(context);
        }

        public override void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            //This Hander runs alwis AFTER OnGet(){ } method

            ViewData["LinkMessage"] += "OnPageExecuted " + context.HandlerMethod.Name + Environment.NewLine;
            base.OnPageHandlerExecuted(context);
        }

        public void Boxing() {

            //Boxing is when we turn something into object
            //Every datatype inherits the "object" class
            
            int a = 5;
            object aObj = (object)a;

            //Unboxing is the opposite, turning something from an object to a dataType
            int b = (int)aObj - 1;


            int? c = null;
            Console.WriteLine(c);
        }
    }
}

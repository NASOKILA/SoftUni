using FiltersLesson.Filters;
using FiltersLesson.Models;
using FiltersLesson.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersLesson.Controllers
{
    public class SumController : Controller
    {

        private readonly SumProvider sumProvider;
        
        public SumController(
            SumProvider sumProvider)
        {
            this.sumProvider = sumProvider;
        }

        [HttpGet]
        [Route("/Sum")]  //We specify the route for this
        public IActionResult Index() {

            return View();
        }

        [HttpPost]
        [CensorNumber]
        [Route("/Sum")]
        public IActionResult Index(NumbersBindingModel model)
        {
            
            this.sumProvider.Sum = model.FirstNumber + model.SecondNumber;
            ViewData["result"] = this.sumProvider.Sum;
            return View();            
        }

        [HttpGet("Increment")]
        public IActionResult Increment() {

            this.sumProvider.Sum++;
            ViewData["result"] = this.sumProvider.Sum;
            return View("Index");
        }

        [HttpGet("Decrement")]
        public IActionResult Decrement()
        {
            this.sumProvider.Sum--;
            ViewData["result"] = this.sumProvider.Sum;
            return View("Index");
        }
        

        //CUSTOM FILTERS CREATION: LOOK IN Filter Folder

    /*
        //this will run right after the constructor, before any action
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            //we have access to everything about the request here
            string displayName = context.ActionDescriptor.DisplayName; //action and controller name
            string method = context.HttpContext.Request.Method; //method

            this.loggingInfoService.Messages.Add($"Executing {displayName} with method {method}.");
            base.OnActionExecuting(context);
        }


        //Runs After An ACtion
        public override void OnActionExecuted(ActionExecutedContext context)
        {

            string displayName = context.ActionDescriptor.DisplayName; //action and controller name
            string method = context.HttpContext.Request.Method; //method

            this.loggingInfoService.Messages.Add($"Executed {displayName} with method {method}.");
            base.OnActionExecuted(context);
        }

    */

    }
}

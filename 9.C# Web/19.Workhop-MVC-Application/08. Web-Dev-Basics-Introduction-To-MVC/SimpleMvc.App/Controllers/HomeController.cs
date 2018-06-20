namespace SimpleMvc.App.Controllers
{
    using Framework.Attributes.Methods;
    using Framework.Contracts;
    using Framework.Controllers;

    public class HomeController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            
            if (this.User.IsAuthenticated)
            {
                this.ViewModel["displayRegister"] = "none";
                this.ViewModel["displayLogoutType"] = "block";
            }
            else
            { 
                this.ViewModel["displayRegister"] = "block";
                this.ViewModel["displayLogoutType"] = "none";
            }

            return this.View();
        }

        [HttpGet]
        public IActionResult About()
        {
            return this.View();
        }
        
    }
}


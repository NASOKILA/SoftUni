using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SumNumbers.Html_Helpers
{
    //This is how we create an html helper method.
    public static class HtmlHelperExtensions
    {
        //we can pass parameters on our own
        public static IHtmlContent HelloWorld(this IHtmlHelper helper, string param) {

            //IMPORTANT :
            //we can use a stringbuilder for the result.
            //we can use the helper parameter for creating html elements in here.
            return new HtmlString("<h1>Hello World " + param + "</h1>");
        }
    }
}


//We can pass a function and work with it
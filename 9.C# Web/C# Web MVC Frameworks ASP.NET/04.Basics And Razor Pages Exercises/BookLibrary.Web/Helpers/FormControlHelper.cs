
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace BookLibrary.Web.Helpers
{
    
    
    [HtmlTargetElement(Attributes="form-control")] //we can specify the name for the attribute that we are creating
    public class FormControlHelper : TagHelper
    {

        //we can use the generator to generate html 
        private readonly IHtmlGenerator generator;

        public FormControlHelper(IHtmlGenerator generator)
        {
            this.generator = generator;
        }


        //we have to pass this with asp-for
        [HtmlAttributeName("asp-for")]
        public ModelExpression For { get; set; }

        //Init() method is for initialization


        //basically we are returning HTML as a string 
        //when we call the attribute in the view the html will be displayed
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(@"<div class=""form-group"">");
            sb.AppendLine(@"<h1>NASKO</h1>");

            //var label = this.generator.GenerateLabel();

            //TO FINISH ...

            sb.AppendLine(@"</div>");

            //we set the result in the output
            output.Content.SetHtmlContent(sb.ToString());
        }
    }
}


//Add all tag helpers in _viewImports.cshtml


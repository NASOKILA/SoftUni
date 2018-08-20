using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SumNumbers.TagHelpers
{
    //Tag helpers and HTMl helpers are c# code which generates HTML 
    public class MessageTagHelper : TagHelper
    {

        public string MessageContent { get; set; }


        //we can do this in an async way
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Content.SetContent(this.MessageContent);
            //we have to add this to _ViewImports and in the view
        }
    }
}

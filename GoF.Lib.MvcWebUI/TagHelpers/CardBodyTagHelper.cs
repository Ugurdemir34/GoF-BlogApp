using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using System.Threading.Tasks;

namespace GoF.Lib.MvcWebUI.TagHelpers
{
    [HtmlTargetElement("uui-card-body", ParentTag = "uui-card")]
    [RestrictChildren("uui-card-title", "uui-card-text")]
    public class CardBodyTagHelper:TagHelper
    {
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            StringBuilder builder = new StringBuilder();
            builder.Append("<div class='card-body'>");
            output.Content.SetHtmlContent(builder.ToString());
            return base.ProcessAsync(context, output);
        }
    }
}

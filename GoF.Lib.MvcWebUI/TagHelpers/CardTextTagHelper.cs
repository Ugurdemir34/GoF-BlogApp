using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoF.Lib.MvcWebUI.TagHelpers
{
    [HtmlTargetElement("uui-card-text", ParentTag = "uui-card-body")]
    public class CardTextTagHelper:TagHelper
    {
        public string Text { get; set; }
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat(@"<div class='card-text'>{0}</div>", Text);
            builder.Append("</div>");
            output.Content.SetHtmlContent(builder.ToString());
            return base.ProcessAsync(context, output);  
        }
    }
}

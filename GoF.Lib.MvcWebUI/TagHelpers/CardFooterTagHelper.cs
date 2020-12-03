using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoF.Lib.MvcWebUI.TagHelpers
{
    [HtmlTargetElement("uui-card-footer",ParentTag ="uui-card")]
    public class CardFooterTagHelper:TagHelper
    {
        public string Footer { get; set; }
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat(@"<div class='card-footer'>{0}</div>", Footer);
            output.Content.SetHtmlContent(builder.ToString());
            return base.ProcessAsync(context, output);
        }
    }
}

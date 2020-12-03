using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoF.Lib.MvcWebUI.TagHelpers
{
    [HtmlTargetElement("uui-card-title", ParentTag = "uui-card-body")]
    public class CardTitleTagHelper: TagHelper
    {
        public string Title { get; set; }
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat(@"<div class='card-title'>{0}</div>", Title);
            output.Content.SetHtmlContent(builder.ToString());
            return base.ProcessAsync(context, output);
        }
    }
}

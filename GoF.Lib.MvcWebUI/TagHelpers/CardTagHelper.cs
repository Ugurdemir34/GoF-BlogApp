using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;

namespace GoF.Lib.MvcWebUI.TagHelpers
{
    [HtmlTargetElement("uui-card")]
    [RestrictChildren("uui-card-header","uui-card-body","uui-card-footer")]
    public class CardTagHelper : TagHelper
    {                     
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            base.Process(context, output);
        }
    }
}

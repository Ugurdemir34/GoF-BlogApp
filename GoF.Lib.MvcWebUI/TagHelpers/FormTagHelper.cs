using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GoF.Lib.MvcWebUI.TagHelpers
{
    [HtmlTargetElement("uui-form")]
    public class FormTagHelper : TagHelper
    {
        public object Model { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var result = Model.GetType();
            StringBuilder builder = new StringBuilder();
            builder.Append("<form>");
            builder.Append("<div class='form-group'>");
            string html = "";
            string inputType = "text";
            foreach (PropertyInfo item in result.GetProperties())
            {
                inputType = (item.Name.ToUpper() == "ID" || item.Name.ToUpper() == "İD") ? "hidden" : "text";
               
                html = String.Format(@"<input type='" + inputType + "' id='{0}' name='{1}' class='form-control' value='{2}'/>", item.Name, item.Name,item.GetValue(Model));
                //<input class="form-control" type="text" id="Question_Name" name="Question.Name" value="">
                builder.Append(html);
            }
            builder.Append("</div>");
            builder.Append("</form>");
            output.Content.AppendHtml(builder.ToString());
            base.Process(context, output);
        }
    }
}

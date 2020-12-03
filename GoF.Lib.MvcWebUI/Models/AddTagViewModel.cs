using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GoF.Lib.MvcWebUI.Models
{
    public class AddTagViewModel
    {
        [DisplayName("Tag Adı")]
        public string TagName { get; set; }
    }
}

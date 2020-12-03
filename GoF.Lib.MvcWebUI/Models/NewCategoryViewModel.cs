using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GoF.Lib.MvcWebUI.Models
{
    public class NewCategoryViewModel
    {
        [DisplayName("Kategori Adı")]
        public string CategoryName { get; set; }
    }
}

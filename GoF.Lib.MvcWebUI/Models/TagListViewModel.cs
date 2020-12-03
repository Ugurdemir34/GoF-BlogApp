using GoF.Lib.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoF.Lib.MvcWebUI.Models
{
    public class TagListViewModel
    {
        public IEnumerable<Tag> Tags { get; set; }
       // public Dictionary<string,int> TagArticleInfo { get; set; }
    }
}

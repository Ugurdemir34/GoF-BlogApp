using GoF.Lib.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoF.Lib.MvcWebUI.Models
{
    public class CategoryListViewModel
    {
        public CategoryListViewModel()
        {
            CategoryArticleInfo = new Dictionary<string, int>();
        }
        public IEnumerable<Category> Categories { get; set; }
        public Dictionary<string,int> CategoryArticleInfo { get; set; }
    }
}

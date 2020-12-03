
using GoF.Lib.Entities.Concrete;
using GoF.Lib.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoF.Lib.MvcWebUI.Models
{
    public class ArticleListViewModel
    {
        public IEnumerable<ArticleCategoryDto> Articles { get; set; }
    
    }
}

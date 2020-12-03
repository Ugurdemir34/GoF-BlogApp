
using GoF.Lib.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoF.Lib.MvcWebUI.Models
{
    public class ArticleCategoryViewModel
    {
        public ArticleCategoryViewModel()
        {
            Article = new Article();
        }
        public Article Article { get; set; }
        public List<ArticleAndTagsViewModel> Articles { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}


using GoF.Lib.Entities.Concrete;
using GoF.Lib.Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoF.Lib.MvcWebUI.Models
{
    public class ArticleAndTagsViewModel
    {
        public ArticleAndTagsViewModel()
        {
            Complex = new ArticleCategoryTagDto();
        }
        public ArticleCategoryTagDto Complex { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> Author { get; set; }
        public IFormFile FormFiles { get; set; }

    }
}

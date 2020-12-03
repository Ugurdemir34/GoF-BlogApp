using GoF.Lib.Business.Abstract;
using GoF.Lib.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoF.Lib.MvcWebUI.ViewComponents
{
    public class TagListViewComponent : ViewComponent
    {
        private ITagService _tagService;
        private IArticleService _articleService;
        private IArticleTagService _articleTagService;
        public TagListViewComponent(ITagService tagService,IArticleService articleService, IArticleTagService articleTagService)
        {
            _tagService = tagService;
            _articleService = articleService;
            _articleTagService = articleTagService;
        }
        public ViewViewComponentResult Invoke()
        {           
            var model = new TagListViewModel
            {
                Tags = _tagService.GetAll().Data
            };
            return View(model);
        }
    }
}

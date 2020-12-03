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
    public class CategoryListViewComponent : ViewComponent
    {
        private ICategoryService _categoryService;
        private IArticleService _articleService;
        public CategoryListViewComponent(ICategoryService categoryService, IArticleService articleService)
        {
            _categoryService = categoryService;
            _articleService = articleService;
        }
        public ViewViewComponentResult Invoke()
        {
            /*SELECT Categories.Id,Categories.Name,COUNT(*) FROM Categories
            INNER JOIN Articles on Categories.Id = Articles.CategoryId GROUP BY Categories.Id,Categories.Name*/
            var categories = _categoryService.GetAll().Data.OrderBy(a => a.Name).ToList();
            var articles = _articleService.GetAll().Data.OrderBy(a => a.ArticleTitle).ToList();
            var result = from a in categories
                         orderby a.Name
                         join b in articles on a.Id equals b.CategoryId
                         group a by a.Name into grp
                         select new
                         {
                             Category = grp.Key,
                             cnt = grp.Count()
                         };

            //var model = new CategoryListViewModel
            //{
            //    Categories = _categoryService.GetAll().OrderBy(a=>a.Name).ToList(),
            //    CategoryArticleInfo = new Dictionary<string, int>()
            //    {
            //    }
            //};
            var model = new CategoryListViewModel();
            foreach (var item in result)
            {
                model.CategoryArticleInfo.Add(item.Category, item.cnt);
            }
            return View(model);
        }
    }
}

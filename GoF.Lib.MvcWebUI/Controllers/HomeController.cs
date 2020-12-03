using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoF.Lib.Business.Abstract;
using GoF.Lib.Entities.Concrete;
using GoF.Lib.MvcWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GoF.Lib.MvcWebUI.Controllers
{
  
    public class HomeController : Controller
    {
        #region Variables
        private ICategoryService _categoryService;
        private ITagService _tagService;
        private IQuestionService _questionService;
        private IArticleService _articleService;
        #endregion
        #region Constructor
        public HomeController(ICategoryService categoryService, ITagService tagService, IQuestionService questionService, IArticleService articleService)
        {
            _categoryService = categoryService;
            _tagService = tagService;
            _questionService = questionService;
            _articleService = articleService;
        }
        #endregion
        #region Index
        public IActionResult Index()
        {
            /*var categories = _categoryService.GetAll();
            var tags = _tagService.GetAll();
            CategoryListViewModel model = new CategoryListViewModel
            {
                Categories = categories,

            };*/
            var articles = _articleService.GetArticleAndCategory();
            ArticleListViewModel model = new ArticleListViewModel
            {
                Articles = articles.Data
            };

            return View(model);
        }
        #endregion
        #region About
        public IActionResult About()
        {
            return View();
        }
        #endregion
        #region Question
        public IActionResult Question()
        {
            var questionViewModel = new QuestionViewModel
            {
                Questions = _questionService.GetQuestionWithCategory().Data,
                Categories = LoadCategories()
            };
            return View(questionViewModel);
        }
        [HttpPost]
        public IActionResult Question(QuestionViewModel model)
        {
            var question = new Question
            {
                Name = model.Question.Name,
                Lastname = model.Question.Lastname,
                CategoryId = model.Question.CategoryId,
                Mail = model.Question.Mail,
                QuestionContent = model.Question.QuestionContent,
                QuestionDate = DateTime.Now,
                QuestionSubject = model.Question.QuestionSubject,

            };
            _questionService.Add(question);
            return RedirectToAction("Index");
        }
        #endregion
        #region Category List Item
        private List<SelectListItem> LoadCategories()
        {
            List<SelectListItem> categories = (from category in _categoryService.GetAll().Data
                                               select new SelectListItem
                                               {
                                                   Value = category.Id.ToString(),
                                                   Text = category.Name
                                               }).ToList();
            return categories;
        }
        #endregion


    }
}
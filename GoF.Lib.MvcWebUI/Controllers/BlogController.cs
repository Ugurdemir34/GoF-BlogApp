using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoF.Lib.Business.Abstract;
using GoF.Lib.Entities.Concrete;
using GoF.Lib.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GoF.Lib.MvcWebUI.Controllers
{
    public class BlogController : Controller
    {
        private IArticleService _articleService;
        private ICommentService _commentService;
        private ISecondLevelCommentService _secondLevelCommentService;
        public BlogController(IArticleService articleService, ICommentService commentService, ISecondLevelCommentService secondLevelCommentService)
        {
            _articleService = articleService;
            _commentService = commentService;
            _secondLevelCommentService = secondLevelCommentService;
        }

        public IActionResult Index(string categoryName = "", string tagName = "")
        {
            var model = new ArticleListViewModel();
            if (tagName == "")
            {
                model.Articles = categoryName == "" ? _articleService.GetArticleAndCategory().Data : _articleService.GetArticleByCategoryName(categoryName).Data;
                ViewData["Name"] = categoryName;
            }
            else if (categoryName == "")
            {
                model.Articles = _articleService.GetArticleByTagName(tagName).Data.Articles;
                ViewData["Name"] = "#" + tagName + " Etiketi ile ilgili " + model.Articles.Count() + " adet makale bulundu";

            }
            
            return View(model);
        }
        [Route("/Blog/BlogDetail/{id}")]
        public IActionResult BlogDetail(int id)
        {
            var model = new ArticleCategoryTagAdminCommentViewModel
            {
                ArticleAll = _articleService.GetAllArticleWithComment(id).Data
            };
            return View(model);
        }
        public JsonResult AddComment(Comment comment)
        {
            comment.CommentDate = DateTime.Now;
            _commentService.Add(comment);
            return Json(comment);
        }
        public JsonResult AddSubComment(SecondLevelComment secondLevelComment)
        {
            secondLevelComment.CommentDate = DateTime.Now;
            _secondLevelCommentService.Add(secondLevelComment);
            return Json(secondLevelComment);
        }


    }
}
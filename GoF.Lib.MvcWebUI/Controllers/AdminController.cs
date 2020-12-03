using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GoF.Lib.Business.Abstract;
using GoF.Lib.MvcWebUI.Middlewares;
using GoF.Lib.MvcWebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using GoF.Lib.Entities.Concrete;
using GoF.Core.Utilities.Security.Hashing;

namespace GoF.Lib.MvcWebUI.Controllers
{
   
    public class AdminController : Controller
    {
        #region Variables
        private IArticleService _articleService;
        private ICategoryService _categoryService;
        private ITagService _tagService;
        private IArticleTagService _articleTagService;
        private IQuestionService _questionService;
        private IAdminService _adminService;
        private ISocialMediaService _socialMediaService;
        #endregion
        #region Constructor
        public AdminController(IArticleService articleService, ICategoryService categoryService, ITagService tagService, IArticleTagService articleTagService, IQuestionService questionService, IAdminService adminService, ISocialMediaService socialMediaService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _tagService = tagService;
            _articleTagService = articleTagService;
            _questionService = questionService;
            _adminService = adminService;
            _socialMediaService = socialMediaService;
        }
        #endregion
        #region Index
        public IActionResult Index()
        {
            return View();
        }
        #endregion
        #region All About Article
        public IActionResult Articles()
        {
            var model = new ArticleListViewModel
            {
                Articles = _articleService.GetArticleAndCategory().Data
            };
            return View(model);

        }
        [Route("/Article/ArticleDetails/{id}")]
        public IActionResult ArticleDetails(int articleId)
        {
            var model = new ArticleAndTagsViewModel
            {
                Complex = _articleService.GetArticleCategoryTag(articleId).Data
            };
            return View(model);

        }
        [HttpGet]
        public JsonResult ArticleContent(int articleId)
        {
            var model = _articleService.GetArticle(articleId).Data.ArticleContent;
            return Json(model);
        }
        //public IActionResult ArticleEdit(int articleId)
        //{
        //    var model = new ArticleCategoryViewModel
        //    {
        //        Article = _articleService.GetArticle(articleId), ÇALIŞIYOR
        //        Categories = LoadCategories()

        //    };
        //    return View("ArticleEdit", model);
        //}
        public IActionResult ArticleEdit(int articleId)
        {
            if (articleId != 0)
            {
                var model = new ArticleAndTagsViewModel
                {
                    Complex = _articleService.GetArticleCategoryTag(articleId).Data,
                    Categories = LoadCategories(),
                    Author = LoadAdmins()
                };

                return View("ArticleEdit", model);
            }
            else
            {
                var model = new ArticleAndTagsViewModel();
                return View("AddArticle", model);
            }
        }
        [HttpPost]
        public IActionResult ArticleEdit(ArticleAndTagsViewModel articleModel)
        {
            if (ModelState.IsValid)
            {
                var articleState = _articleService.GetArticle(articleModel.Complex.Article.Id).Data;

                if (articleState != null)
                {
                    var model = new Article
                    {
                        ArticleContent = articleModel.Complex.Article.ArticleContent,
                        PublishDate = articleModel.Complex.Article.PublishDate,
                        Views = articleModel.Complex.Article.Views,
                        CategoryId = articleModel.Complex.Article.CategoryId,
                        ArticleTitle = articleModel.Complex.Article.ArticleTitle,
                        AdminId = articleModel.Complex.Article.AdminId,
                        Thumbnail = articleModel.FormFiles.GetBytes(),//IFormFile
                        Id = articleModel.Complex.Article.Id
                    };

                    _articleService.Update(model);

                }
            }
            return RedirectToAction("Articles");
        }
        [HttpGet]
        public JsonResult ArticleDelete(int articleId)
        {

            var model = _articleService.GetArticle(articleId).Data;
            _articleService.Delete(model);
            return Json("1");

        }
        public IActionResult AddArticle()
        {
            var model = new AddArticleViewModel
            {
                Categories = LoadCategories(),
                Author = LoadAdmins()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddArticle(AddArticleViewModel model)
        {
            var article = new Article()
            {
                ArticleContent = model.ArticleContent,
                ArticleTitle = model.ArticleTitle,
                AdminId = model.AdminId,
                CategoryId = model.CategoryId,
                PublishDate = DateTime.Now,
                Thumbnail = model.FormFiles.GetBytes(),
                Views = model.Views
            };

            _articleService.Add(article);

            return RedirectToAction("Articles");

        }
        #endregion
        #region All About Category
        public IActionResult Categories()
        {
            var model = new CategoryListViewModel
            {
                Categories = _categoryService.GetAll().Data
            };
            return View(model);
        }
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
        public IActionResult CategoryEdit(int categoryId)
        {
            var category = _categoryService.GetCategoryById(categoryId).Data;
            var model = new CategoryEditViewModel
            {
                Id = category.Id,
                CategoryName = category.Name
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult CategoryEdit(CategoryEditViewModel category)
        {
            var updatedCategory = new Category
            {
                Id = category.Id,
                Name = category.CategoryName
            };
            _categoryService.Update(updatedCategory);
            return RedirectToAction("Categories");
        }
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(NewCategoryViewModel model)
        {
            _categoryService.Add(new Category() { Name = model.CategoryName });
            return RedirectToAction("Categories");

        }
        public JsonResult CategoryDelete(int categoryId)
        {
            var deletedCategory = _categoryService.GetCategoryById(categoryId).Data;
            _categoryService.Delete(deletedCategory);
            return Json("1");
        }
        #endregion
        #region All About Article Tag
        [HttpGet]
        public JsonResult DeleteArticleTag(int tagId, int articleId)
        {
            var model = _articleTagService.GetArticleTagByTagId(tagId, articleId).Data;
            _articleTagService.Delete(model);
            return Json("1");

        }
        public JsonResult AddArticleTag(int tagId, int articleId)
        {

            var addedArticleTag = new ArticleTag()
            {
                ArticleId = articleId,
                TagId = tagId,
                Tag = new Tag()
                {
                    TagName = _tagService.GetTagById(tagId).Data.TagName,
                    Id = tagId
                }
            };
            _articleTagService.Add(addedArticleTag);
            return Json(addedArticleTag.Tag);
        }
        #endregion
        #region All About Tag
        [HttpGet]
        public JsonResult GetAllTags(int articleId)
        {
            var model = _tagService.GetAll();
            return Json(model);
        }
        [HttpGet]
        public JsonResult GetDifferentTags(int articleId)
        {

            var model = articleId == 0 ? _tagService.GetAll().Data.ToList() : _tagService.GetTagsWhichArticleDoesNotHave(articleId).Data.Tags;

            return Json(model);
        }
        public IActionResult Tags()
        {
            var model = new TagListViewModel
            {
                Tags = _tagService.GetAll().Data
            };
            return View(model);
        }
        public IActionResult TagEdit(int tagId)
        {
            var tag = _tagService.GetTagById(tagId).Data;
            var model = new TagEditViewModel
            {
                Id = tag.Id,
                TagName = tag.TagName
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult TagEdit(TagEditViewModel tag)
        {
            var model = new Tag
            {
                Id = tag.Id,
                TagName = tag.TagName
            };
            _tagService.Update(model);
            return RedirectToAction("Tags");
        }
        public JsonResult TagDelete(int tagId)
        {
            var deletedTag = _tagService.GetTagById(tagId).Data;
            _tagService.Delete(deletedTag);
            return Json("1");
        }
        public IActionResult AddTag()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTag(AddTagViewModel model)
        {
            _tagService.Add(new Tag() { TagName = model.TagName });
            return RedirectToAction("Tags");
        }
        #endregion
        #region All About Question
        public IActionResult Questions()
        {
            var model = new QuestionViewModel
            {
                Categories = LoadCategories(),
                Questions = _questionService.GetQuestionWithCategory().Data

            };
            return View(model);
        }
        public JsonResult QuestionDelete(int questionId)
        {
            var question = _questionService.GetQuestionById(questionId).Data;
            _questionService.Delete(question);
            return Json("1");
        }
        #endregion   
        #region All About Administrator
        public IActionResult Administrators()
        {
            var result = _adminService.GetAll();
            var model = new AdministratorListViewModel();
            for (int i = 0; i < result.Data.Count; i++)
            {
                var newmod = new AdministratorViewModel
                {
                    About = result.Data[i].About,
                    Email = result.Data[i].Email,
                    Id = result.Data[i].Id,
                    LastName = result.Data[i].Lastname,
                    FirstName = result.Data[i].Name,
                    Password = result.Data[i].Password,
                    Username = result.Data[i].Username
                };
                model.Admins.Add(newmod);
            }
            
            return View(model);
        }
        public JsonResult AdministratorDelete(int adminId)
        {
            var admin = _adminService.GetAdmin(adminId).Data;
            _adminService.Delete(admin);
            return Json("1");
        }
        public IActionResult AdministratorEdit(int adminId)
        {
            if (adminId != 0)
            {
                var model = new AdministratorAndSocialMediaViewModel
                {
                    AdminSocialMedias = _adminService.GetAdminWithSocialMedia(adminId).Data
                };
                return View("AdministratorEdit", model);
            }
            else
            {
                var model = new ArticleAndTagsViewModel();
                return View("Index", model);
            }
        }
        //[HttpPost]
        //public IActionResult AdministratorEdit(AdministratorAndSocialMediaViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
               
        //        var addedAdmin = new GoF.Lib.EntiAdmin()
        //        {
        //            Id = model.AdminSocialMedias.Admin.Id,
        //            FirstName = model.AdminSocialMedias.Admin.FirstName,
        //            LastName = model.AdminSocialMedias.Admin.LastName,
        //            UserName = model.AdminSocialMedias.Admin.UserName,
        //            PasswordHash = model.AdminSocialMedias.Admin.PasswordHash,
        //            About = model.AdminSocialMedias.Admin.About,
        //            Email = model.AdminSocialMedias.Admin.Email
        //        };
        //        _adminService.Update(addedAdmin);
        //    }

        //    return RedirectToAction("Administrators");
        //}
        //public JsonResult AdminSocialMediaDelete(int adminId, int socialMediaId)
        //{
        //    var model = _socialMediaService.GetSocialMedia(adminId, socialMediaId).Data;
        //    _socialMediaService.DeleteSocialMedia(model);
        //    return Json("1");
        //}
        private List<SelectListItem> LoadAdmins()
        {
            List<SelectListItem> admins = (from admin in _adminService.GetAll().Data
                                           select new SelectListItem
                                           {
                                               Value = admin.Id.ToString(),
                                               Text = admin.Name + " " + admin.Lastname
                                           }).ToList();
            return admins;
        }
        public IActionResult AddAdministrator()
        {

            return View();
        }
        [HttpPost]
        //public IActionResult AddAdministrator(AddAdministratorViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        byte[] passwordHash, passwordSalt;
        //        HashingHelper.CreatePasswordHash(model.Password, out passwordHash, out passwordSalt);
        //        var result = new GoF.Lib.Entities.Concrete.Admin()
        //        {
        //            FirstName = model.Name,
        //            LastName = model.Lastname,
        //            PasswordHash = passwordHash,
        //            PasswordSalt = passwordSalt,
        //            UserName = model.Username,
        //            About = model.About,
        //            Email = model.Email

        //        };
        //        _adminService.Add(result);
        //        return RedirectToAction("Administrators");
        //    }
        //}
        public JsonResult AddSocialMedia(string link,string logo,int adminId)
        {
            var model = new SocialMedia
            {
                AdminId = adminId,
                Link = link,
                LogoClass = logo
            };
            _socialMediaService.Add(model);
            return Json(1);
        }
        public JsonResult GetLastId() 
        {
            int result=_socialMediaService.LastId();
            return Json(result);
        }
        #endregion
    }
}
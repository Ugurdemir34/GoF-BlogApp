using GoF.Core.DataAccess.EntityFramework;
using GoF.Lib.DataAccess.Abstract;
using GoF.Lib.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using GoF.Lib.Entities.Dtos;

namespace GoF.Lib.DataAccess.Concrete.EntityFramework
{
    public class EfArticleDal : EfEntityRepositoryBase<Article, GoFContext>, IArticleDal
    {
        public List<ArticleCategoryDto> GetArticleAndCategory()
        {
            using (var _context = new GoFContext())
            {
                var result = from q in _context.Articles
                             join c in _context.Categories on q.CategoryId equals c.Id
                             select new ArticleCategoryDto
                             {
                                 ArticleId = q.Id,
                                 ArticleContent = q.ArticleContent,
                                 ArticleTitle = q.ArticleTitle,
                                 AdminName = q.Admin.Name + " " + q.Admin.Lastname,
                                 Thumbnail = q.Thumbnail,
                                 CategoryName = c.Name,
                                 PublishDate = q.PublishDate,
                                 Views = q.Views
                             };
                return result.ToList();
            }
        }
        public ArticleCategoryTagDto GetArticleAndCategoryTag(int articleId)
        {
            using (var _context = new GoFContext())
            {
                var model = new ArticleCategoryTagDto();
                var result1 = _context.Articles
                            .Include(i => i.Category)
                            .Include(i => i.ArticleTag);
                model.Article = result1.Where(i => i.Id == articleId).FirstOrDefault();
                var result2 = from t in _context.Tags
                              join a in _context.ArticleTags on t.Id equals a.TagId
                              where a.ArticleId == articleId
                              select t;
                model.Tags = result2.ToList();
                return model;
            }
        }
        public List<ArticleCategoryDto> GetArticleByCategoryName(string categoryName)
        {
            using (var _context = new GoFContext())
            {
                var model = from c in _context.Categories
                            join a in _context.Articles on c.Id equals a.CategoryId
                            where c.Name == categoryName
                            select new ArticleCategoryDto
                            {
                                ArticleId = a.Id,
                                ArticleContent = a.ArticleContent,
                                ArticleTitle = a.ArticleTitle,
                                AdminName = a.Admin.Name + " " + a.Admin.Lastname,
                                Thumbnail = a.Thumbnail,
                                CategoryName = c.Name,
                                PublishDate = a.PublishDate,
                                Views = a.Views
                            };
                return model.ToList();
            }
        }
        public ArticleCategoryTagAdminDto GetArticleCategoryTagAdmin(int articleId)
        {
            using (var _context = new GoFContext())
            {
                var model = new ArticleCategoryTagAdminDto();
                var result = _context.Articles
                            .Include(i => i.Category)
                            .Include(i => i.ArticleTag);
                model.Article = result.Where(i => i.Id == articleId).FirstOrDefault();

                var result2 = from t in _context.Tags
                              join a in _context.ArticleTags on t.Id equals a.TagId
                              where a.ArticleId == articleId
                              select t;
                model.ArticleTags = result2.ToList();

                var result3 = from a in _context.Admins
                              join ar in _context.Articles on a.Id equals ar.AdminId
                              where ar.Id == articleId
                              select a;
                model.Admin = result3.FirstOrDefault();
                int adminId = model.Admin.Id;



                var result4 = from a in _context.Admins
                              join sos in _context.SocialMedias on a.Id equals sos.AdminId
                              where sos.AdminId == adminId
                              select sos;

                model.SocialMedias = result4.ToList();
                model.Admin = result3.FirstOrDefault();

                return model;
            }
        }
        public TagArticleCategoryDto GetArticleCategoryTagByTagName(string tagName)
        {
            using (var _context = new GoFContext())
            {
                var model = new TagArticleCategoryDto();
                var result1 = _context.Tags
                            .Include(i => i.ArticleTag).Where(i => i.TagName == tagName);
                model.Tag = result1.FirstOrDefault();

                var result2 = from a in _context.Articles
                              join c in _context.Categories on a.CategoryId equals c.Id
                              join ar in _context.ArticleTags on a.Id equals ar.ArticleId
                              join t in _context.Tags on ar.TagId equals t.Id
                              where t.TagName == tagName
                              select new ArticleCategoryDto
                              {
                                  ArticleContent = a.ArticleContent,
                                  ArticleId = a.Id,
                                  ArticleTitle = a.ArticleTitle,
                                  CategoryName = c.Name,
                                  PublishDate = a.PublishDate,
                                  Thumbnail = a.Thumbnail,
                                  Views = a.Views,

                              };
                model.Articles = result2.ToList();
                return model;
            }

        }
        public ArticleCategoryTagAdminCommentDto GetArticleCategoryTagAdminComment(int articleId)
        {
            using (var _context = new GoFContext())
            {
                var model = new ArticleCategoryTagAdminCommentDto();
                var result = _context.Articles
                            .Include(i => i.Category)
                            .Include(i => i.ArticleTag);
                model.Article = result.Where(i => i.Id == articleId).FirstOrDefault();

                var result2 = from t in _context.Tags
                              join a in _context.ArticleTags on t.Id equals a.TagId
                              where a.ArticleId == articleId
                              select t;
                model.ArticleTags = result2.ToList();

                var result3 = from a in _context.Admins
                              join ar in _context.Articles on a.Id equals ar.AdminId
                              where ar.Id == articleId
                              select a;
                model.Admin = result3.FirstOrDefault();
                int adminId = model.Admin.Id;



                var result4 = from a in _context.Admins
                              join sos in _context.SocialMedias on a.Id equals sos.AdminId
                              where sos.AdminId == adminId
                              select sos;
                var result5 = from a in _context.Articles
                              join c in _context.Comments on a.Id equals c.ArticleId
                              where c.ArticleId == articleId
                              select c;

                //var comment = from c in _context.Comments
                //              join s in _context.SecondLevelComments on c.Id equals s.CommentId into gj
                //              from sub in gj.DefaultIfEmpty()

                //              select new CommentsComplexData
                //              {
                //                  Comments = new List<Comment>()
                //                  {
                //                     new Comment()
                //                     {
                //                          Id = c.Id,
                //                          CommentDate = c.CommentDate,
                //                          CommentDescription = c.CommentDescription,
                //                          Email = c.Email,
                //                          Name = c.Name,
                //                          ArticleId = c.ArticleId,
                //                         SecondLevelComments = new List<SecondLevelComment>()
                //                         {
                //                              new SecondLevelComment
                //                              {
                //                                 Id=sub.Id,
                //                                 CommentDate=sub.CommentDate,
                //                                 CommentDescription=sub.CommentDescription,
                //                                 CommentId=c.Id,
                //                                 Email=sub.Email,
                //                                 Name=sub.Name
                //                              }
                //                         }
                //                     }
                //                  }
                //              };
                var commentquery = _context.Comments.Where(i => i.ArticleId == articleId).ToList();
                var secondquery = _context.SecondLevelComments.ToList();
                
                model.SocialMedias = result4.ToList();
                model.Admin = result3.FirstOrDefault();
                model.allComments = commentquery;
                
                return model;
            }
        }
    }
}


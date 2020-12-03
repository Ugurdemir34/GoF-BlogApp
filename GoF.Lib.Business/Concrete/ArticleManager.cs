using GoF.Core.Utilities.Results;
using GoF.Lib.Business.Abstract;
using GoF.Lib.Business.Constants;
using GoF.Lib.DataAccess.Abstract;
using GoF.Lib.Entities.Concrete;
using GoF.Lib.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Lib.Business.Concrete
{
    public class ArticleManager : IArticleService
    {
        private IArticleDal _articleDal;
        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }
        public IResult Add(Article article)
        {
            _articleDal.Add(article);
            return new SuccessResult(Messages.Success);
        }


        public IResult Delete(Article article)
        {
            _articleDal.Delete(article);
            return new SuccessResult(Messages.Success);
        }
        public IDataResult<List<Article>> GetAll()
        {
            var articleList = _articleDal.GetList();
            return new SuccessDataResult<List<Article>>(articleList, Messages.Success);
        }

        public IDataResult<ArticleCategoryTagAdminCommentDto> GetAllArticleWithComment(int articleId)
        {
            var model = _articleDal.GetArticleCategoryTagAdminComment(articleId);
            return new SuccessDataResult<ArticleCategoryTagAdminCommentDto>(model, Messages.Success);
        }

        public IDataResult<Article> GetArticle(int articleId)
        {
            var model = _articleDal.Get(i => i.Id == articleId);
            return new SuccessDataResult<Article>(model, Messages.Success);
        }

        public IDataResult<ArticleCategoryTagAdminDto> GetArticleAll(int articleId)
        {
            var model = _articleDal.GetArticleCategoryTagAdmin(articleId);
            return new SuccessDataResult<ArticleCategoryTagAdminDto>(model, Messages.Success);
        }

        public IDataResult<List<ArticleCategoryDto>> GetArticleAndCategory()
        {
            var articleAndCategory = _articleDal.GetArticleAndCategory();
            return new SuccessDataResult<List<ArticleCategoryDto>>(articleAndCategory, Messages.Success);
        }

        public IDataResult<List<ArticleCategoryDto>> GetArticleByCategoryName(string categoryName)
        {
            var model = _articleDal.GetArticleByCategoryName(categoryName);
            return new SuccessDataResult<List<ArticleCategoryDto>>(model, Messages.Success);
        }
        public IDataResult<TagArticleCategoryDto> GetArticleByTagName(string tagName)
        {
            var model = _articleDal.GetArticleCategoryTagByTagName(tagName);
            return new SuccessDataResult<TagArticleCategoryDto>(model, Messages.Success);
        }
        public IDataResult<ArticleCategoryTagDto> GetArticleCategoryTag(int articleId)
        {
            var model = _articleDal.GetArticleAndCategoryTag(articleId);
            return new SuccessDataResult<ArticleCategoryTagDto>(model, Messages.Success);
        }
        public IResult Update(Article article)
        {
            _articleDal.Update(article);
            return new SuccessResult(Messages.Success);
        }
    }
}

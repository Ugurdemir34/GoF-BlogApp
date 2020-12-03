using GoF.Core.Utilities.Results;
using GoF.Lib.Entities.Concrete;
using GoF.Lib.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Lib.Business.Abstract
{
    public interface IArticleService
    {
        IDataResult<List<Article>> GetAll();
        IResult Add(Article article);
        IResult Update(Article article);
        IResult Delete(Article article);
        IDataResult<Article> GetArticle(int articleId);
        IDataResult<List<ArticleCategoryDto>> GetArticleAndCategory();
        IDataResult<ArticleCategoryTagDto> GetArticleCategoryTag(int articleId);
       // ArticleCategoryTagDto GetArticleCategoryTagByTagId(int tagId);
        IDataResult<ArticleCategoryTagAdminDto> GetArticleAll(int articleId);
        IDataResult<ArticleCategoryTagAdminCommentDto> GetAllArticleWithComment(int articleId);
        IDataResult<List<ArticleCategoryDto>> GetArticleByCategoryName(string categoryName);
       
        IDataResult<TagArticleCategoryDto> GetArticleByTagName(string tagName);
  

    }
}

using GoF.Core.DataAccess;
using GoF.Lib.Entities.Concrete;
using GoF.Lib.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Lib.DataAccess.Abstract
{
    public interface IArticleDal : IEntityRepository<Article>
    {
        List<ArticleCategoryDto> GetArticleAndCategory();
        ArticleCategoryTagDto GetArticleAndCategoryTag(int articleId);
        // TagArticleCategoryComplexData GetArticleAndCategoryTagByTagId(int tagId);
        ArticleCategoryTagAdminDto GetArticleCategoryTagAdmin(int articleId);
        List<ArticleCategoryDto> GetArticleByCategoryName(string categoryName);
        TagArticleCategoryDto GetArticleCategoryTagByTagName(string tagName);
        ArticleCategoryTagAdminCommentDto GetArticleCategoryTagAdminComment(int articleId);
    }
}

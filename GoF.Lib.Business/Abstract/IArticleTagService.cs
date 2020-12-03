using GoF.Core.Utilities.Results;
using GoF.Lib.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Lib.Business.Abstract
{
    public interface IArticleTagService
    {
        IDataResult<List<ArticleTag>> GetAll();
        IResult Add(ArticleTag articleTag);
        IResult Update(ArticleTag articleTag);
        IResult Delete(ArticleTag articleTag);
        IDataResult<ArticleTag> GetArticleTag(int articleTag);
        IDataResult<ArticleTag> GetArticleTagByTagId(int tagId, int articleId);
     

    }
}

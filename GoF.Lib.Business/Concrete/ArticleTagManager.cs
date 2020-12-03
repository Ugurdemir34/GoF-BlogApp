using GoF.Core.Utilities.Results;
using GoF.Lib.Business.Abstract;
using GoF.Lib.Business.Constants;
using GoF.Lib.DataAccess.Abstract;
using GoF.Lib.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Lib.Business.Concrete
{
    public class ArticleTagManager : IArticleTagService
    {
        private IArticleTagDal _articleTagDal;
        public ArticleTagManager(IArticleTagDal articleTagDal)
        {
            _articleTagDal = articleTagDal;
        }
        public IResult Add(ArticleTag articleTag)
        {
            _articleTagDal.Add(articleTag);
            return new SuccessResult(Messages.Success);
        }

        public IResult Delete(ArticleTag articleTag)
        {
            _articleTagDal.Delete(articleTag);
            return new SuccessResult(Messages.Success);

        }

        public IDataResult<List<ArticleTag>> GetAll()
        {
            var model = _articleTagDal.GetList();
            return new SuccessDataResult<List<ArticleTag>>(model, Messages.Success);

        }
        public IDataResult<ArticleTag> GetArticleTag(int articleTag)
        {
            var model = _articleTagDal.Get(i => i.Id == articleTag);
            return new SuccessDataResult<ArticleTag>(model, Messages.Success);
        }

        public IDataResult<ArticleTag> GetArticleTagByTagId(int tagId, int articleId)
        {
            var model = _articleTagDal.Get(i => i.TagId == tagId && i.ArticleId == articleId);
            return new SuccessDataResult<ArticleTag>(model, Messages.Success);
        }

        public IResult Update(ArticleTag articleTag)
        {
            _articleTagDal.Update(articleTag);
            return new SuccessResult(Messages.Success);
        }
    }
}

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
    public class TagManager : ITagService
    {
        private ITagDal _tagDal;
        public TagManager(ITagDal tagDal)
        {
            _tagDal = tagDal;
        }
        public IResult Add(Tag tag)
        {
            _tagDal.Add(tag);
            return new SuccessResult(Messages.Success);
        }
        public IResult Delete(Tag tag)
        {
            _tagDal.Delete(tag);
            return new SuccessResult(Messages.Success);
        }
        public IDataResult<List<Tag>> GetAll()
        {
            var model = _tagDal.GetList();
            return new SuccessDataResult<List<Tag>>(model, Messages.Success);
        }

        public IDataResult<Tag> GetTagById(int tagId)
        {
            var model = _tagDal.Get(i=>i.Id == tagId);
            return new SuccessDataResult<Tag>(model, Messages.Success);
        }

        public IDataResult<TagArticleTagDto> GetTagsWhichArticleDoesNotHave(int articleId)
        {
            var model = _tagDal.GetTagsWhichArticleDoesNotHave(articleId);
            return new SuccessDataResult<TagArticleTagDto>(model, Messages.Success);
        }

        public IResult Update(Tag tag)
        {
            _tagDal.Update(tag);
            return new SuccessResult(Messages.Success);

        }
    }
}

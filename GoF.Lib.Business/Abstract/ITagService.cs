using GoF.Lib.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using GoF.Core.Utilities.Results;
using GoF.Lib.Entities.Dtos;

namespace GoF.Lib.Business.Abstract
{
    public interface ITagService
    {
        IDataResult<List<Tag>> GetAll();
        IResult Add(Tag tag);
        IResult Update(Tag tag);
        IResult Delete(Tag tag);
        IDataResult<TagArticleTagDto> GetTagsWhichArticleDoesNotHave(int articleId);
        IDataResult<Tag> GetTagById(int tagId);



    }
}

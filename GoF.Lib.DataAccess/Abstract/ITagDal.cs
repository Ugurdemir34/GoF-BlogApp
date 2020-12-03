using GoF.Core.DataAccess;
using GoF.Lib.Entities.Concrete;
using GoF.Lib.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Lib.DataAccess.Abstract
{
    public interface ITagDal:IEntityRepository<Tag>
    {
        TagArticleTagDto GetTagsWhichArticleDoesNotHave(int articleId);
    }
}

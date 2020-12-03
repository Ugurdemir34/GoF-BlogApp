using GoF.Core.Utilities.Results;
using GoF.Lib.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Lib.Business.Abstract
{
    public interface ISecondLevelCommentService
    {
        IDataResult<List<SecondLevelComment>> GetAll();
        IResult Add(SecondLevelComment secondLevelComment);
        IResult Update(SecondLevelComment secondLevelComment);
        IResult Delete(SecondLevelComment secondLevelComment);
        IDataResult<SecondLevelComment> GetSecondLevelComment(int commentId);
       // SecondLevelComment GetSecondLevelCommentByArticleId(int articleId);

    }
}

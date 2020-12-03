using GoF.Core.Utilities.Results;
using GoF.Lib.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Lib.Business.Abstract
{
    public interface ICommentService
    {
        IDataResult<List<Comment>> GetAll();
        IResult Add(Comment comment);
        IResult Update(Comment comment);
        IResult Delete(Comment comment);
        IDataResult<Comment> GetComment(int commentId);
        IDataResult<Comment> GetCommentByArticleId(int articleId);

    } 
}

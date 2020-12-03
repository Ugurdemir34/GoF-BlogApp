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
    public class CommentManager : ICommentService
    {
        private ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }
        public IResult Add(Comment comment)
        {
            _commentDal.Add(comment);
            return new SuccessResult(Messages.Success);
        }

        public IResult Delete(Comment comment)
        {
            _commentDal.Delete(comment);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<Comment>> GetAll()
        {
            var model = _commentDal.GetList();
            return new SuccessDataResult<List<Comment>>(Messages.Success);
        }

        public IDataResult<Comment> GetComment(int commentId)
        {
            var model = _commentDal.Get(i => i.Id == commentId);
            return new SuccessDataResult<Comment>(model, Messages.Success);
        }

        public IDataResult<Comment> GetCommentByArticleId(int articleId)
        {
            var model = _commentDal.Get(i => i.ArticleId == articleId);
            return new SuccessDataResult<Comment>(model, Messages.Success);
        }

        public IResult Update(Comment comment)
        {
            _commentDal.Update(comment);
            return new SuccessResult(Messages.Success);
        }
    }
}

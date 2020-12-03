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
    public class SecondLevelCommentManager : ISecondLevelCommentService
    {
        private ISecondLevelCommentDal _secondLevelCommentDal;
        public SecondLevelCommentManager(ISecondLevelCommentDal secondLevelCommentDal)
        {
            _secondLevelCommentDal = secondLevelCommentDal;
        }
        public IResult Add(SecondLevelComment secondLevelComment)
        {
            _secondLevelCommentDal.Add(secondLevelComment);
            return new SuccessResult(Messages.Success);
        }
        public IResult Delete(SecondLevelComment secondLevelComment)
        {
            _secondLevelCommentDal.Delete(secondLevelComment);
            return new SuccessResult(Messages.Success);
        }
        public IDataResult<List<SecondLevelComment>> GetAll()
        {
            var model = _secondLevelCommentDal.GetList();
            return new SuccessDataResult<List<SecondLevelComment>>(model, Messages.Success);
        }
        public IDataResult<SecondLevelComment> GetSecondLevelComment(int commentId)
        {
            var model = _secondLevelCommentDal.Get(i => i.CommentId == commentId);
            return new SuccessDataResult<SecondLevelComment>(model, Messages.Success);

        }

        public IResult Update(SecondLevelComment secondLevelComment)
        {
            _secondLevelCommentDal.Update(secondLevelComment);
            return new SuccessResult(Messages.Success);
        }
    }
}

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
    public class QuestionManager : IQuestionService
    {
        private IQuestionDal _questionDal;
        public QuestionManager(IQuestionDal question)
        {
            _questionDal = question;
        }
        public IResult Add(Question question)
        {
            _questionDal.Add(question);
            return new SuccessResult(Messages.Success);
        }

        public IResult Delete(Question question)
        {
            _questionDal.Delete(question);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<Question>> GetAll()
        {
           var model =  _questionDal.GetList();
            return new SuccessDataResult<List<Question>>(model, Messages.Success);
        }

        public IDataResult<Question> GetQuestionById(int questionId)
        {
            var model = _questionDal.Get(i => i.Id == questionId);
            return new SuccessDataResult<Question>(model, Messages.Success);
        }

        public IDataResult<List<QuestionCategoryDto>> GetQuestionWithCategory()
        {
            var model = _questionDal.GetQuestionWithCategory();
            return new SuccessDataResult<List<QuestionCategoryDto>>(model, Messages.Success);
        }
    }
}

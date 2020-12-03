using GoF.Core.Utilities.Results;
using GoF.Lib.Entities.Concrete;
using GoF.Lib.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
namespace GoF.Lib.Business.Abstract
{
    public interface IQuestionService
    {
        IResult Add(Question question);
        IResult Delete(Question question);
        IDataResult<List<Question>> GetAll();
        IDataResult<List<QuestionCategoryDto>> GetQuestionWithCategory();
        IDataResult<Question> GetQuestionById(int questionId);
    }
}

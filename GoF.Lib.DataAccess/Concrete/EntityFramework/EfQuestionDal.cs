using GoF.Core.DataAccess.EntityFramework;
using GoF.Lib.DataAccess.Abstract;
using GoF.Lib.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GoF.Lib.Entities.Dtos;

namespace GoF.Lib.DataAccess.Concrete.EntityFramework
{
    public class EfQuestionDal : EfEntityRepositoryBase<Question, GoFContext>, IQuestionDal
    {
        public List<QuestionCategoryDto> GetQuestionWithCategory()
        {
            using (var _context = new GoFContext())
            {
                var result = from q in _context.Questions
                             join c in _context.Categories on q.CategoryId equals c.Id
                             orderby q.QuestionDate descending
                             select new QuestionCategoryDto
                             {
                                 QuestionId = q.Id,
                                 Mail=q.Mail,
                                 CategoryName=c.Name,
                                 Name=q.Name,
                                 Lastname=q.Lastname,
                                 QuestionContent=q.QuestionContent,
                                 QuestionDate=q.QuestionDate,
                                 QuestionSubject=q.QuestionSubject
                             };
               
                return result.ToList();              
            }
        }
    }
}

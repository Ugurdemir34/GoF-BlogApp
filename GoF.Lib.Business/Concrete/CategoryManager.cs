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
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(Messages.Success);
        }

        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<Category>> GetAll()
        {
            var model = _categoryDal.GetList();
            return new SuccessDataResult<List<Category>>(model, Messages.Success);
        }

        public IDataResult<Category> GetCategoryById(int categoryId)
        {
            var model = _categoryDal.Get(i => i.Id == categoryId);
            return new SuccessDataResult<Category>(model, Messages.Success);
        }   

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages.Success);
        }
    }
}

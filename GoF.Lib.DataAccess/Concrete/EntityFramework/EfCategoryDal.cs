using GoF.Core.DataAccess.EntityFramework;
using GoF.Lib.Entities.Concrete;
using GoF.Lib.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Lib.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal:EfEntityRepositoryBase<Category,GoFContext>,ICategoryDal
    {
        
    }
}

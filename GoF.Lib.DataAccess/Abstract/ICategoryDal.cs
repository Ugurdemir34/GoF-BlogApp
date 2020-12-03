using GoF.Core.DataAccess;
using GoF.Lib.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Lib.DataAccess.Abstract
{

    public interface ICategoryDal : IEntityRepository<Category>
    {
    }
}

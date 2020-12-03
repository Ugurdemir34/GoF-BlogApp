using GoF.Core.DataAccess.EntityFramework;
using GoF.Lib.DataAccess.Abstract;
using GoF.Lib.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Lib.DataAccess.Concrete.EntityFramework
{
    public class EfSecondLevelCommentDal : EfEntityRepositoryBase<SecondLevelComment, GoFContext>, ISecondLevelCommentDal
    {

    }
}

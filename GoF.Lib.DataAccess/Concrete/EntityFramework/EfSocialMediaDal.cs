using GoF.Core.DataAccess.EntityFramework;
using GoF.Lib.DataAccess.Abstract;
using GoF.Lib.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoF.Lib.DataAccess.Concrete.EntityFramework
{
    public class EfSocialMediaDal : EfEntityRepositoryBase<SocialMedia, GoFContext>, ISocialMediaDal
    {
        public int GetSocialMediaLastId()
        {
            using (var _context = new GoFContext())
            {
                return _context.SocialMedias.OrderByDescending(i => i.Id).First().Id;
            }
        }
    }
}

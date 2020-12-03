using GoF.Core.DataAccess;
using GoF.Core.Entities.Concrete;
using GoF.Lib.Entities.Concrete;
using GoF.Lib.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Lib.DataAccess.Abstract
{
    public interface IAdminDal :IEntityRepository<Admin>
    {
        List<OperationClaim> GetClaims(Admin admin);//JOIN OPERASYONU
        AdminSocialMediaDto GetAdminWithSocialMedia(int adminId);
      
    }
}

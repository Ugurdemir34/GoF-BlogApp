using GoF.Core.DataAccess.EntityFramework;
using GoF.Core.Entities.Concrete;
using GoF.Core.Utilities.Security.Hashing;
using GoF.Lib.DataAccess.Abstract;

using GoF.Lib.Entities.Concrete;
using GoF.Lib.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoF.Lib.DataAccess.Concrete.EntityFramework
{
    public class EfAdminDal : EfEntityRepositoryBase<Admin, GoFContext>, IAdminDal
    {
        

        public AdminSocialMediaDto GetAdminWithSocialMedia(int adminId)
        {
            using (var _context = new GoFContext())
            {
                var admn = _context.Admins.Find(adminId);
                var model = new AdminSocialMediaDto()
                {
                    Admin = new AdminForRegisterDto
                    {
                        About = admn.About,
                        Email = admn.Email,
                        FirstName = admn.Name,
                        Id = admn.Id,
                        LastName = admn.Lastname,
                        Password =admn.Password
                    },
                    SocialMedias = _context.SocialMedias.Where(i => i.AdminId == adminId).ToList()
                };
                return model;
            }
        }

        public List<OperationClaim> GetClaims(Admin admin)
        {

            using (var context = new GoFContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.AdminId == admin.Id
                             select new OperationClaim
                             {
                                 Id = operationClaim.Id,
                                 Name = operationClaim.Name
                             };
                return result.ToList();
            }
        }
    }
}

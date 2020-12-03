using GoF.Lib.Entities.Concrete;
using GoF.Core.Utilities.Results;
using GoF.Lib.Entities.Dtos;
using System.Collections.Generic;
using GoF.Core.Entities.Concrete;

namespace GoF.Lib.Business.Abstract
{
    public interface IAdminService
    {
        IDataResult<List<Admin>> GetAll();
        IResult Add(Admin admin);
        IResult Update(Admin admin);
        IResult Delete(Admin admin);
        IDataResult<Admin> GetAdmin(int adminId);      
        IDataResult<AdminSocialMediaDto> GetAdminWithSocialMedia(int adminId);
        List<OperationClaim> GetClaims(Admin admin);
        IDataResult<Admin> GetByMail(string email);
        IDataResult<Admin> GetByUserName(string userName);
        IDataResult<AdminForRegisterDto> GetAdmin(string userName, string password);        
    }
}

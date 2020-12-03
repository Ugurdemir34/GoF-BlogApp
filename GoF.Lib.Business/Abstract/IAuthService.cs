using GoF.Core.Entities.Concrete;
using GoF.Core.Utilities.Results;
using GoF.Core.Utilities.Security.Jwt;
using GoF.Lib.Entities.Concrete;
using GoF.Lib.Entities.Dtos;


namespace GoF.Lib.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<Admin> Register(AdminForRegisterDto adminForRegisterDto, string password);
        IDataResult<Admin> Login(AdminForLoginDto adminForLoginDto);
        IDataResult<Admin> UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(Admin admin);
   
    }
}

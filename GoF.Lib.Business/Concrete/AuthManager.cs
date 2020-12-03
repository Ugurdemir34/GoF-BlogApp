using GoF.Core.Entities.Concrete;
using GoF.Core.Utilities.Results;
using GoF.Core.Utilities.Security.Hashing;
using GoF.Core.Utilities.Security.Jwt;
using GoF.Lib.Business.Abstract;
using GoF.Lib.Business.Constants;
using GoF.Lib.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Lib.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IAdminService _adminService;
        private ITokenHelper _tokenHelper;
        public AuthManager(IAdminService adminService, ITokenHelper tokenHelper)
        {
            _adminService = adminService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<AccessToken> CreateAccessToken(Admin admin)
        {
            var claims = _adminService.GetClaims(admin);
            var accessToken = _tokenHelper.CreateToken(admin, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<Admin> Login(AdminForLoginDto adminForLoginDto)
        {
            var userToCheck = _adminService.GetByMail(adminForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<Admin>(Messages.UserNotFound);
            }

            return new SuccessDataResult<Admin>(userToCheck.Data, Messages.SuccessfulLogin);
        }

        public IDataResult<Admin> Register(AdminForRegisterDto adminForRegisterDto, string password)
        {


            var admin = new Admin
            {
                Email = adminForRegisterDto.Email,
                Name = adminForRegisterDto.FirstName,
                Lastname = adminForRegisterDto.LastName,
                Password = password,
                Username = adminForRegisterDto.UserName,
                About = adminForRegisterDto.About


            };
            _adminService.Add(admin);
            return new SuccessDataResult<Admin>(admin, Messages.AdminRegistered);
        }

        public IDataResult<Admin> UserExists(string email)
        {
            var model = _adminService.GetByMail(email);
            if (model != null)
            {
                return new ErrorDataResult<Admin>(model.Data, Messages.AdminAlreadyExists);
            }
            return new SuccessDataResult<Admin>(model.Data, Messages.AdminFound);
        }
    }
}

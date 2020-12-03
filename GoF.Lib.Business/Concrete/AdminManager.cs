using GoF.Lib.Business.Abstract;
using System;
using System.Collections.Generic;
using GoF.Lib.DataAccess.Abstract;
using GoF.Core.Utilities.Results;
using GoF.Lib.Business.Constants;
using GoF.Lib.Entities.Dtos;
using GoF.Core.Entities.Concrete;
using GoF.Core.Utilities.Security.Hashing;

namespace GoF.Lib.Business.Concrete
{
    public class AdminManager : IAdminService
    {
        private IAdminDal _adminDal;
        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }
        public IResult Add(Admin admin)
        {
            _adminDal.Add(admin);
            return new SuccessResult(Messages.Success);
        }

        public IResult Delete(Admin admin)
        {
            _adminDal.Delete(admin);
            return new SuccessResult(Messages.Success);
        }
        public IDataResult<Admin> GetAdmin(int adminId)
        {
            var model = _adminDal.Get(i=>i.Id==adminId);
            return new SuccessDataResult<Admin>(model, Messages.Success);
        }

        public IDataResult<AdminForRegisterDto> GetAdmin(string userName, string password)
        {
            var model = _adminDal.Get(i => i.Username == userName);
         
            if(model==null)
            {
                return new ErrorDataResult<AdminForRegisterDto>(Messages.UserNotFound);
            }
            var newModel = new AdminForRegisterDto { Email = model.Email, FirstName = model.Name, Id = model.Id, LastName = model.Lastname, Password = password, UserName = model.Username };
            return new SuccessDataResult<AdminForRegisterDto>(newModel);
        }



        public IDataResult<AdminSocialMediaDto> GetAdminWithSocialMedia(int adminId)
        {
            var model = _adminDal.GetAdminWithSocialMedia(adminId);
            return new SuccessDataResult<AdminSocialMediaDto>(model, Messages.Success);
        }
        public IDataResult<List<Admin>> GetAll()
        {
            var model = _adminDal.GetList();
            return new SuccessDataResult<List<Admin>>(model, Messages.Success);
        }

        public IDataResult<Admin> GetByMail(string email)
        {
            var model = _adminDal.Get(i => i.Email == email);
            return new SuccessDataResult<Admin>(model, Messages.Success);

        }

        public IDataResult<Admin> GetByUserName(string userName)
        {
            var model = _adminDal.Get(i => i.Username == userName);
            return new SuccessDataResult<Admin>(model, Messages.Success);
        }

        public List<OperationClaim> GetClaims(Admin admin)
        {
            return _adminDal.GetClaims(admin);
        }

        public IResult Update(Admin admin)
        {
            _adminDal.Update(admin);
            return new SuccessResult(Messages.Success);
        }

      
    }
}

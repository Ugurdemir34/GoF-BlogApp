using GoF.Core.Utilities.Results;
using GoF.Lib.Business.Abstract;
using GoF.Lib.Business.Constants;
using GoF.Lib.DataAccess.Abstract;
using GoF.Lib.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Lib.Business.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        private ISocialMediaDal _socialMediaDal;
        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public IResult Add(SocialMedia socialMedia)
        {
            _socialMediaDal.Add(socialMedia);
            return new SuccessResult(Messages.Success);

        }

        public IResult DeleteSocialMedia(SocialMedia socialMedia)
        {

            _socialMediaDal.Delete(socialMedia);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<SocialMedia> GetSocialMedia(int adminId, int socialMediaId)
        {
            var model =  _socialMediaDal.Get(i => i.AdminId == adminId && i.Id == socialMediaId);
            return new SuccessDataResult<SocialMedia>(model,Messages.Success);
        }

        public int LastId()
        {
            return _socialMediaDal.GetSocialMediaLastId();
            //mf => mf.AuditItems.OrderByDescending(ai => ai.DateOfAction).First().Step == 1);
        }
    }
}

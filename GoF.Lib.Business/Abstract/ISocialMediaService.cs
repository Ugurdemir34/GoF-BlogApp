using GoF.Core.Utilities.Results;
using GoF.Lib.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Lib.Business.Abstract
{
    public interface ISocialMediaService
    {
        IResult Add(SocialMedia socialMedia);
        IResult DeleteSocialMedia(SocialMedia socialMedia);
        IDataResult<SocialMedia> GetSocialMedia(int adminId, int socialMediaId);
        int LastId();
    }
}

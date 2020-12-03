using GoF.Core.Entities;
using GoF.Core.Entities.Concrete;
using GoF.Lib.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Lib.Entities.Dtos
{
    public class AdminSocialMediaDto:IDto
    {
        public AdminSocialMediaDto()
        {
           
        }
        public AdminForRegisterDto Admin { get; set; }
        public List<SocialMedia> SocialMedias { get; set; }
    }
}

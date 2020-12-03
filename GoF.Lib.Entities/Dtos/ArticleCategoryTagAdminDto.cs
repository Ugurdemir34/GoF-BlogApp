﻿using GoF.Core.Entities;
using GoF.Core.Entities.Concrete;
using GoF.Lib.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Lib.Entities.Dtos
{
    public class ArticleCategoryTagAdminDto : IDto
    {
        public ArticleCategoryTagAdminDto()
        {
            Admin = new Admin();
            SocialMedias = new List<SocialMedia>();
            ArticleTags = new List<Tag>();
        }
        public Article Article { get; set; }
        public List<Tag> ArticleTags { get; set; }
        public Category Category { get; set; }
        
        public Admin Admin { get; set; }
        public List<SocialMedia> SocialMedias { get; set; }
    }
}

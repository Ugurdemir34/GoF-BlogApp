using GoF.Core.Entities;
using GoF.Lib.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Lib.Entities.Dtos
{
    public class TagArticleCategoryDto : IDto
    {
        public Tag Tag { get; set; }
        public List<ArticleCategoryDto> Articles { get; set; }
    }
}

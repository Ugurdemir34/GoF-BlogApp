using GoF.Core.Entities;
using GoF.Lib.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Lib.Entities.Dtos
{
    public class TagArticleTagDto : IDto
    {
        public TagArticleTagDto()
        {
            Tags = new List<Tag>();
        }
        public List<Tag> Tags { get; set; }
    }
}

using GoF.Core.Entities;
using GoF.Lib.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Lib.Entities.Dtos
{
    public class ArticleCategoryTagDto : IDto
    {
        public Article Article { get; set; }
        public List<Tag> Tags { get; set; }

        public string CategoryName { get; set; }
        public int CategoryId { get; set; }

    }
}

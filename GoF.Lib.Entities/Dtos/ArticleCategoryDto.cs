using GoF.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Lib.Entities.Dtos
{
    public class ArticleCategoryDto : IDto
    {
        public int ArticleId { get; set; }
        public byte[] Thumbnail { get; set; }
        public string CategoryName { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleContent { get; set; }
        public int Views { get; set; }
        public DateTime PublishDate { get; set; }
        public string AdminName { get; set; }
    }
}

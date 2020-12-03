using GoF.Core.Entities;
using GoF.Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GoF.Lib.Entities.Concrete
{
    public class Article : IEntity
    {
        public int Id { get; set; }
        public byte[] Thumbnail { get; set; }
        public int CategoryId { get; set; }
        [DisplayName("Makale Başlığı")]
        public string ArticleTitle { get; set; }
        [DisplayName("Makale İçeriği")]
        public string ArticleContent { get; set; }
        [DisplayName("Görüntülenme")]
        public int Views { get; set; }
        [DisplayName("Yayım Tarihi")]
        public DateTime PublishDate { get; set; }
        [DisplayName("Yazar")]
        public int AdminId { get; set; }
        public Admin Admin { get; set; }
        public IEnumerable<ArticleTag> ArticleTag { get; set; }
        public Category Category { get; set; }
    }
}

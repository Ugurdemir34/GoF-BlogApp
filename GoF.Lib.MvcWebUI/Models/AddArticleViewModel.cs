using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GoF.Lib.MvcWebUI.Models
{
    public class AddArticleViewModel
    {
        public int Id { get; set; }
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
        [DisplayName("Kategori")]
        public List<SelectListItem> Categories { get; set; }
        [DisplayName("Yazar")]
        public List<SelectListItem> Author { get; set; }
        public IFormFile FormFiles { get; set; }
    }
}

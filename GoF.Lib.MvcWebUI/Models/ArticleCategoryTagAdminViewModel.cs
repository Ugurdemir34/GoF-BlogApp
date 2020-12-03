
using GoF.Lib.Entities.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoF.Lib.MvcWebUI.Models
{
    public class ArticleCategoryTagAdminViewModel
    {
        public ArticleCategoryTagAdminViewModel()
        {

        }
        public ArticleCategoryTagAdminDto ArticleAll { get; set; }
    }
}

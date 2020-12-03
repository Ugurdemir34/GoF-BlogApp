using GoF.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Lib.Entities.Concrete
{
    public class Tag :IEntity
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public  List<ArticleTag> ArticleTag { get; set; }
    }
}

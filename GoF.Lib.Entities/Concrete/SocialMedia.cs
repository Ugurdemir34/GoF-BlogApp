using GoF.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GoF.Lib.Entities.Concrete
{
    public class SocialMedia :IEntity
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        [DisplayName("İkon")]
        public string LogoClass { get; set; }
        [DisplayName("Link")]
        public string Link { get; set; }
    }
}

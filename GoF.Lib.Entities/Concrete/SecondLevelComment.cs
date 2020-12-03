using GoF.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Lib.Entities.Concrete
{
    public class SecondLevelComment:IEntity
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentDescription { get; set; }
      

    }
}

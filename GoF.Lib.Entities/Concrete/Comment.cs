using GoF.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GoF.Lib.Entities.Concrete
{
    public class Comment: IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime CommentDate { get; set; }
        [Required]
        public string CommentDescription { get; set; }
        [Required]
        public int ArticleId { get; set; }
        public virtual ICollection<SecondLevelComment> SecondLevelComments { get; set; }


    }
}

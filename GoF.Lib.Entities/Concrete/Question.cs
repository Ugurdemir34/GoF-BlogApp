using GoF.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Lib.Entities.Concrete
{
    public class Question : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string QuestionSubject { get; set; }
        public string QuestionContent { get; set; }
        public DateTime QuestionDate { get; set; }
        public string Mail { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
    }
}

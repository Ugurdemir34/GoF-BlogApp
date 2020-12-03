using GoF.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Lib.Entities.Dtos
{
    public class QuestionCategoryDto : IDto
    {
        public int QuestionId { get; set; }
        public string CategoryName { get; set; }
        public string QuestionSubject { get; set; }
        public string QuestionContent { get; set; }
        public DateTime QuestionDate { get; set; }
        public string Mail { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
    }
}

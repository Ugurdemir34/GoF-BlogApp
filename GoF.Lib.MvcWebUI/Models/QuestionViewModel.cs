
using GoF.Lib.Entities.Concrete;
using GoF.Lib.Entities.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoF.Lib.MvcWebUI.Models
{
    public class QuestionViewModel
    {
        public QuestionViewModel()
        {
            Question = new Question();
        }
        public Question Question { get; set; }
        public List<QuestionCategoryDto> Questions { get; set; }
        public List<SelectListItem> Categories { get; set; }

    }
}

using GoF.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Lib.Entities.Dtos
{
    public class AdminForLoginDto:IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

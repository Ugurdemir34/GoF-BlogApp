using GoF.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Core.Entities.Concrete
{
    public class Admin :IEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
     
        public string About { get; set; }
      
    }
}

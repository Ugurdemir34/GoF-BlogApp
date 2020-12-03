using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoF.Lib.MvcWebUI.Models
{
    public class AdministratorViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }
        public string Email { get; set; }
    }
}

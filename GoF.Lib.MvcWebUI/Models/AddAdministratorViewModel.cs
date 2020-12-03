using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoF.Lib.MvcWebUI.Models
{
    public class AddAdministratorViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string About { get; set; }
        public string Email { get; set; }
    }
}

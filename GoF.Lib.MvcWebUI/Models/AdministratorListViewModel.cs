using System.Collections.Generic;
using GoF.Core.Entities.Concrete;
namespace GoF.Lib.MvcWebUI.Models
{
    public class AdministratorListViewModel
    {
        public AdministratorListViewModel()
        {
            Admins = new List<AdministratorViewModel>();
        }
        public List<AdministratorViewModel> Admins { get; set; }
    }
}

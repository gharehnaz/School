using ESchool.Application.Application.Contracts.Account;
using ESchool.Application.Application.Contracts.School;
using System.Collections.Generic;

namespace ESchool.Web.Areas.Admin.Models
{
    public class SchoolIndexViewModel
    {
        public SchoolIndexViewModel()
        {
            Account =new List<AccountViewModel>();
            School = new List<SchoolViewModel>();
        }
        public List<AccountViewModel> Account { get; set; }
        public List<SchoolViewModel> School { get; set; }
    }
}

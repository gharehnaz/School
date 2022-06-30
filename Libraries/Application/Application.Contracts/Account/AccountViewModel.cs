using ESchool.Application.Application.Contracts.Role;
using ESchool.Application.Application.Contracts.School;
using System.Collections.Generic;

namespace ESchool.Application.Application.Contracts.Account
{
    public class AccountViewModel
    {

        public AccountViewModel()
        {
            Roles = new List<RoleViewModel>();
        }
        public long Id { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Mobile { get; set; }
        public long RoleId { get; set; }
        public string Role { get; set; }
        public string ProfilePhoto { get; set; }
        public string CreationDate { get; set; }
        public List<RoleViewModel> Roles { get ; set; }
        public string SchoolName { get; set; }
        public long SchoolCode { get; set; }



    }

}

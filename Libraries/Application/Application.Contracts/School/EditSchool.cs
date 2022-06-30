using ESchool.Application.Application.Contracts.Account;
using System.Collections.Generic;

namespace ESchool.Application.Application.Contracts.School
{
    public class EditSchool : CreateSchool
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public List<AccountViewModel> Managers { get; set; }
    }
  
}

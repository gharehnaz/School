using ESchool.Application.Application.Contracts.Account;
using System.Collections.Generic;

namespace ESchool.Application.Application.Contracts.School
{
    public class SchoolViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public long AccountId { get; set; }
 
    }
}

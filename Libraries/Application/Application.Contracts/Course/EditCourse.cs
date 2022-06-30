using ESchool.Application.Application.Contracts.Account;
using System.Collections.Generic;

namespace ESchool.Application.Application.Contracts.Course
{
    public class EditCourse : CreateCourse
    {
        public EditCourse()
        {
            Teachers = new List<AccountViewModel>();
        }
        public long Id { get; set; }
        public long AccountId { get; set; }
        public List<AccountViewModel> Teachers { get; set; }
    }
}

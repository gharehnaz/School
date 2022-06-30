using ESchool.Application.Application.Contracts.Role;
using System.Collections.Generic;

namespace ESchool.Application.Application.Contracts.Course
{
    public class CourseViewModel
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public string Fullname { get; set; }
        public string Code { get; set; }

    }

}

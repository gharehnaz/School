using ESchool.Application.Application.Contracts.School;
using System.Collections.Generic;

namespace ESchool.Application.Application.Contracts.ClassRoom
{
    public class CreateClassRoom
    {
        public string Name { get; set; }
        public string Level { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public int SchoolCode { get; set; }
        public long SchoolId { get; set; }
        public List<SchoolViewModel> Schools { get; set; }
    }
}

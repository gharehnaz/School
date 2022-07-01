using ESchool.Application.Application.Contracts.Student;

namespace ESchool.Application.Application.Contracts.ClassRoom
{
    public class ClassRoomViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string Level { get; set; }
        public int SchoolCode { get; set; }
        public string School { get; set; }
        public long SchoolId { get; set; }
        public StudentViewModel Student { get; set; }

    }
}

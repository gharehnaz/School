using ESchool.Domain.AccountAgg;
using ESchool.Domain.CourseAgg;
using ESchool.Domain.SchoolAgg;
using System.Collections.Generic;

namespace ESchool.Domain.ClassRoomAgg
{
    public class ClassRoom:BaseEntity
    {
        public string Name { get; private set; }
        public int Number { get; private set; }
        public string Level { get; private set; }
        public string Description { get; private set; }
        public int SchoolCode { get; private set; }
        public long SchoolId { get; private set; }
        public School School { get; private set; }
        public List<Student> Students { get; set; }
        public List<Course> Courses { get; set; }

        public ClassRoom()
        {
            Students = new List<Student>();
            Courses = new List<Course>();
        }
        public ClassRoom(string name, int number, string level, string description,long schoolId,int schoolCode)
        {
            Name = name;
            Number = number;
            Level = level;
            Description = description;
            SchoolId = schoolId;
            SchoolCode = schoolCode;
        }
        public void Edit(string name, int number,string level, string description, long schoolId, int schoolCode)
        {
            Name = name;
            Number= number;
            Level = level;
            Description = description;
            SchoolId = schoolId;
            SchoolCode = schoolCode;

        }
    }
}

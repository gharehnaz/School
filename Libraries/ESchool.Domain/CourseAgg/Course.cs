using ESchool.Domain.AccountAgg;
using ESchool.Domain.ClassRoomAgg;

namespace ESchool.Domain.CourseAgg
{
    public class Course : BaseEntity
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public long ClassRoomId { get; private set; }
        public ClassRoom ClassRoom { get; private set; }
        public long? AccountId { get; private set; }
        public Account Account { get; set; }
        public Course(string name,string code,long classRoomId)
        {
            Name = name;
            Code = code;
            ClassRoomId=classRoomId;          
        }

        public void Edit(string name, string code, long classRoomId,long accountId)
        {
            Name = name;
            Code = code;
            ClassRoomId = classRoomId;
            AccountId = accountId;
        }

    }
}

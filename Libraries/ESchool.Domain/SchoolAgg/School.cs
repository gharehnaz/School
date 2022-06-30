using ESchool.Domain.AccountAgg;
using ESchool.Domain.ClassRoomAgg;
using System.Collections.Generic;

namespace ESchool.Domain.SchoolAgg
{
    public class School:BaseEntity
    {
        public string Name { get; private set; }
        public int Code { get; private set; }
        public string Description { get; private set; }
        public long AccountId { get; private set; }
        public List<Account> Accounts { get; set; }
        public List<ClassRoom> ClassRooms { get; set; }
        public School()
        {
            ClassRooms=new List<ClassRoom>();
            Accounts=new List<Account>();
        }
        public School(string name, int code, string description)
        {
            Name = name;
            Code = code;
            Description = description;
        }
        public void Edit(string name, int code, string description, long accountId)
        {
            Name = name;
            Code= code;
            Description = description;
            AccountId = accountId;
        }
        

    }
}

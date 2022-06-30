using ESchool.Domain.ClassRoomAgg;
using ESchool.Domain.RoleAgg;

namespace ESchool.Domain.AccountAgg
{
    public class Student : BaseEntity
    {
        public string Name { get; private set; }
        public string Family { get; private set; }
        public int NationalCode { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Mobile { get; private set; }
        public string ProfilePhoto { get; private set; }
        public long ClassRoomId { get; private set; }
        public ClassRoom ClassRoom { get; private set; }
        public Student(string name, string family, int nationalCode, string username,  string mobile,
             string profilePhoto,long classRoomId)
        {
            Name = name;
            Family = family;
            NationalCode = nationalCode;
            Username = username;
            Mobile = mobile;           
            ProfilePhoto = profilePhoto;
            ClassRoomId=classRoomId;          
        }

        public void Edit(string name, string family, int nationalCode, string username, string mobile,
             string profilePhoto, long classRoomId)
        {
            Name = name;
            Family = family;
            NationalCode = nationalCode;
            Username = username;
            Mobile = mobile;
            ClassRoomId = classRoomId;

            if (!string.IsNullOrWhiteSpace(profilePhoto))
                ProfilePhoto = profilePhoto;
        }

    }
}

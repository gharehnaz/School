using ESchool.Application.Application.Contracts.ClassRoom;
using ESchool.Application.Application.Contracts.Role;
using System.Collections.Generic;

namespace ESchool.Application.Application.Contracts.Student
{
    public class StudentViewModel
    {

        public StudentViewModel()
        {
            Roles = new List<RoleViewModel>();
            ClassRooms= new List<ClassRoomViewModel>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public int NationalCode { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Mobile { get; set; }
        public long RoleId { get; set; }
        public string Role { get; set; }
        public string ProfilePhoto { get; set; }
        public string CreationDate { get; set; }
        public List<RoleViewModel> Roles { get ; set; }
        public List<ClassRoomViewModel> ClassRooms { get; set; }
        public string ClassRoomName { get; set; }



    }

}

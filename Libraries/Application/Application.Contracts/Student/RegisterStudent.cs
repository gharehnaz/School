using ESchool.Application.Application.Contracts.ClassRoom;
using ESchool.Application.Application.Contracts.Role;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ESchool.Application.Application.Contracts.Student
{
    public class RegisterStudent
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public int  NationalCode { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public long RoleId { get; set; }
        public IFormFile ProfilePhoto { get; set; }
        public List<RoleViewModel> Roles { get; set; }
        public long ClassRoomId { get; set; }
        public List<ClassRoomViewModel> ClassRooms { get; set; }
    }
}

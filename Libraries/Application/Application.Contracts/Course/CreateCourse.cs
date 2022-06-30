using ESchool.Application.Application.Contracts.ClassRoom;
using ESchool.Application.Application.Contracts.Role;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ESchool.Application.Application.Contracts.Course
{
    public class CreateCourse
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public long ClassRoomId { get; set; }
        public List<ClassRoomViewModel> ClassRooms { get; set; }
    }
}

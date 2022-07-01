﻿using ESchool.Domain.CourseAgg;
using ESchool.Domain.RoleAgg;
using ESchool.Domain.SchoolAgg;
using System.Collections.Generic;

namespace ESchool.Domain.AccountAgg
{
    public class Account : BaseEntity
    {
        public string Fullname { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Mobile { get; private set; }
        public long RoleId { get; private set; }
        public Role Role { get; private set; }
        public long? SchoolId { get; private set; }
        public School School { get; private set; }
        public long? CourseId { get; private set; }
        public List<Course> Courses { get; private set; }
        public string ProfilePhoto { get; private set; }
        public Account()
        {
            Courses=new List<Course>();
        }

        public Account(string fullname, string username, string password, string mobile,
            long roleId, string profilePhoto,long schoolId)
        {
            Fullname = fullname;
            Username = username;
            Password = password;
            Mobile = mobile;
            RoleId = roleId;
            SchoolId=schoolId;

            if (roleId == 0)
                RoleId = 2;
            
            ProfilePhoto = profilePhoto;
        }

        public void Edit(string fullname, string username, string mobile,
            long roleId, string profilePhoto)
        {
            Fullname = fullname;
            Username = username;
            Mobile = mobile;
            RoleId = roleId;

            if (!string.IsNullOrWhiteSpace(profilePhoto))
                ProfilePhoto = profilePhoto;
        }

        public void ChangePassword(string password)
        {
            Password = password;
        }
    }
}

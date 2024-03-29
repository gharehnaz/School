﻿using ESchool.Application.Application.Contracts.Role;
using ESchool.Application.Application.Contracts.School;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ESchool.Application.Application.Contracts.Account
{
    public class RegisterAccount
    {
        public string Fullname { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Mobile { get; set; }

        public long RoleId { get; set; }
        public List<SchoolViewModel> Schooles { get; set; }
        public long SchoolId { get; set; }

        public IFormFile ProfilePhoto { get; set; }
        public List<RoleViewModel> Roles { get; set; }
    }
}

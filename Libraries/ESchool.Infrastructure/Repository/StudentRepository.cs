using ESchool.Application.Application.Contracts.Account;
using ESchool.Application.Application.Contracts.Student;
using ESchool.Application.IRepository;
using ESchool.Domain.AccountAgg;
using ESchool.Infrastructure.Context;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ESchool.Infrastructure.Repository
{
    public class StudentRepository : RepositoryBase<long, Student>, IStudentRepository
    {
        private readonly ESchoolContext _context;

        public StudentRepository(ESchoolContext context) : base(context)
        {
            _context = context;
        }

        public Student GetBy(string name)
        {
            return _context.Students.FirstOrDefault(x => x.Name == name);
        }

        public EditStudent GetDetails(long id)
        {
            return _context.Students.Select(x => new EditStudent
            {
                Id = x.Id,
                Name = x.Name,
                Family=x.Family,
                NationalCode=x.NationalCode,
                Mobile = x.Mobile,
                Password = x.Password,
                Username = x.Username
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<StudentViewModel> GetStudents()
        {
            return _context.Students.Select(x => new StudentViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Family= x.Family,
                NationalCode = x.NationalCode,
                
            }).ToList();
        }
   
        public List<StudentViewModel> Search(StudentSearchModel searchModel)
        {
            var query = _context.Students.Select(x => new StudentViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Family= x.Family,
                NationalCode=x.NationalCode,
                Mobile = x.Mobile,
                ProfilePhoto = x.ProfilePhoto,
                Username = x.Username,
                CreationDate = x.CreationDate.ToString(),
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.Family))
                query = query.Where(x => x.Username.Contains(searchModel.Family));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
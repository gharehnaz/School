using ESchool.Application.Application.Contracts.ClassRoom;
using ESchool.Application.IRepository;
using ESchool.Domain.ClassRoomAgg;
using ESchool.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

using Framework.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using ESchool.Domain.SchoolAgg;
using ESchool.Domain.CourseAgg;
using ESchool.Application.Application.Contracts.Course;

namespace ESchool.Infrastructure.Repository
{
    public class CourseRepository : RepositoryBase<long, Course>, ICourseRepository
    {
        private readonly ESchoolContext _context;

        public CourseRepository(ESchoolContext context) : base(context)
        {
            _context = context;
        }
        public List<CourseViewModel> GetCourse()
        {
            return _context.Courses.Select(x => new CourseViewModel
            {
                    Id = x.Id,
                    Name = x.Name,
                    Code=x.Code,
                    Fullname=x.Account.Fullname,
                    }).ToList();
        }

        public EditCourse GetDetails(long id)
        {
            return _context.Courses.Select(x => new EditCourse()
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                ClassRoomId = x.ClassRoomId,
                
            }).FirstOrDefault(x => x.Id == id);
        }

    

        public List<CourseViewModel> Search(CourseSearchModel searchModel)
        {
            var query = _context.Courses.Select(x => new CourseViewModel
            {
               Id = x.Id,
               Name = x.Name,
               Code = x.Code,
             });

               if (!string.IsNullOrWhiteSpace(searchModel.Name))
                   query = query.Where(x => x.Name.Contains(searchModel.Name));

               return query.OrderByDescending(x => x.Id).ToList();
        }

    }
}

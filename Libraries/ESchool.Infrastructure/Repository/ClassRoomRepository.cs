using ESchool.Application.Application.Contracts.ClassRoom;
using ESchool.Application.IRepository;
using ESchool.Domain.ClassRoomAgg;
using ESchool.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

using Framework.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using ESchool.Domain.SchoolAgg;

namespace ESchool.Infrastructure.Repository
{
    public class ClassRoomRepository : RepositoryBase<long, ClassRoom>, IClassRoomRepository
    {
        private readonly ESchoolContext _context;

        public ClassRoomRepository(ESchoolContext context) : base(context)
        {
            _context = context;
        }

        //public long FindSchoolId(int schoolCode)
        //{
        //    var code= _context.Schools.Any(x=>x.Code==schoolCode);
        //    var result = _context.ClassRooms.Include(x => x.School).FirstOrDefault(x => x.Code == schoolCode);
        //    var src = result.Id;
        //    return src;
        //}
        public long GetSchoolIdWithSchoolCode(int schoolCode)
        {
            var result= _context.Schools.Include(x => x.ClassRooms).FirstOrDefault(x => x.Code == schoolCode);
            var code = result.Id;
            return code;
        }

        public List<ClassRoomViewModel> GetClassRoom()
        {
            return _context.ClassRooms.Select(x => new ClassRoomViewModel
            {
                    Id = x.Id,
                    Name = x.Name,
                    Number = x.Number,
                    SchoolId=x.SchoolId,
                    SchoolCode=x.SchoolCode,
                    Level = x.Level,
                    }).ToList();
        }
        public List<ClassRoomViewModel> GetClassRoom(long id)
        {
            return _context.ClassRooms.Where(x=>x.School.AccountId==id).Select(x => new ClassRoomViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Number = x.Number,
                SchoolId = x.SchoolId,
                SchoolCode = x.SchoolCode,
                Level = x.Level,
            }).ToList();
        }

        public EditClassRoom GetDetails(long id)
        {
            return _context.ClassRooms.Select(x => new EditClassRoom()
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name,
                Number = x.Number,
                SchoolId = x.SchoolId,
                Level = x.Level,
                SchoolCode = x.SchoolCode,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ClassRoomViewModel> Search(ClassRoomSearchModel searchModel)
        {
            var query = _context.ClassRooms.Select(x => new ClassRoomViewModel
            {
               Id = x.Id,
               Name = x.Name,
               Number = x.Number,
             });

               if (!string.IsNullOrWhiteSpace(searchModel.Name))
                   query = query.Where(x => x.Name.Contains(searchModel.Name));

               return query.OrderByDescending(x => x.Id).ToList();
        }

    }
}

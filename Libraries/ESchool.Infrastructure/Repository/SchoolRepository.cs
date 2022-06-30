using ESchool.Application.Application.Contracts.School;
using ESchool.Application.IRepository;
using ESchool.Domain.SchoolAgg;
using ESchool.Infrastructure.Context;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace ESchool.Infrastructure.Repository
{
    public class SchoolRepository : RepositoryBase<long, School>, ISchoolRepository
    {
        private readonly ESchoolContext _context;

        public SchoolRepository(ESchoolContext context) : base(context)
        {
            _context = context;
        }

        public List<SchoolViewModel> GetSchool()
        {
            return _context.Schools
            .Select(x => new SchoolViewModel
            {
                Id= x.Id,
                Name = x.Name,
                Code = x.Code,
                AccountId = x.AccountId,    
            }).ToList();
        }

        public EditSchool GetDetails(long id)
        {
            return _context.Schools.Select(x => new EditSchool()
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name,
                Code = x.Code,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<SchoolViewModel> Search(SchoolSearchModel searchModel)
        {
            var query = _context.Schools.Select(x => new SchoolViewModel
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

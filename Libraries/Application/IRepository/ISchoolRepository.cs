using ESchool.Application.Application.Contracts.School;
using ESchool.Domain.SchoolAgg;
using Framework.Application;
using System.Collections.Generic;


namespace ESchool.Application.IRepository
{
    public interface ISchoolRepository: IRepositoryBase<long, School>
    {
        EditSchool GetDetails(long id);
        List<SchoolViewModel> GetSchool();
        List<SchoolViewModel> Search(SchoolSearchModel searchModel);
    }
}

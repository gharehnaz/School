using Framework.Application;
using System.Collections.Generic;

namespace ESchool.Application.Application.Contracts.School
{
    public interface ISchoolApplication
    {
        OperationResult Create(CreateSchool command);
        OperationResult Edit(EditSchool command);
        OperationResult Delete(DeleteSchool command);
        EditSchool GetDetails(long id);
        List<SchoolViewModel> GetSchool();
        List<SchoolViewModel> Search(SchoolSearchModel searchModel);
    }
}

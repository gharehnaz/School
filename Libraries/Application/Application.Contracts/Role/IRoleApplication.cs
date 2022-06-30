using ESchool.Application.Application.Contracts.Account;
using Framework.Application;
using System.Collections.Generic;

namespace ESchool.Application.Application.Contracts.Role
{
    public interface IRoleApplication
    {
        OperationResult Create(CreateRole command);
        OperationResult Edit(EditRole command);
        OperationResult Delete(DeleteRole command);
        
        List<RoleViewModel> List();
       
        EditRole GetDetails(long id);
        List<RoleViewModel> Search(RoleSearchModel searchModel);

    }
}

using ESchool.Application.Application.Contracts.Account;
using ESchool.Application.Application.Contracts.Role;
using ESchool.Domain.RoleAgg;
using Framework.Application;
using System.Collections.Generic;

namespace ESchool.Application.IRepository
{
    public interface IRoleRepository : IRepositoryBase<long, Role>
    {
        List<RoleViewModel> List();
        EditRole GetDetails(long id);

        List<RoleViewModel> Search(RoleSearchModel searchModel);

    }
}

using ESchool.Application.Application.Contracts.Account;
using ESchool.Domain.AccountAgg;
using Framework.Application;
using System.Collections.Generic;

namespace ESchool.Application.IRepository
{
    public interface IAccountRepository : IRepositoryBase<long, Account>
    {
        Account GetBy(string username);
        EditAccount GetDetails(long id);
        List<AccountViewModel> GetAccounts();
        List<AccountViewModel> GetManagers();
        List<AccountViewModel> GetTeachers();
        List<AccountViewModel> GetTeachers(long id);
        AccountViewModel GetAccountByName(string name);
        long GetSchoolIdByAccountId(long id);
        List<AccountViewModel> Search(AccountSearchModel searchModel);
        int GetSchoolCodeByAccountId(long id);
    }
}

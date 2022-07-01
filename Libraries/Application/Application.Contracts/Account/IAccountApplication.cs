using Framework.Application;
using System.Collections.Generic;

namespace ESchool.Application.Application.Contracts.Account
{
    public interface IAccountApplication
    {
        AccountViewModel GetAccountBy(long id);
        OperationResult Register(RegisterAccount command, long id);
        OperationResult Edit(EditAccount command);
        OperationResult Delete(DeleteAccount command);
        OperationResult ChangePassword(ChangePassword command);
        OperationResult Login(Login command);
        EditAccount GetDetails(long id);
        List<AccountViewModel> Search(AccountSearchModel searchModel);
        void Logout();
        List<AccountViewModel> GetAccounts();
        List<AccountViewModel> GetManagers();
        List<AccountViewModel> GetTeachers();
        List<AccountViewModel> GetTeachers(long id);
        long GetSchoolIdBy(long id);
        int GetSchoolCodeIdByAccountId(long id);
    }
}

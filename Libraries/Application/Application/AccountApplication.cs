using ESchool.Application.Application.Contracts.Account;
using ESchool.Application.IRepository;
using ESchool.Domain.AccountAgg;
using Framework.Application;
using System.Collections.Generic;
using System.Linq;

namespace ESchool.Application.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAccountRepository _accountRepository;
        private readonly IAuthHelper _authHelper;
        private readonly IRoleRepository _roleRepository;

        public AccountApplication(IAccountRepository accountRepository, IPasswordHasher passwordHasher,
            IFileUploader fileUploader, IAuthHelper authHelper, IRoleRepository roleRepository)
        {
            _authHelper = authHelper;
             _roleRepository = roleRepository;
            _fileUploader = fileUploader;
            _passwordHasher = passwordHasher;
            _accountRepository = accountRepository;
        }

        public OperationResult ChangePassword(ChangePassword command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account == null)
                return operation.Failed("");

            if (command.Password != command.RePassword)
                return operation.Failed("");

            var password = _passwordHasher.Hash(command.Password);
            account.ChangePassword(password);
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }

        public AccountViewModel GetAccountBy(long id)
        {
            var account = _accountRepository.Get(id);
            return new AccountViewModel()
            {
                Fullname = account.Fullname,
                Mobile = account.Mobile
            };
        }
        public long GetSchoolIdBy(long id)
        {
            var schoolId = _accountRepository.GetSchoolIdByAccountId(id);
            return schoolId;
        }

        public OperationResult Register(RegisterAccount command,long id)
        {
            var operation = new OperationResult();

            if (_accountRepository.Exists(x => x.Username == command.Username || x.Mobile == command.Mobile))
                return operation.Failed("");
            var password = _passwordHasher.Hash(command.Password);
            var path = $"profilePhotos";
            var picturePath = _fileUploader.Upload(command.ProfilePhoto, path);
            var account = new Account(command.Fullname, command.Username, password, command.Mobile, command.RoleId,
                picturePath,command.SchoolId);
            _accountRepository.Create(account);
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }
       
        public OperationResult Edit(EditAccount command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account == null)
                return operation.Failed("");

            if (_accountRepository.Exists(x =>
                (x.Username == command.Username || x.Mobile == command.Mobile) && x.Id != command.Id))
                return operation.Failed("");

            var path = $"profilePhotos";
            var picturePath = _fileUploader.Upload(command.ProfilePhoto, path);
            account.Edit(command.Fullname, command.Username, command.Mobile, command.RoleId, picturePath);
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Delete(DeleteAccount command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            _accountRepository.DeleteRecord(account);
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }
        public EditAccount GetDetails(long id)
        {
            return _accountRepository.GetDetails(id);
        }

        public OperationResult Login(Login command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.GetBy(command.Username);
            if (account == null)
                return operation.Failed("");

            var result = _passwordHasher.Check(account.Password, command.Password);
            if (!result.Verified)
                return operation.Failed("");

            var permissions = _roleRepository.Get(account.RoleId)
                .Permissions
                .Select(x => x.Code)
                .ToList();

            var authViewModel = new AuthViewModel(account.Id, account.RoleId, account.Fullname
                , account.Username, account.Mobile, permissions);

            _authHelper.Signin(authViewModel);
            return operation.Succedded();
        }

        public void Logout()
        {
            _authHelper.SignOut();
        }

        public List<AccountViewModel> GetAccounts()
        {

            return _accountRepository.GetAccounts();
        }
        public List<AccountViewModel> GetManagers()
        {

            return _accountRepository.GetManagers();
        }
        public List<AccountViewModel> GetTeachers()
        {

            return _accountRepository.GetTeachers();
        }
        public List<AccountViewModel> GetTeachers(long id)
        {

            return _accountRepository.GetTeachers(id);
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            return _accountRepository.Search(searchModel);
        }
    }
}
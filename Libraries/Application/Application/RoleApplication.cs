
using ESchool.Application.Application.Contracts.Account;
using ESchool.Application.Application.Contracts.Role;
using ESchool.Application.IRepository;
using ESchool.Domain.RoleAgg;
using Framework.Application;
using System.Collections.Generic;

namespace ESchool.Application.Application
{
    public class RoleApplication : IRoleApplication
    {
        private readonly IRoleRepository _roleRepository;

        public RoleApplication(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public OperationResult Create(CreateRole command)
        {
            var operation = new OperationResult();
            if (_roleRepository.Exists(x => x.Name == command.Name))
                return operation.Failed("");
           
            var role = new Role(command.Name, new List<Permission>());
            _roleRepository.Create(role);
           
            _roleRepository.SaveChanges();
            return operation.Succedded();
        }
       
        public OperationResult Delete(DeleteRole command)
        {
            var operation = new OperationResult();
            var account = _roleRepository.Get(command.Id);
            _roleRepository.DeleteRecord(account);
            _roleRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditRole command)
        {
            var operation = new OperationResult();
            var role = _roleRepository.Get(command.Id);
            if (role == null)
                return operation.Failed("");

            if (_roleRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed("");

            var permissions = new List<Permission>();
            command.Permissions.ForEach(code => permissions.Add(new Permission(code)));

            role.Edit(command.Name, permissions);
            _roleRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditRole GetDetails(long id)
        {
            return _roleRepository.GetDetails(id);
        }

        public List<RoleViewModel> List()
        {
            return _roleRepository.List();
        }

        public List<RoleViewModel> Search(RoleSearchModel searchModel)
        {
            return _roleRepository.Search(searchModel); ;
        }
    }
}
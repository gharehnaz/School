using ESchool.Domain.AccountAgg;
using System.Collections.Generic;

namespace ESchool.Domain.RoleAgg
{
    public class Role : BaseEntity
    {
        public string Name { get; private set; }
        public List<Permission> Permissions { get; private set; }
        public List<Account> Accounts { get; private set; }

        protected Role()
        {
            
        }
        public Role(string name)
        {
            Name = name;
            Accounts = new List<Account>();
        }
        public Role(string name, List<Permission> permissions)
        {
            Name = name;
            Permissions = permissions;
            Accounts = new List<Account>();
        }

        public void Edit(string name, List<Permission> permissions)
        {
            Name = name;
            Permissions = permissions;
        }
    }
}
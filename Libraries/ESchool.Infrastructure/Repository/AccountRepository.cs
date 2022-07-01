using ESchool.Application.Application.Contracts.Account;
using ESchool.Application.IRepository;
using ESchool.Domain.AccountAgg;
using ESchool.Infrastructure.Context;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ESchool.Infrastructure.Repository
{
    public class AccountRepository : RepositoryBase<long, Account>, IAccountRepository
    {
        private readonly ESchoolContext _context;

        public AccountRepository(ESchoolContext context) : base(context)
        {
            _context = context;
        }
        public long GetSchoolIdByAccountId(long id)
        {
            var result = _context.Schools.Single(x => x.AccountId == id);
            var schoolId=result.Id;
            return schoolId;

        }
        public Account GetBy(string username)
        {
            return _context.Accounts.FirstOrDefault(x => x.Username == username);
        }

        public EditAccount GetDetails(long id)
        {
            return _context.Accounts.Select(x => new EditAccount
            {
                Id = x.Id,
                Fullname = x.Fullname,
                Mobile = x.Mobile,
                RoleId = x.RoleId,
                Password = x.Password,
                Username = x.Username
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<AccountViewModel> GetAccounts()
        {
            return _context.Accounts.Select(x => new AccountViewModel
            {
                Id = x.Id,
                Fullname = x.Fullname,
                RoleId=x.RoleId,
                Role=x.Role.Name,         
            }).ToList();
        }

        public List<AccountViewModel> GetManagers()
        {
            return _context.Accounts.Where(x=>x.Role.Name=="مدیر مدرسه").Select(x => new AccountViewModel
            {
                Id = x.Id,
                Fullname = x.Fullname,
                RoleId = x.RoleId,
                Role = x.Role.Name,
            }).ToList();
        }
        public List<AccountViewModel> GetTeachers()
        {
            return _context.Accounts.Where(x => x.Role.Name == "معلم").Select(x => new AccountViewModel
            {
                Id = x.Id,
                Fullname = x.Fullname,
                RoleId = x.RoleId,
                Role = x.Role.Name,
            }).ToList();
        }
        public List<AccountViewModel> GetTeachers(long id)
        {
            return _context.Accounts.Where(x =>  x.School.AccountId == id ).Select(x => new AccountViewModel
            {
                Id = x.Id,
                Fullname = x.Fullname,
                RoleId = x.RoleId,
                Role = x.Role.Name,
            }).ToList();
        }
        public AccountViewModel GetAccountByName(string name)
        {
            return _context.Accounts.Select(x => new AccountViewModel
            {
                Id = x.Id,
                Fullname = x.Fullname,
                RoleId = x.RoleId,
                Role = x.Role.Name,
            }).FirstOrDefault(x=>x.Username==name);
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            var query = _context.Accounts.Include(x => x.Role).Select(x => new AccountViewModel
            {
                Id = x.Id,
                Fullname = x.Fullname,
                Mobile = x.Mobile,
                ProfilePhoto = x.ProfilePhoto,
                Role = x.Role.Name,
                RoleId = x.RoleId,
                Username = x.Username,
                CreationDate = x.CreationDate.ToString(),
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Fullname))
                query = query.Where(x => x.Fullname.Contains(searchModel.Fullname));

            if (!string.IsNullOrWhiteSpace(searchModel.Username))
                query = query.Where(x => x.Username.Contains(searchModel.Username));

            if (!string.IsNullOrWhiteSpace(searchModel.Mobile))
                query = query.Where(x => x.Mobile.Contains(searchModel.Mobile));

            if (searchModel.RoleId > 0)
                query = query.Where(x => x.RoleId == searchModel.RoleId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
        public AccountViewModel GetAccountByName(Login model)
        {
            return _context.Accounts.Include(x => x.Role).Select(x => new AccountViewModel
            {
                Id = x.Id,
                Fullname = x.Fullname,
                Mobile = x.Mobile,
                ProfilePhoto = x.ProfilePhoto,
                Role = x.Role.Name,
                RoleId = x.RoleId,
                Username = x.Username,
                CreationDate = x.CreationDate.ToString(),
            }).FirstOrDefault(x=>x.Username==model.Username);

        }

        
    }
}
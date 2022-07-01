using ESchool.Application.Application.Contracts.Account;
using ESchool.Application.Application.Contracts.Role;
using ESchool.Application.Application.Contracts.School;
using Framework.Application;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ESchool.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Policy = "Account")]
    public class AccountController : Controller
    {
        public AccountSearchModel SearchModel;
        public List<AccountViewModel> Accounts;
        public SelectList Roles;
        public SelectList Schooles;

        private readonly IAccountApplication _accountApplication;
        private readonly ISchoolApplication _schoolApplication;

        private readonly IRoleApplication _roleApplication;
        private readonly IAuthHelper _authHelper;


        public AccountController(
            IAccountApplication accountApplication, 
            IRoleApplication roleApplication,
            ISchoolApplication schoolApplication,
            IAuthHelper authHelper)
        {
            _accountApplication = accountApplication;
            _roleApplication = roleApplication;
            _authHelper=authHelper;
            _schoolApplication=schoolApplication;
        }
   
        public IActionResult Index(AccountSearchModel searchModel)
        {
            Accounts = _accountApplication.Search(searchModel);
            Accounts = _accountApplication.GetAccounts();
            Roles = new SelectList(_roleApplication.List(), "Id", "Name");
            return View(Accounts);
         }
        public IActionResult Teacher()
        {
            Accounts = _accountApplication.GetTeachers(_authHelper.CurrentAccountInfo().Id);
            return View(Accounts);
        }
      
        public IActionResult Register()
        {
            if (_authHelper.CurrentAccountInfo().RoleId==long.Parse(SystemRoles.Administrator))
            {
                var command = new RegisterAccount
                {
                    Roles = _roleApplication.List(),
                    Schooles = _schoolApplication.GetSchool()
                };
                Schooles = new SelectList(_schoolApplication.GetSchool(), "Id", "Name"); 
                return PartialView(command);
            }
            else
            {
                var command = new RegisterAccount
                {
                    Roles = _roleApplication.List(),
                    SchoolId= _accountApplication.GetSchoolIdBy(_authHelper.CurrentAccountInfo().Id),
                };
                return PartialView(command);
            }
            
        }

        [HttpPost]
        public JsonResult Register(RegisterAccount command)
        {
            if (_authHelper.CurrentAccountInfo().RoleId == long.Parse(SystemRoles.Administrator))
            {
                var result = _accountApplication.Register(command, _authHelper.CurrentAccountInfo().Id);
                return new JsonResult(result);
            }
            else
            {
            command.SchoolId = _accountApplication.GetSchoolIdBy(_authHelper.CurrentAccountInfo().Id);
            var result = _accountApplication.Register(command, _authHelper.CurrentAccountInfo().Id);
                return new JsonResult(result);
            }
            
        }
      
        public JsonResult Edit(long id)
        {
            var result = _accountApplication.GetDetails(id);
            return new JsonResult(result);
        }

        [HttpPost]
        public JsonResult Edit(EditAccount command)
        {
            var result = _accountApplication.Edit(command);
            return new JsonResult(result);
        }
        [HttpDelete]
        public JsonResult Delete(DeleteAccount command)
        {
            var result = _accountApplication.Delete(command);
            return new JsonResult(result);
        }
       

    }
}

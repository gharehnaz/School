using ESchool.Application.Application.Contracts.Account;
using ESchool.Application.Application.Contracts.Role;
using ESchool.Application.Application.Contracts.School;
using Framework.Application;
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
        private readonly IAccountApplication _accountApplication;
        private readonly IRoleApplication _roleApplication;
        private readonly IAuthHelper _authHelper;

        public AccountController(IAccountApplication accountApplication, IRoleApplication roleApplication, IAuthHelper authHelper)
        {
            _accountApplication = accountApplication;
            _roleApplication = roleApplication;
            _authHelper=authHelper;
        }
   
        public IActionResult Index(AccountSearchModel searchModel)
        {
            Accounts = _accountApplication.Search(searchModel);
            Accounts = _accountApplication.GetAccounts();
            Roles = new SelectList(_roleApplication.List(), "Id", "Name");
            return View(Accounts);
         }
        //public IActionResult Teacher()
        //{
        //    Accounts = _accountApplication.GetTeachers(_authHelper.CurrentAccountInfo().Id);
        //    return View();
        //}

        public IActionResult Register()
        {
            var command = new RegisterAccount
            {
                Roles = _roleApplication.List()
            };
            return PartialView(command);
        }

        [HttpPost]
        public JsonResult Register(RegisterAccount command)
        {
            var result = _accountApplication.Register(command, _authHelper.CurrentAccountInfo().Id);
            return new JsonResult(result); 
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

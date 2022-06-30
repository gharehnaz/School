using ESchool.Application.Application.Contracts.Account;
using Framework.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ESchool.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AdminArea")]

    public class HomeController : Controller
    {
        
        public AccountViewModel Account;
        private readonly IAccountApplication _accountApplication;
        private readonly IAuthHelper _authHelper;
        public HomeController(IAccountApplication accountApplication, IAuthHelper authHelper, IHttpContextAccessor contextAccessor)
        {
            _accountApplication = accountApplication;
            _authHelper = authHelper;
           
        }
        public IActionResult Index()
        {
            return View(_authHelper.CurrentAccountInfo());
        }
    
        public IActionResult Logout()
        {
            _accountApplication.Logout();
            return Redirect("/home/Index");
        }
    }
}

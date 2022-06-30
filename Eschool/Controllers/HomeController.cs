
using ESchool.Application.Application.Contracts.Account;
using Microsoft.AspNetCore.Mvc;


namespace MyEshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAccountApplication _accountApplication;
       
        public HomeController(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login command)
        {
            var result = _accountApplication.Login(command);
            if (result.IsSuccedded)
                return Redirect("/Admin/home");

            return Redirect("./Index");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }



    }
}

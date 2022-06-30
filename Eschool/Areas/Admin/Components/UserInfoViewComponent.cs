using Framework.Application;
using Microsoft.AspNetCore.Mvc;

namespace ESchool.Web.Areas.Admin.Components
{
    [Area("Admin")]
    public class UserInfoViewComponent : ViewComponent
    {
        private readonly IAuthHelper _authHelper;
        public UserInfoViewComponent( IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }
        public IViewComponentResult Invoke()
        {
            return View(_authHelper.CurrentAccountInfo());
        }

    }
}

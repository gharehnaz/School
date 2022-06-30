using ESchool.Application.Application.Contracts.Role;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ESchool.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Policy = "Role")]
    public class RoleController : Controller
    {
        public RoleSearchModel SearchModel;
        public List<RoleViewModel> RolesApp;
        private readonly IRoleApplication _roleApplication;

        public RoleController(IRoleApplication roleApplication)
        {
            _roleApplication = roleApplication;
        }
   
        public IActionResult Index(RoleSearchModel searchModel)
        {

            RolesApp = _roleApplication.Search(searchModel);
            RolesApp = _roleApplication.List();
           
            return View(RolesApp);
         }

        public IActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult Create(CreateRole command)
        {
            var role = _roleApplication.Create(command);
            return new JsonResult(role); 

        }

        public JsonResult Edit(long id)
        {
            var role = _roleApplication.GetDetails(id);
            return new JsonResult(role);
        }

        [HttpPost]
        public JsonResult Edit(EditRole command)
        {
            var result = _roleApplication.Edit(command);
            return new JsonResult(result);
        }
        [HttpDelete]
        public JsonResult Delete(DeleteRole command)
        {
            var result = _roleApplication.Delete(command);
            return new JsonResult(result);
        }

    }
}

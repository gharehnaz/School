using ESchool.Application.Application.Contracts.Account;
using ESchool.Application.Application.Contracts.School;
using ESchool.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ESchool.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "School")]

    public class SchoolController : Controller
    {
        public SchoolSearchModel SearchModel;
        public List<SchoolViewModel> Schools;
        public List<AccountViewModel> Managers;
        public SchoolIndexViewModel SchoolIndex;
        public SelectList Manager;
        private readonly IAccountApplication _accountApplication;
        private readonly ISchoolApplication _schoolApplication;


        public SchoolController(ISchoolApplication schoolApplication, IAccountApplication accountApplication)
        {
            _schoolApplication = schoolApplication;
            _accountApplication = accountApplication;
            SchoolIndex=new SchoolIndexViewModel();
            
        }
   
        public IActionResult Index(SchoolSearchModel searchModel)
        {
            Schools = _schoolApplication.Search(searchModel);
            SchoolIndex.School = _schoolApplication.GetSchool();
            SchoolIndex.Account = _accountApplication.GetManagers();
            Manager = new SelectList(_accountApplication.GetManagers(), "Id", "FullName");
            return View(SchoolIndex);
        }

        public IActionResult Create()
        {
            return PartialView(new CreateSchool());
        }

        [HttpPost]
        public IActionResult Create(CreateSchool command)
        {
            var result = _schoolApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult Edit(long id)
        {
            var school = _schoolApplication.GetDetails(id);
            school.Managers = _accountApplication.GetManagers();
            return PartialView(school);
        }

        [HttpPost]
        public JsonResult Edit(EditSchool command)
        {
            var result = _schoolApplication.Edit(command);
            return new JsonResult(result);
        }
   
        [HttpDelete]
        public JsonResult Delete(DeleteSchool command)
        {
            var result = _schoolApplication.Delete(command);
            return new JsonResult(result);
        }

    }
}

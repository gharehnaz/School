using ESchool.Application.Application.Contracts.Account;
using ESchool.Application.Application.Contracts.ClassRoom;
using ESchool.Application.Application.Contracts.Course;
using Framework.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ESchool.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "Course")]
    public class CourseController : Controller
    {
        public CourseSearchModel SearchModel;
        public List<CourseViewModel> Courses;
        public SelectList ClassRoom;
        public SelectList Teacher;
        private readonly IAccountApplication _accountApplication;
        private readonly ICourseApplication _courseApplication;
        private readonly IClassRoomApplication _classRoomApplication;
        private readonly IAuthHelper _authHelper;

        public CourseController
        (
        ICourseApplication courseApplication, 
        IClassRoomApplication classRoomApplication, 
        IAccountApplication accountApplication,
        IAuthHelper authHelper
        )
            {
                _courseApplication = courseApplication;
                _classRoomApplication = classRoomApplication;
                _accountApplication = accountApplication;
                _authHelper = authHelper;
            }
   
        public IActionResult Index(CourseSearchModel searchModel)
        {
            Courses = _courseApplication.Search(searchModel);
            Courses = _courseApplication.GetCourses();
            ClassRoom = new SelectList(_classRoomApplication.GetClassRoom(_authHelper.CurrentAccountInfo().Id), "Id", "Name");
            Teacher = new SelectList(_accountApplication.GetTeachers(_authHelper.CurrentAccountInfo().Id), "Id", "Fullname");
            return View(Courses);
         }

        public IActionResult Create()
        {
            var command = new CreateCourse
            {
                ClassRooms = _classRoomApplication.GetClassRoom()
            };
            return PartialView(command);
        }

        [HttpPost]
        public JsonResult Create(CreateCourse command)
        {
            var result = _courseApplication.Create(command);
            return new JsonResult(result); 

        }

        public IActionResult Edit(long id)
        {
            var result = _courseApplication.GetDetails(id);
            result.Teachers = _accountApplication.GetTeachers(_authHelper.CurrentAccountInfo().Id);
            result.ClassRooms=_classRoomApplication.GetClassRoom(_authHelper.CurrentAccountInfo().Id);
            return PartialView(result);
        }

        [HttpPost]
        public JsonResult Edit(EditCourse command)
        {
            var result = _courseApplication.Edit(command);
            return new JsonResult(result);
        }
        [HttpDelete]
        public JsonResult Delete(DeleteCourse command)
        {
            var result = _courseApplication.Delete(command);
            return new JsonResult(result);
        }
       

    }
}

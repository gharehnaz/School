using ESchool.Application.Application.Contracts.Account;
using ESchool.Application.Application.Contracts.ClassRoom;
using ESchool.Application.Application.Contracts.Course;
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

        public CourseController(ICourseApplication courseApplication, IClassRoomApplication classRoomApplication, IAccountApplication accountApplication)
        {
            _courseApplication = courseApplication;
            _classRoomApplication = classRoomApplication;
            _accountApplication = accountApplication;
        }
   
        public IActionResult Index(CourseSearchModel searchModel)
        {
            Courses = _courseApplication.Search(searchModel);
            Courses = _courseApplication.GetCourses();
            ClassRoom = new SelectList(_classRoomApplication.GetClassRoom(), "Id", "Name");
            Teacher = new SelectList(_accountApplication.GetTeachers(), "Id", "Fullname");

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
            result.Teachers = _accountApplication.GetTeachers();
            result.ClassRooms=_classRoomApplication.GetClassRoom();
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

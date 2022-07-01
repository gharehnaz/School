using ESchool.Application.Application.Contracts.ClassRoom;
using ESchool.Application.Application.Contracts.Student;
using Framework.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ESchool.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "Student")]

    public class StudentController : Controller
    {
        public StudentSearchModel SearchModel;
        public List<StudentViewModel> Students;
        public SelectList ClassRoom;
        private readonly IStudentApplication _studentApplication;
        private readonly IClassRoomApplication _classRoomApplication;
        private readonly IAuthHelper _authHelper;

        public StudentController(IStudentApplication studentApplication,
            IClassRoomApplication classRoomApplication,
            IAuthHelper authHelper)
        {
            _studentApplication = studentApplication;
            _classRoomApplication = classRoomApplication;
            _authHelper=authHelper;
        }
   
        public IActionResult Index(StudentSearchModel searchModel)
        {
            Students = _studentApplication.Search(searchModel);
            Students = _studentApplication.GetStudents();
            ClassRoom = new SelectList(_classRoomApplication.GetClassRoom(), "Id", "Name");
            return View(Students);
         }

        public IActionResult Register()
        {
            var command = new RegisterStudent
            {
                ClassRooms = _classRoomApplication.GetClassRoom(_authHelper.CurrentAccountInfo().Id)
            };
            return PartialView(command);
        }

        [HttpPost]
        public JsonResult Register(RegisterStudent command)
        {
            var result = _studentApplication.Register(command);
            return new JsonResult(result); 

        }

        public JsonResult Edit(long id)
        {
            var result = _studentApplication.GetDetails(id);
            return new JsonResult(result);
        }

        [HttpPost]
        public JsonResult Edit(EditStudent command)
        {
            var result = _studentApplication.Edit(command);
            return new JsonResult(result);
        }
        [HttpDelete]
        public JsonResult Delete(DeleteStudent command)
        {
            var result = _studentApplication.Delete(command);
            return new JsonResult(result);
        }
       

    }
}

using ESchool.Application.Application.Contracts.ClassRoom;
using ESchool.Application.Application.Contracts.School;
using ESchool.Application.Application.Contracts.Student;
using Framework.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ESchool.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "ClassRoom")]
    public class ClassRoomController : Controller
    {
        public ClassRoomSearchModel SearchModel;
        public List<ClassRoomViewModel> ClassRooms;
        private readonly IClassRoomApplication _classRoomApplication;
        private readonly ISchoolApplication _schoolApplication;
        private readonly IStudentApplication _studentApplication;

        private readonly IAuthHelper _authHelper;
        public ClassRoomController(
            IClassRoomApplication classRoomApplication, 
            ISchoolApplication schoolApplication, 
            IStudentApplication studentApplication,
            IAuthHelper authHelper)
        {
            _classRoomApplication = classRoomApplication;
            _schoolApplication = schoolApplication;
            _studentApplication = studentApplication;
            _authHelper = authHelper;
        }
   
        public IActionResult Index(ClassRoomSearchModel searchModel)
        {
            ClassRooms = _classRoomApplication.Search(searchModel);
            ClassRooms = _classRoomApplication.GetClassRoom(_authHelper.CurrentAccountInfo().Id);
            return View(ClassRooms);
        }

        public IActionResult Create()
        {
            return PartialView(new CreateClassRoom());
        }
        public IActionResult StudentOfClass(long id)
        {
            var result = _studentApplication.GetStudentOfClassByClassId(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Create(CreateClassRoom command)
        {
            var result = _classRoomApplication.Create(command);
            return new JsonResult(result);
        }

        public JsonResult Edit(long id)
        {
            var classRoom = _classRoomApplication.GetDetails(id);
            classRoom.Schools= _schoolApplication.GetSchool();
            return new JsonResult(classRoom);
        }

        [HttpPost]
        public JsonResult Edit(EditClassRoom command)
        {
            var result = _classRoomApplication.Edit(command);
            return new JsonResult(result);
        }
        [HttpDelete]
        public JsonResult Delete(DeleteClassRoom command)
        {
            var result = _classRoomApplication.Delete(command);
            return new JsonResult(result);
        }

    }
}

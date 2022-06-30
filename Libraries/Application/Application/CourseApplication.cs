using ESchool.Application.Application.Contracts.Course;
using ESchool.Application.IRepository;
using ESchool.Domain.CourseAgg;
using Framework.Application;
using System.Collections.Generic;


namespace ESchool.Application.Application
{
    public class CourseApplication : ICourseApplication
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IClassRoomRepository _classRoomRepository;
       
        public CourseApplication(ICourseRepository courseRepository,
            IClassRoomRepository classRoomRepository)
        {
            _courseRepository = courseRepository;
            _classRoomRepository = classRoomRepository;
        }
        public OperationResult Create(CreateCourse command)
        {
            var operation = new OperationResult();
            if (_courseRepository.Exists(x => x.Code == command.Code))
                return operation.Failed("");
            
            var courses = new Course(command.Name,command.Code,command.ClassRoomId );
            _courseRepository.Create(courses);
            _courseRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Delete(DeleteCourse command)
        {
            var operation = new OperationResult();
            var course = _courseRepository.Get(command.Id);
            _courseRepository.DeleteRecord(course);
            _courseRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditCourse command)
        {
            var operation = new OperationResult();
            var course = _courseRepository.Get(command.Id);

            if (course == null)
                return operation.Failed("");

            if (_courseRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed("");


            course.Edit(command.Name, command.Code,command.ClassRoomId,command.AccountId);

            _courseRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<CourseViewModel> GetCourses()
        {
            return _courseRepository.GetCourse();
        }

        public EditCourse GetDetails(long id)
        {
            return _courseRepository.GetDetails(id);
        }

        public List<CourseViewModel> Search(CourseSearchModel searchModel)
        {
            return _courseRepository.Search(searchModel);
        }

       
    }
}

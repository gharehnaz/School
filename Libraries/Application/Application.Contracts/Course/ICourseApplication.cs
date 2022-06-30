using Framework.Application;
using System.Collections.Generic;

namespace ESchool.Application.Application.Contracts.Course
{
    public interface ICourseApplication
    {
        OperationResult Create(CreateCourse command);
        OperationResult Edit(EditCourse command);
        OperationResult Delete(DeleteCourse command);
        EditCourse GetDetails(long id);
        List<CourseViewModel> GetCourses();
        List<CourseViewModel> Search(CourseSearchModel searchModel);
    }
}

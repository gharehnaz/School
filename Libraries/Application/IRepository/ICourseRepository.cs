using ESchool.Application.Application.Contracts.ClassRoom;
using ESchool.Application.Application.Contracts.Course;
using ESchool.Domain.CourseAgg;
using Framework.Application;
using System.Collections.Generic;


namespace ESchool.Application.IRepository
{
    public interface ICourseRepository: IRepositoryBase<long, Course>
    {
        EditCourse GetDetails(long id);
        List<CourseViewModel> GetCourse();
        List<CourseViewModel> Search(CourseSearchModel searchModel);
    }
}

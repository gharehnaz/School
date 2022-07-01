using ESchool.Application.Application.Contracts.Account;
using ESchool.Application.Application.Contracts.Student;
using ESchool.Domain.AccountAgg;
using Framework.Application;
using System.Collections.Generic;

namespace ESchool.Application.IRepository
{
    public interface IStudentRepository : IRepositoryBase<long, Student>
    {
        Student GetBy(string username);
        EditStudent GetDetails(long id);
        List<StudentViewModel> GetStudents();
        List<StudentViewModel> GetStudentOfClassByClassId(long id);
        List<StudentViewModel> Search(StudentSearchModel searchModel);
    }
}

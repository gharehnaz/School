using Framework.Application;
using System.Collections.Generic;

namespace ESchool.Application.Application.Contracts.Student
{
    public interface IStudentApplication
    {
        StudentViewModel GetStudentBy(long id);
        OperationResult Register(RegisterStudent command);
        OperationResult Edit(EditStudent command);
        OperationResult Delete(DeleteStudent command);
        OperationResult ChangePassword(ChangePassword command);
        EditStudent GetDetails(long id);
        List<StudentViewModel> Search(StudentSearchModel searchModel);
        List<StudentViewModel> GetStudents();
    }
}

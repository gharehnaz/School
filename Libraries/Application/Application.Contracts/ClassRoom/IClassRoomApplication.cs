using Framework.Application;
using System.Collections.Generic;

namespace ESchool.Application.Application.Contracts.ClassRoom
{
    public interface IClassRoomApplication
    {
        OperationResult Create(CreateClassRoom command);
        OperationResult Edit(EditClassRoom command);
        OperationResult Delete(DeleteClassRoom command);
        EditClassRoom GetDetails(long id);
        List<ClassRoomViewModel> GetClassRoom();
        List<ClassRoomViewModel> GetClassRoom(long id);

        List<ClassRoomViewModel> Search(ClassRoomSearchModel searchModel);
    }
}

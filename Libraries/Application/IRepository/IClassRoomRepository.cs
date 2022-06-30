using ESchool.Application.Application.Contracts.ClassRoom;
using ESchool.Domain.ClassRoomAgg;
using Framework.Application;
using System.Collections.Generic;


namespace ESchool.Application.IRepository
{
    public interface IClassRoomRepository: IRepositoryBase<long, ClassRoom>
    {
        EditClassRoom GetDetails(long id);
        List<ClassRoomViewModel> GetClassRoom();
        List<ClassRoomViewModel> GetClassRoom(long id);

        List<ClassRoomViewModel> Search(ClassRoomSearchModel searchModel);
        long GetSchoolIdWithSchoolCode(int schoolCode);
    }
}

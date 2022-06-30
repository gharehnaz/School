using ESchool.Application.Application.Contracts.ClassRoom;
using ESchool.Application.IRepository;
using ESchool.Domain.ClassRoomAgg;
using Framework.Application;
using System.Collections.Generic;


namespace ESchool.Application.Application
{
    public class ClassRoomApplication : IClassRoomApplication
    {
        private readonly IClassRoomRepository _classRoomRepository;
        private readonly ISchoolRepository _schoolRepository;
       
        public ClassRoomApplication(IClassRoomRepository classRoomRepository, 
            ISchoolRepository schoolRepository)
        {
            _classRoomRepository = classRoomRepository;
            _schoolRepository = schoolRepository;
        }
        public OperationResult Create(CreateClassRoom command)
        {
            var operation = new OperationResult();
            if (_classRoomRepository.Exists(x => x.Name == command.Name))
                return operation.Failed("");
            var schoolId = _classRoomRepository.GetSchoolIdWithSchoolCode(command.SchoolCode);
            
            var classRooms = new ClassRoom(command.Name,command.Number, command.Level, command.Description, schoolId, command.SchoolCode);
            _classRoomRepository.Create(classRooms);
            _classRoomRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Delete(DeleteClassRoom command)
        {
            var operation = new OperationResult();
            var classes = _classRoomRepository.Get(command.Id);
            _classRoomRepository.DeleteRecord(classes);
            _classRoomRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditClassRoom command)
        {
            var operation = new OperationResult();
            var classes = _classRoomRepository.Get(command.Id);

            if (classes == null)
                return operation.Failed("");

            if (_classRoomRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed("");

            var schoolId = _classRoomRepository.GetSchoolIdWithSchoolCode(command.SchoolCode);

            classes.Edit(command.Name, command.Number,command.Level, command.Description, schoolId, command.SchoolCode);

            _classRoomRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<ClassRoomViewModel> GetClassRoom()
        {
            return _classRoomRepository.GetClassRoom();
        }
        public List<ClassRoomViewModel> GetClassRoom(long id)
        {
            return _classRoomRepository.GetClassRoom(id);
        }

        public EditClassRoom GetDetails(long id)
        {
            return _classRoomRepository.GetDetails(id);
        }

        public List<ClassRoomViewModel> Search(ClassRoomSearchModel searchModel)
        {
            return _classRoomRepository.Search(searchModel);
        }

    }
}

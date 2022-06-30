using ESchool.Application.Application.Contracts.School;
using ESchool.Application.IRepository;
using ESchool.Domain.SchoolAgg;
using Framework.Application;
using System.Collections.Generic;


namespace ESchool.Application.Application
{
    public class SchoolApplication : ISchoolApplication
    {
        private readonly ISchoolRepository _schoolRepository;
        public SchoolApplication(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }
        public OperationResult Create(CreateSchool command)
        {
            var operation = new OperationResult();
            if (_schoolRepository.Exists(x => x.Name == command.Name))
                return operation.Failed("");

            var schools = new School(command.Name,command.Code,command.Description);
            _schoolRepository.Create(schools);
            _schoolRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Delete(DeleteSchool command)
        {
            var operation = new OperationResult();
            var schools = _schoolRepository.Get(command.Id);
            _schoolRepository.DeleteRecord(schools);
            _schoolRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditSchool command)
        {
            var operation = new OperationResult();
            var schools = _schoolRepository.Get(command.Id);

            if (schools == null)
                return operation.Failed("");

            if (_schoolRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed("");


            schools.Edit(command.Name, command.Code, command.Description,command.AccountId);

            _schoolRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<SchoolViewModel> GetSchool()
        {
            return _schoolRepository.GetSchool();

        }

        public EditSchool GetDetails(long id)
        {
            return _schoolRepository.GetDetails(id);
        }

        public List<SchoolViewModel> Search(SchoolSearchModel searchModel)
        {
            return _schoolRepository.Search(searchModel);
        }

      
    }
}

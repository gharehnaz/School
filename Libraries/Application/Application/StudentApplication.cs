using ESchool.Application.Application.Contracts.Student;
using ESchool.Application.IRepository;
using ESchool.Domain.AccountAgg;
using Framework.Application;
using System.Collections.Generic;
using System.Linq;

namespace ESchool.Application.Application
{
    public class StudentApplication : IStudentApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAccountRepository _accountRepository;
        private readonly IAuthHelper _authHelper;
        private readonly IRoleRepository _roleRepository;
        private readonly IStudentRepository _studentRepository;


        public StudentApplication(IAccountRepository accountRepository, IPasswordHasher passwordHasher,
            IFileUploader fileUploader, IAuthHelper authHelper, IRoleRepository roleRepository, IStudentRepository studentRepository)
        {
            _authHelper = authHelper;
             _roleRepository = roleRepository;
            _fileUploader = fileUploader;
            _passwordHasher = passwordHasher;
            _accountRepository = accountRepository;
            _studentRepository = studentRepository;
        }

        public OperationResult ChangePassword(ChangePassword command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account == null)
                return operation.Failed("");

            if (command.Password != command.RePassword)
                return operation.Failed("");

            var password = _passwordHasher.Hash(command.Password);
            account.ChangePassword(password);
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }

        public StudentViewModel GetStudentBy(long id)
        {
            var student = _studentRepository.Get(id);
            return new StudentViewModel()
            {
                Name = student.Name,
                Family= student.Family,
                NationalCode= student.NationalCode,
            };
        }

        public OperationResult Register(RegisterStudent command)
        {
            var operation = new OperationResult();

            if (_studentRepository.Exists(x => x.NationalCode == command.NationalCode))
                return operation.Failed("");

            var path = $"profilePhotos";
            var picturePath = _fileUploader.Upload(command.ProfilePhoto, path);
            var student = new Student(command.Name, command.Family, command.NationalCode, command.Username, command.Mobile, 
                 picturePath,command.ClassRoomId);
            _studentRepository.Create(student);
            _studentRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditStudent command)
        {
            var operation = new OperationResult();
            var student = _studentRepository.Get(command.Id);
            if (student == null)
                return operation.Failed("");

            if (_studentRepository.Exists(x =>(x.NationalCode == command.NationalCode) && x.Id != command.Id))
                return operation.Failed("");

            var path = $"profilePhotos";
            var picturePath = _fileUploader.Upload(command.ProfilePhoto, path);
            student.Edit(command.Name, command.Family, command.NationalCode, command.Username, command.Mobile, picturePath, command.ClassRoomId);
            _studentRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Delete(DeleteStudent command)
        {
            var operation = new OperationResult();
            var account = _studentRepository.Get(command.Id);
            _studentRepository.DeleteRecord(account);
            _studentRepository.SaveChanges();
            return operation.Succedded();
        }
        public EditStudent GetDetails(long id)
        {
            return _studentRepository.GetDetails(id);
        }

        public List<StudentViewModel> GetStudents()
        {

            return _studentRepository.GetStudents();
        }

        public List<StudentViewModel> Search(StudentSearchModel searchModel)
        {
            return _studentRepository.Search(searchModel);
        }

        public List<StudentViewModel> GetStudentOfClassByClassId(long id)
        {
            return _studentRepository.GetStudentOfClassByClassId(id);
        }
    }
}
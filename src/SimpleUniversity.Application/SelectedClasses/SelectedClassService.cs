using SimpleUniversity.Application.Classes.Contracts;
using SimpleUniversity.Application.Contracts;
using SimpleUniversity.Application.SelectedClasses.Contracts;
using SimpleUniversity.Application.Students.Contracts;
using SimpleUniversity.Domain;

namespace SimpleUniversity.Application.SelectedClasses
{
    public class SelectedClassService : ISelectedClassService
    {
        private readonly ISelectedClassRepository _repository;
        private readonly IClassRepository _classRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;
        public SelectedClassService(
                        ISelectedClassRepository repository,
                        IClassRepository classRepository,
                        IStudentRepository studentRepository,
                        IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _classRepository = classRepository;
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
        }

        public void SelectClass(SelectClassesDto dto)
        {
            var selectedClass = new SelectedClass
            {
                ClassId = dto.ClassId,
                StudentId = dto.StudentId,
            };

            _repository.Add(selectedClass);

            _unitOfWork.SaveChanges();
        }
    }
}

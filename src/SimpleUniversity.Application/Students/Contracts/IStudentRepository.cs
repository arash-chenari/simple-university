using SimpleUniversity.Domain;

namespace SimpleUniversity.Application.Students.Contracts
{
    public interface IStudentRepository
    {
        void Add(Student student);
        List<GetStudentDto> GetAll();
    }
}

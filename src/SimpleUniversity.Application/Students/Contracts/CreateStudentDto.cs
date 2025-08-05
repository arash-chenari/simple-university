using SimpleUniversity.Domain;

namespace SimpleUniversity.Application.Students.Contracts
{
    public class CreateStudentDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Code { get; set; }
        public DateTime BirthDate { get; set; }
        public string NationalCode { get; set; }
        public string FatherName { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}

namespace SimpleUniversity.Application.Classes.Contracts;

public class CreateClassDto
{
    public int CourseId { get; set; }
    public int TeacherId { get; set; }
    public int TermId { get; set; }
    public int Capacity { get; set; }
}
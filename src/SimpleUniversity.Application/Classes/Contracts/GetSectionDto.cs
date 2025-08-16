namespace SimpleUniversity.Application.Classes.Contracts;

public class GetSectionDto
{
    public int Id  { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
}
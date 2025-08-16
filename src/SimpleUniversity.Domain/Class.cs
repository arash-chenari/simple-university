namespace SimpleUniversity.Domain
{
    public class Class
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public int TermId { get; set; }
        public Term Term { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public HashSet<Section> Sections { get; set; } = [];
        public HashSet<SelectedClass> SelectedClasses { get; set; } = [];
    }

    public class Section
    {
        public int Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}



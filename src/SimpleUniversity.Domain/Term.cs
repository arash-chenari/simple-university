namespace SimpleUniversity.Domain
{
    public class Term
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public HashSet<Class> Classes { get; set; } = [];
    }


    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public short Unit { get; set; }
    }
}

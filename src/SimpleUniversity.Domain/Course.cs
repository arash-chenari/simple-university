namespace SimpleUniversity.Domain
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public short Unit { get; set; }
        public HashSet<Class> Classes { get; set; } = [];
    }
}

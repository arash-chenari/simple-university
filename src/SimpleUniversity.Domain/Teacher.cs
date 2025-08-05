namespace SimpleUniversity.Domain
{
    public class Teacher : Person
    {
        public HashSet<Class> Classes { get; set; } = [];
    }
}




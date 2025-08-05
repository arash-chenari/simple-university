namespace SimpleUniversity.Domain
{
    public class Student : Person
    {
        public HashSet<SelectedClass> SelectedClasses { get; set; }
    }
}




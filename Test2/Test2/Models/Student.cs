namespace Test2.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SSID { get; set; }
        public List<Course> Courses { get; set; }

    }
}

using Test2.Models;

namespace Test2.Data
{
    public class MockRepo
    {
        List<Student> Students = new List<Student>()
        {
                new Student() { Id = 1, FirstName = "Bragi", LastName = "Sivarss", SSID = 050505-0505 },
                new Student() { Id = 2, FirstName = "Arnar", LastName = "Sigur", SSID = 050505-0606 },
                new Student() { Id = 3, FirstName = "Gunnar", LastName = "Steinn", SSID = 050505-0707 },
        };

        public MockRepo() 
        {

        }

        public List<Student> GetAllStudents() 
        {
            return Students;
        }

        public Student GetStudentById(int id)
        {
            return Students.FirstOrDefault(x => x.Id == id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Test2.Models;

namespace Test2.Controllers
{
    [Route("/api/students")]
    [Controller]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public List<Student> GetAllStudents() 
        { 
            
        }

        [HttpGet]
        [Route("{id}")]
        public Student GetStudent(int id) 
        {
            List<Student> s = new List<Student>()
            {
                new Student() { Id = 1, FirstName = "Bragi", LastName = "Sivarss", SSID = 050505-0505 },
                new Student() { Id = 2, FirstName = "Arnar", LastName = "Sigur", SSID = 050505-0606 },
                new Student() { Id = 3, FirstName = "Gunnar", LastName = "Steinn", SSID = 050505-0707 },
            };

            return s.FirstOrDefault(x => x.Id == id);
        }
    }
}

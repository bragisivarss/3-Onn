using EF_Core.Models;
using Microsoft.AspNetCore.Mvc;
using SkilaAPI.Data.Interfaces;

namespace SkilaAPI.Controllers
{
    [Controller]
    [Route("/api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IRepository _repo;

        public StudentsController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAllStudents()
        {
            try
            {
                List<Student> students = await _repo.GetAllStudentsAsync();
                return Ok(students);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            try
            {
                Student stud = await _repo.GetStudentByIdAsync(id);

                if (stud == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(stud);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}

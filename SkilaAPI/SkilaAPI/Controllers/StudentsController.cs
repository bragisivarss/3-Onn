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

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent([FromBody]Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var createdStudent = await _repo.CreateStudentAsync(student);

                    return CreatedAtAction(nameof(GetStudentById), new { id = createdStudent.StudentId }, createdStudent);
                }
                else
                {
                    return BadRequest("Student cannot be empty");
                }
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

        [HttpPatch]
        [Route("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, [FromBody]Student student)
        {
            try
            {
                //var updatedStudent = await _repo.UpdateStudentAsync(id, student);

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                else
                {
                    var studentToUpdate = await _repo.GetStudentByIdAsync(id);

                    if (studentToUpdate == null)
                    { return NotFound(); }

                    if (!string.IsNullOrEmpty(student.FirstName)) 
                    {
                        studentToUpdate.FirstName = student.FirstName;
                    }

                    if (!string.IsNullOrEmpty(student.LastName))
                    {
                        studentToUpdate.LastName = student.LastName;
                    }

                    if (student.GroupId != 0)
                    {
                        studentToUpdate.GroupId = student.GroupId;
                    }

                    await _repo.SaveAsync();

                    return Ok(studentToUpdate);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}

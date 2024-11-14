using EF_Core.Models;
using Microsoft.EntityFrameworkCore;
using SkilaAPI.Data.Interfaces;

namespace SkilaAPI.Data.Repositories
{
    public class MainRepository : IRepository
    {
        private readonly SchoolDbContext _db;

        public MainRepository()
        {
            _db = new SchoolDbContext();
        }

        public async Task<Student> CreateStudentAsync(Student student)
        {
            using (var db = _db)
            {
                await db.Students.AddAsync(student);
                await db.SaveChangesAsync();
                return student;
            }
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            List<Student> students;

            using (var db = _db)
            {
                students = await db.Students.ToListAsync();
            }

            return students;
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            Student s;

            using (var db = _db)
            {
                s = await db.Students.FirstOrDefaultAsync(x => x.StudentId == id);
            }

            return s;
        }
    }
}

using EF_Core.Models;

namespace SkilaAPI.Data.Interfaces
{
    public interface IRepository
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task<Student> CreateStudentAsync(Student student);
        Task<Student> UpdateStudentAsync(int id, Student student);
        Task SaveAsync();
    }
}

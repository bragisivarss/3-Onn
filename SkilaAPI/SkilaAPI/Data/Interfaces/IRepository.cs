﻿using EF_Core.Models;

namespace SkilaAPI.Data.Interfaces
{
    public interface IRepository
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);

    }
}
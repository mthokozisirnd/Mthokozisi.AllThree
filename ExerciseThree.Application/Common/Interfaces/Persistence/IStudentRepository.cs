using ExerciseThree.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseThree.Application.Common.Interfaces.Persistence
{
    public interface IStudentRepository
    {
        void Add(Student student);

        Student? GetStudentByEmail(string email);

        Student? GetStudentById(Guid studentId);

        void Update(Guid studentId, Student student);

        void Delete(Guid studentId);

        List<Student> GetAllStudents();
    }
}

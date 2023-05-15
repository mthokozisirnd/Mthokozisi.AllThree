using ExerciseThree.Application.Common.Interfaces.Persistence;
using ExerciseThree.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExerciseThree.Domain.Entities;

namespace ExerciseThree.Infrastructure.Persistence
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentManagementDbContext _studentManagementDbContext;

        public StudentRepository(StudentManagementDbContext studentManagementDbContext)
        {
            _studentManagementDbContext = studentManagementDbContext;
        }

        public void Add(Student student)
        {
            _studentManagementDbContext.Add(student);
            _studentManagementDbContext.SaveChanges();
        }

        public Student? GetStudentByEmail(string email)
        {
            return _studentManagementDbContext.Students.SingleOrDefault(s => s.Email == email);
        }

        public Student? GetStudentById(Guid studentId)
        {
            return _studentManagementDbContext.Students.SingleOrDefault(s => s.Id == studentId);
        }

        public void Delete(Guid studentId)
        {
            var student = _studentManagementDbContext.Students.SingleOrDefault(s => s.Id == studentId); 

            _studentManagementDbContext.Attach(student);
            //DeleteObject is used to delete the entity object.  
            _studentManagementDbContext.Remove(student);
            _studentManagementDbContext.SaveChanges();
        }

        public List<Student> GetAllStudents()
        {
            return _studentManagementDbContext.Students.ToList();
        }

        public void Update(Guid studentId, Student student)
        {
            var result = _studentManagementDbContext.Students.FirstOrDefault(m => m.Id == studentId); 

            if (result == null)
            {
                throw new DirectoryNotFoundException();
            }

            result.FirstName = student.FirstName;
            result.LastName = student.LastName;

            _studentManagementDbContext.SaveChangesAsync();
        }
    }
}

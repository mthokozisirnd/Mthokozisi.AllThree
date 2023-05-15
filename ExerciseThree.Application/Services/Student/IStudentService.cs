using ExerciseThree.Domain.Entities;

namespace ExerciseThree.Application.Services.StudentManagement;

public interface IStudentService
{
    Result Login(string email, string password);

    Result Register(string firstName, string lastName,string email, string password);

    Result Update(Guid studentId, Student student);

    Result Delete(Guid studentId);

    Result GetAllStudents();
}
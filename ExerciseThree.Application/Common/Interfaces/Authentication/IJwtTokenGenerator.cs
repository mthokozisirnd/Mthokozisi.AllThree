using ExerciseThree.Domain.Entities;

namespace ExerciseThree.Application.Common.Interfaces.StudentManagement;

public interface IJwtTokenGenerator
{
    string GenerateToken(Student student);
}
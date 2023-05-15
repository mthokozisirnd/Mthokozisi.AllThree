using ExerciseThree.Domain.Entities;

namespace ExerciseThree.Application.Services.StudentManagement;

public record Result(
    List<Student> student,
    string Token
);
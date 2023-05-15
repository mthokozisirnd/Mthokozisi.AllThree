namespace ExerciseThree.Contracts.StudentManagement;

public record StudentResponse
(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token
);
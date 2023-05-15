namespace ExerciseThree.Contracts.StudentManagement;

public record RegisterRequest
(
    string FirstName,
    string LastName,
    string Email,
    string Password
);

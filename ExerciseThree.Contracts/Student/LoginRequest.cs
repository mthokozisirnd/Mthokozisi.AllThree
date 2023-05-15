namespace ExerciseThree.Contracts.StudentManagement;

public record LoginRequest
(
    string Email,
    string Password
);
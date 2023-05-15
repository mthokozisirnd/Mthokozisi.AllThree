using ExerciseThree.Application.Common.Interfaces.StudentManagement;
using ExerciseThree.Application.Common.Interfaces.Persistence;
using ExerciseThree.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace ExerciseThree.Application.Services.StudentManagement;


public class StudentService : IStudentService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IStudentRepository _studentRepository;
    private readonly ILogger<StudentService> _logger;
    public StudentService(IJwtTokenGenerator jwtTokenGenerator, IStudentRepository studentRepository, ILogger<StudentService> logger)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _studentRepository = studentRepository;
        _logger = logger;
    }
    public Result Register(string firstName, string lastName, string email, string password)
    { 
        // 1. Validate the student doesn't exist
        if (_studentRepository.GetStudentByEmail(email) is not null)
        {
            throw new Exception("Student with given email already exists");
        }

        // 2. Create student
        var student = new Student
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _studentRepository.Add(student);

        // 3. Generate JWT Token
        var token = _jwtTokenGenerator.GenerateToken(student);
        _logger.LogDebug(" token generation: {@token}", token);

        return new Result(
          new List<Student> { student },
          token
        );
    }
    public Result Login(string email, string password)
    {
        //1. Validate the Student does exist
        if (_studentRepository.GetStudentByEmail(email) is not Student student)
        {
            throw new Exception("Student with given email does not exists.");
        }

        //2. Validate the Password

        if (student.Password != password)
        {
            throw new Exception("Invalid password.");
        }

        //3. Generate Token

        var token = _jwtTokenGenerator.GenerateToken(student);
        _logger.LogDebug(" token generation: {@token}", token);

        return new Result(
          new List<Student> { student },
          token
        );
    }

    public Result Update(Guid studentId, Student student)
    {
        //1. Validate the Student does exist
        if (_studentRepository.GetStudentById(studentId) is not Student savedStudent)
        {
            throw new Exception("Student with given email does not exists.");
        }
        _studentRepository.Update(studentId, student);
        return new Result(
          new List<Student> { student },
          ""
        );

    }

    public Result GetAllStudents()
    {
        var students = _studentRepository.GetAllStudents();
        return new Result(
          students,
          ""
        );

    }

    public Result Delete(Guid studentId)
    {
        _studentRepository.Delete(studentId);
        return new Result(
          new List<Student>(),
          ""
        );
    }
}
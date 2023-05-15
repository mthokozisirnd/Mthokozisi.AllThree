using ExerciseThree.Contracts.StudentManagement;
using Microsoft.AspNetCore.Mvc;

using ExerciseThree.Application.Services.StudentManagement;
using ExerciseThree.Domain.Entities;
using System.Net;

namespace ExerciseThree.Api.Controllers;

[ApiController]
[Route("Student")]
public class StudentController : ControllerBase
{

    public readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }
    [HttpPost("register")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(StudentResponse), (int)HttpStatusCode.OK)]
    public IActionResult Register([FromBody] RegisterRequest  request)
    {
        var authResult = _studentService.Register(
             request.FirstName,
             request.LastName,
             request.Email,
             request.Password
        );

        var response = new StudentResponse(
            authResult.student[0].Id,
            authResult.student[0].FirstName,
            authResult.student[0].LastName,
            authResult.student[0].Email,
            authResult.Token
        );
        return Ok(response);
    }

    [HttpPost("login")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(StudentResponse), (int)HttpStatusCode.OK)]
    public  IActionResult Login([FromBody] LoginRequest  request)
    {
        var authResult = _studentService.Login(
             request.Email,
             request.Password
        );

        var response = new StudentResponse(
            authResult.student[0].Id,
            authResult.student[0].FirstName,
            authResult.student[0].LastName,
            authResult.student[0].Email,
            authResult.Token
        );
        return Ok(response);
    }

    [HttpGet("GetAllStudents")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(List<StudentResponse>), (int)HttpStatusCode.OK)]
    public IActionResult GetAllStudents()
    {
        var authResult = _studentService.GetAllStudents();

        var response = new List<StudentResponse>();

        foreach (var student in authResult.student)
        {
            var responseStudent = new StudentResponse(
            student.Id,
            student.FirstName,
            student.LastName,
            student.Email,
            authResult.Token
            );

            response.Add(responseStudent);
        }
        return Ok(response);
    }

    // POST: Student/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    
    [HttpPut("UpdateStudent")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public IActionResult Edit(Guid id, [FromBody] Student student)
    {
        if (id != student.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                var authResult = _studentService.Update(id, student);
            }
            catch (Exception ex)
            {
                if (student == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        return Ok(student);
    }

    // GET: Student/Delete/5
    [HttpDelete("DeleteStudent")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public IActionResult Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        try
        {
            var authResult = _studentService.Delete(id.Value);
        }
        catch (Exception ex)
        {
            throw;
        }
        return Ok();
    }

}
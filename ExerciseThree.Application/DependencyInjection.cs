using ExerciseThree.Application.Services.StudentManagement;
using Microsoft.Extensions.DependencyInjection;
namespace ExerciseThree.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IStudentService, StudentService>();
        return services;
    }
}
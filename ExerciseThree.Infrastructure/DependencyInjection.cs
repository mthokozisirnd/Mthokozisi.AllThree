using ExerciseThree.Application.Services.StudentManagement;
using ExerciseThree.Infrastructure.StudentManagement;
using ExerciseThree.Infrastructure.Services;
using ExerciseThree.Application.Common.Interfaces.StudentManagement;
using ExerciseThree.Application.Common.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ExerciseThree.Application.Common.Interfaces.Persistence;
using ExerciseThree.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ExerciseThree.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddDbContext<StudentManagementDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("Default")));

        return services;
    }
}
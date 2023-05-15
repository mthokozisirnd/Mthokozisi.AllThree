using ExerciseThree.Application.Common.Interfaces.Services;
using System;
namespace ExerciseThree.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
using System;
namespace ExerciseThree.Application.Common.Interfaces.Services;

public interface IDateTimeProvider
{

    DateTime UtcNow {get;}

}
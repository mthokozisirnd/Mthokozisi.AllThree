using ExerciseThree.Api.Filters;
using ExerciseThree.Application;
using ExerciseThree.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
// Add services to the container.
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
}


var app = builder.Build();
{
app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
}
using ExerciseOne.Models;

namespace ExerciseOne.Web.Services
{
    public interface IXMLService
    {
        Task Create(User user);
        Task<User> GetUserById(string userId);

        Task<List<User>> GetAllUsers();

        Task Update(User user);

        Task Delete(string UserId);

    }
}

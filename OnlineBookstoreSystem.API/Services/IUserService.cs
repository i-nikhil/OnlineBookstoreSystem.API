using OnlineBookstoreSystem.API.Models;

namespace OnlineBookstoreSystem.API.Services;

public interface IUserService
{
    void RegisterUser(User user);
    IEnumerable<User> GetAllUsers();
}

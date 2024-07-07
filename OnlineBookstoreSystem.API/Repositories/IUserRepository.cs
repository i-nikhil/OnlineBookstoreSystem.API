using OnlineBookstoreSystem.API.Models;

namespace OnlineBookstoreSystem.API.Repositories;

public interface IUserRepository
{
    void AddUser(User user);
    IEnumerable<User> GetAllUsers();
    User GetUserById(int id);
}

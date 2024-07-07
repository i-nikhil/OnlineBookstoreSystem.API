using OnlineBookstoreSystem.API.Models;

namespace OnlineBookstoreSystem.API.Repositories;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users = new();

    public void AddUser(User user)
    {
        user.Id = _users.Count + 1;
        _users.Add(user);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _users;
    }

    public User GetUserById(int id)
    {
        return _users.FirstOrDefault( u => u.Id == id);
    }
}

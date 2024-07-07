using OnlineBookstoreSystem.API.Models;
using OnlineBookstoreSystem.API.Repositories;

namespace OnlineBookstoreSystem.API.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void RegisterUser(User user)
    {
        _userRepository.AddUser(user);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _userRepository.GetAllUsers();
    }
}

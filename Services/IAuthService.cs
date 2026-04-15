using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IAuthService
    {
        IEnumerable<Car> Get();
        int GetUser(int id);
        Task CreateUser(User newUser);
    }
}

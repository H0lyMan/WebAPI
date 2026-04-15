using WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class AuthService : IAuthService
    {
        public static List<User> GetDummyUsers()
        {
            return new List<User>
            {
                new User { Id = 1, Username = "jkowalski", Passwd = "Password123!" },
                new User { Id = 2, Username = "anowak", Passwd = "QwertyUIOP!9" },
                new User { Id = 3, Username = "mwisniewski", Passwd = "SuperTajneHaslo1" },
                new User { Id = 4, Username = "kwojcik", Passwd = "Admin12345@" },
                new User { Id = 5, Username = "pkaminski", Passwd = "Zima2024!#" },
                new User { Id = 6, Username = "ewojciechowska", Passwd = "MojeHaslo99$" },
                new User { Id = 7, Username = "alevandowska", Passwd = "FitnessLife12" },
                new User { Id = 8, Username = "tnowacki", Passwd = "TomekNow123" },
                new User { Id = 9, Username = "jsmith", Passwd = "JohnSmith88@" },
                new User { Id = 10, Username = "admin_glowny", Passwd = "RootPassword!00" }
            };
        }
        public IEnumerable<Car> Get()
        {
            return cars();
        }

        List<Car> cars()
        {
            using var carsDbConnection = new DbConnectionContext();
        
            return carsDbConnection.dbCars.ToList();
        }

        public int GetUser(int id)
        {
            if (GetDummyUsers().Any(user => user.Id == id))
            {
                return id;
            }
            else
            {
                var defaultId = from user in GetDummyUsers() select user.Id;
                return defaultId.First(); // Zwraca 1, jeśli użytkownik o podanym ID nie istnieje
            }
        }   

        public async Task CreateUser(User newUser)
        {
            GetDummyUsers().Add(newUser);
        }
    }
}

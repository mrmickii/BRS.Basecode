using BRS.Basecode.Data.Entity;

namespace BRS.Basecode.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUser();

        Task<User> GetUserById(int id);

        Task CreateUser(User user);

        Task UpdateUser(User newUser);

        Task DeleteUser(int id);

        Task <int> GetLatestUserId();
    }
}

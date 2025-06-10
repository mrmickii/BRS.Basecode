using BRS.Basecode.Data.Entity;
using BRS.Basecode.Services.DTO;

namespace BRS.Basecode.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUser();

        Task<User> GetUserById(int userId);

        Task CreateUser(CreateUserDTO model);

        Task UpdateUser(CreateUserDTO model);

        Task DeleteUser(int id);
    }
}

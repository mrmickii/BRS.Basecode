using BRS.Basecode.Data.Entity;
using BRS.Basecode.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BRS.Basecode.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            return await _appDbContext.Users.ToListAsync();
        }

        public async Task<User?> GetUserById(int userId)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task CreateUser(User user)
        {
            await _appDbContext.AddAsync(user);
            _appDbContext.SaveChanges();

        }

        public async Task UpdateUser(User newUser)
        {
            _appDbContext.Update(newUser);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var toDelete = await _appDbContext.Users.FindAsync(id);

            if (toDelete != null)
            {
                _appDbContext.Users.Remove(toDelete);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<int> GetLatestUserId()
        {
            return await _appDbContext.Users
                .OrderByDescending(u => u.UserId)
                .Select(u => u.UserId)
                .FirstOrDefaultAsync();
        }
    }
}

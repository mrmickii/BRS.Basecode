using BRS.Basecode.Data.Entity;
using BRS.Basecode.Data.Interfaces;
using BRS.Basecode.Resources.Constants;
using BRS.Basecode.Services.DTO;
using BRS.Basecode.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BRS.Basecode.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            var result = await _userRepository.GetAllUser();
            return result;
        }

        public async Task<User> GetUserById(int userId)
        {
            var user = await _userRepository.GetUserById(userId);

            if(user == null)
            {
                throw new KeyNotFoundException($"User with id {userId} does not exists.");
            }
            return user;
        }

        public async Task CreateUser(CreateUserDTO model)
        {
            var hasher = new PasswordHasher<User>();
            var latestUserID = await _userRepository.GetLatestUserId();
            var userExists = (await _userRepository.GetAllUser())
                .Any(user => user.UserId == model.UserId);

            if (userExists)
            {
                throw new InvalidOperationException(Common.Messages.USER_ID_EXISTS(model.UserId));
            }

            var newUser = new User
            {
                Email = model.Email,
                UserId = latestUserID + 1,
                UserPin = 1234,
                DateCreated = DateTime.UtcNow
            };

            newUser.Password = hasher.HashPassword(newUser, model.Password);

            await _userRepository.CreateUser(newUser);
        }

        public async Task UpdateUser(CreateUserDTO model)
        {
            var result = await _userRepository.GetUserById(model.UserId);
            var hasher = new PasswordHasher<User>();

            if(result == null)
            {
                throw new Exception(Common.Messages.USER_NOT_FOUND);
            }

            result.Email = model.Email;
            result.Password = hasher.HashPassword(result, model.Password);
            result.UserPin = model.UserPin;
            result.DateCreated = DateTime.UtcNow;
        }

        public async Task DeleteUser(int id)
        {
            var toDelete = await _userRepository.GetUserById(id);

            if(toDelete != null)
            {
                await _userRepository.DeleteUser(id);
            }
        }
    }
}

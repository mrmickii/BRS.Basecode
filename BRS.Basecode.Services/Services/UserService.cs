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
            return await _userRepository.GetAllUser();
        }

        public async Task<User> GetUserById(int userId)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user == null)
            {
                throw new KeyNotFoundException(Common.Messages.USER_ID_NOT_EXISTS(userId));
            }
            return user;
        }

        public async Task CreateUser(CreateUserDTO model)
        {
            var hasher = new PasswordHasher<User>();
            var latestUserID = await _userRepository.GetLatestUserId();

            var newUser = new User
            {
                UserId = latestUserID + 1,
                Email = model.Email,
                Password = hasher.HashPassword(null, model.Password),
                UserPin = 1234,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };

            await _userRepository.CreateUser(newUser);
        }

        public async Task UpdateUser(UserDTO model)
        {
            var user = await _userRepository.GetUserById(model.UserId);
            if (user == null)
            {
                throw new KeyNotFoundException(Common.Messages.USER_NOT_FOUND);
            }

            var hasher = new PasswordHasher<User>();

            user.Email = model.Email;
            user.Password = hasher.HashPassword(user, model.Password);
            user.UserPin = model.UserPin;
            user.DateCreated = DateTime.UtcNow;

            await _userRepository.UpdateUser(user);
        }

        public async Task UpdatePin(UpdatePinDTO model)
        {
            var user = await _userRepository.GetUserById(model.UserId);
            if (user == null)
            {
                throw new KeyNotFoundException(Common.Messages.USER_NOT_FOUND);
            }

            user.UserPin = model.UserPin;
            user.DateUpdated = DateTime.UtcNow;

            await _userRepository.UpdateUser(user);
        }

        public async Task DeleteUser(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user != null)
            {
                await _userRepository.DeleteUser(id);
            }
        }
    }
}

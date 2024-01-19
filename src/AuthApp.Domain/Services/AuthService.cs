using AuthApp.Domain.Models;
using AuthApp.Domain.Services.Interfaces;
using Microsoft.AspNet.Identity;

namespace AuthApp.Domain.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserDataService _userDataService;
        private readonly IPasswordHasher _passwordHasher;
        public AuthService(IUserDataService userDataService, IPasswordHasher passwordHasher)
        {
            _userDataService = userDataService;
            _passwordHasher = passwordHasher;   
        }

        public async Task<bool> LogIn(string login, string password)
        {
            var user = await _userDataService.GetByLogin(login);

            if (user == null)
            {
                throw new ArgumentException($"User {login} not found");
            }

            PasswordVerificationResult passwordVerificationResult =
                _passwordHasher.VerifyHashedPassword(user.PasswordHash, password);
            if(passwordVerificationResult != PasswordVerificationResult.Success)
            {
                throw new ArgumentException("Incorrect password");
            }
            return true;
        }

        public async Task<User> SignUp(string username, string password, string confirmPassword)
        {
            if(password != confirmPassword)
            {
                throw new ArgumentException("Passwords did not match");
            }

            var user = await _userDataService.GetByLogin(username);

            if (user != null) 
            {
                throw new ArgumentException($"{username} alrady exists");
            }

            var passwordHash = _passwordHasher.HashPassword(password);
            User entity = new User()
            {
                Login = username,
                PasswordHash = passwordHash
            };
            await _userDataService.Create(entity);
            return entity;
        }
    }
}

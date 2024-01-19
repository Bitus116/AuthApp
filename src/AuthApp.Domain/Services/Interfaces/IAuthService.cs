using AuthApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Domain.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> LogIn(string login, string password);

        Task<User> SignUp(string username, string password, string confirmPassword);
    }
}

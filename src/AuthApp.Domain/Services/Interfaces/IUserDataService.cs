using AuthApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Domain.Services.Interfaces
{
    public interface IUserDataService : IDataService<User>
    {
        Task<User?> GetByLogin(string username);
    }
}

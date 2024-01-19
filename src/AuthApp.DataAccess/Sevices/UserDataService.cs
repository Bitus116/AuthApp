using AuthApp.Domain.Models;
using AuthApp.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AuthApp.DataAccess.Sevices
{
    public class UserDataService : IUserDataService
    {
        private readonly DbContextFactory _contextFactory;

        public UserDataService(DbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<User> Create(User entity)
        {
            using (AuthAppDbContext context = _contextFactory.CreateDbContext())
            {
                EntityEntry<User> createdResult = await context.Set<User>().AddAsync(entity);
                await context.SaveChangesAsync();

                return createdResult.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (AuthAppDbContext context = _contextFactory.CreateDbContext())
            {
                User? entity = await context.Set<User>().FirstOrDefaultAsync((e) => e.Id == id);

                if(entity == null)
                {
                    return false;
                }

                context.Set<User>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<User?> Get(int id)
        {
            using (AuthAppDbContext context = _contextFactory.CreateDbContext())
            {
                User? entity = await context.Users.FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<User?>> GetAll()
        {
            using (AuthAppDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<User> entities = await context.Users
                    .ToListAsync();
                return entities;
            }
        }

        public async Task<User?> GetByLogin(string username)
        {
            using (AuthAppDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Users
                    .FirstOrDefaultAsync(a => a.Login == username);
            }
        }

        public async Task<User> Update(int id, User entity)
        {
            using (AuthAppDbContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;

                context.Set<User>().Update(entity);
                await context.SaveChangesAsync();

                return entity;
            }
        }
    }
}

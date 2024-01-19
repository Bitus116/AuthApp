﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace AuthApp.DataAccess
{
    public class DbContextFactory
    {
        private readonly Action<DbContextOptionsBuilder> _configureDbContext;

        public DbContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
        {
            _configureDbContext = configureDbContext;
        }

        public AuthAppDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<AuthAppDbContext> options = new DbContextOptionsBuilder<AuthAppDbContext>();

            _configureDbContext(options);

            return new AuthAppDbContext(options.Options);
        }
    }
}

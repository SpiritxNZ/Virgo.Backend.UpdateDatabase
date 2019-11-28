using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Virgo.Backend.Repository.Context;
using Virgo.Backend.UpdateDatabase.interfaces;

namespace Virgo.Backend.UpdateDatabase.services
{
    public class DatabaseMigrationService : IMigrationService
    {
        private readonly VirgoDbContext _dbContext;

        public DatabaseMigrationService(VirgoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task MigrateAll()
        {
            try
            {
                IEnumerable<string> pending = await _dbContext.Database.GetPendingMigrationsAsync();
                Console.WriteLine($"Pending database migrations are: {string.Join(" | ", pending)}");
                _dbContext.Database.SetCommandTimeout(10 * 60); // 10 minutes
                await _dbContext.Database.MigrateAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to run database migration: {e.Message}");
                throw;
            }
        }

        public async Task MigrateToTarget(string migrationId)
        {
            try
            {
                var migrator = _dbContext.Database.GetService<IMigrator>();
                _dbContext.Database.SetCommandTimeout(10 * 60); // 10 minutes
                await migrator.MigrateAsync(migrationId);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to migrate the database: {e.Message}");
                throw e;
            }
        }
    }
}
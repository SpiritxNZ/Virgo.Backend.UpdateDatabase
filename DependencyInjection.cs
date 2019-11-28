using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Virgo.Backend.Repository.Context;
using Virgo.Backend.UpdateDatabase.Helper;
using Virgo.Backend.UpdateDatabase.interfaces;
using Virgo.Backend.UpdateDatabase.services;

namespace Virgo.Backend.UpdateDatabase
{
    public class DependencyInjection
    {
        public static IServiceProvider ConfigureServices()
        {
            ServiceCollection services = new ServiceCollection();

            string mysqlConnectionString = DatabaseSetupHelper.GetDatabaseConnectionString();
            services.AddDbContext<VirgoDbContext>(builder =>
            {
                builder.UseMySQL(mysqlConnectionString);
            });

            services.AddScoped<IMigrationService, DatabaseMigrationService>();

            return services.BuildServiceProvider();
        }
    }
}
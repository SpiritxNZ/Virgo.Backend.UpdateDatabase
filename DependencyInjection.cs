using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Virgo.Backend.Repository.Context;
using Virgo.Backend.UpdateDatabase.Helper;

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

            return services.BuildServiceProvider();
        }
    }
}

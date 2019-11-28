using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Virgo.Backend.UpdateDatabase.interfaces;

namespace Virgo.Backend.UpdateDatabase
{
    public class Program
    {
        private static IServiceProvider services;
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            services = DependencyInjection.ConfigureServices();
            Console.WriteLine("wow");

            var migrationService = services.GetService<IMigrationService>();
            await migrationService.MigrateAll();
        }
    }
}
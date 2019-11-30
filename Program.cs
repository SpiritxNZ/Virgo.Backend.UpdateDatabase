using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine("Starting Virgo UpdateDatabase service...");
            services = DependencyInjection.ConfigureServices();

            var migrationService = services.GetService<IMigrationService>();

            Dictionary<string, string> parameters = GetParameters(args);
            try
            {
                if (parameters.ContainsKey("--RunMigration") && bool.Parse(parameters["--RunMigration"]))
                {
                    Console.WriteLine("Full migration is selected...");
                    await migrationService.MigrateAll();
                }
                else if (parameters.ContainsKey("--RunMigrationTo"))
                {
                    Console.WriteLine($"Target migration is selected: {parameters["--RunMigrationTo"]}");
                    await migrationService.MigrateToTarget(parameters["RunMigrationTo"]);
                }


                if (parameters.ContainsKey("--RunFix") && bool.Parse(parameters["--RunFix"]))
                {
                    // TODO: implement database fix
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Virgo UpdateDatabase service encountered the following error: {e.Message}");
                throw;
            }
            Console.WriteLine("Virgo UpdateDatabase service operation finished...");
        }

        private static Dictionary<string, string> GetParameters(string[] args)
        {
            Dictionary<string, string> parameterDictionary = new Dictionary<string, string>();
            parameterDictionary = args
                .Select(x => x.Split('='))
                .ToDictionary(x => x[0], x => x[1]);
            return parameterDictionary;
        }
    }
}
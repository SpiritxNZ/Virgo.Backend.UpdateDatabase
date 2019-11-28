using System.Threading.Tasks;

namespace Virgo.Backend.UpdateDatabase.interfaces
{
    public interface IMigrationService
    {
        Task MigrateAll();
        Task MigrateToTarget(string migrationId);
    }
}
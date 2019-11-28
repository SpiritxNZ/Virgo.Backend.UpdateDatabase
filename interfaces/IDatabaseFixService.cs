using System.Threading.Tasks;

namespace Virgo.Backend.UpdateDatabase.interfaces {
    public interface IDatabaseFixService {
        Task HandleFix();
    }
}
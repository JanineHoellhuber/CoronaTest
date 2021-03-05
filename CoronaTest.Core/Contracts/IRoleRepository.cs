using CoronaTest.Core.Models;
using System.Threading.Tasks;

namespace CoronaTest.Core.Contracts
{
    public interface IRoleRepository
    {
        Task AddAsync(Role role);
    }
}
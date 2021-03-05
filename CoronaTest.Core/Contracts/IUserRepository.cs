using CoronaTest.Core.Models;
using System.Threading.Tasks;

namespace CoronaTest.Core.Contracts
{
    public interface IUserRepository
    {
        Task AddAsync(AuthUser user);
    }
}
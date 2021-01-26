using ClassLibrary1.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaTest.Core.Persistence
{
    public interface ITestCenterRepository
    {
        Task AddRangeAsync(TestCenter[] testCenter);
        Task<int> GetCountAsync();
    }
}

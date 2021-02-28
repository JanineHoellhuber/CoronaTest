using ClassLibrary1.Entities;
using CoronaTest.Core.DTO;
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
        Task<TestCenter[]> GetTestcCenterByCampaignIdAsync(int id);
        Task<TestCenter[]> GetAllAsync();
        Task AddAsync(TestCenter testCenter);
        Task<IEnumerable<TestCenter>> GetTestCenterByPostcodeAsync(string postalcode);
        Task<TestCenter> GetTestCenterByIdAsync(int id);
        void Delete(TestCenter testCenter);
    }
}

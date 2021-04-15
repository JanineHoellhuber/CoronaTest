
using CoronaTest.Core.DTOs;
using CoronaTest.Core.Entities;
using CoronaTest.Core.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaTest.Persistence.Repositories
{
    public class TestCenterRepository : ITestCenterRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TestCenterRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddRangeAsync(TestCenter[] testCenters)
        {
            await _dbContext.TestCenter.AddRangeAsync(testCenters);
        }

        public async Task AddAsync(TestCenter testCenters)
        {
            await _dbContext.TestCenter.AddAsync(testCenters);
        }


        public async Task<int> GetCountAsync()
        {
            return await _dbContext.TestCenter.CountAsync();
        }
        public async Task<TestCenter[]> GetTestcCenterByCampaignIdAsync(int id)
        {
            var campaign = await _dbContext.Campaign
              .Where(c => c.Id == id)
              .SingleOrDefaultAsync();

            return campaign.AvailableTestCenters.ToArray();
        }

        public async Task<TestCenter> GetTestCenterByIdAsync(int id)
        {
            return await _dbContext
                .TestCenter
                .SingleOrDefaultAsync(t => t.Id == id);
        }

        public void Delete(TestCenter testCenter)
        {
            _dbContext.TestCenter.Remove(testCenter);
        }

        public async Task<TestCenter[]> GetAllAsync()
        {
            return await _dbContext.TestCenter
                .ToArrayAsync();
        }

        public async Task<IEnumerable<TestCenter>> GetTestCenterByPostcodeAsync(string postalcode)
        {
            return await _dbContext.TestCenter
                .Where(t => t.Postcode == postalcode)
                .ToArrayAsync();
        }

    }
}

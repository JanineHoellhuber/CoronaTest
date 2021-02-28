using ClassLibrary1.Entities;
using CoronaTest.Core.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaTest.Persistence.Repositories
{
    public class CampaignRepository : ICampaignRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CampaignRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddRangeAsync(Campaign[] campaigns)
        {
            await _dbContext.Campaign.AddRangeAsync(campaigns);
        }
        public async Task<int> GetCountAsync()
        {
            return await _dbContext.Campaign.CountAsync();
        }

        public async Task<Campaign[]> GetAllAsync()
        {
            return await _dbContext
                .Campaign
                .ToArrayAsync();
        }
        public async Task AddAsync(Campaign campaign)
        {
            await _dbContext.AddAsync(campaign);
        }
        public async Task<Campaign> GetByIdAsync(int id)
        {
            return await _dbContext.Campaign
                .Where(c => c.Id == id)
                .SingleOrDefaultAsync();
        }
        public void Delete(Campaign campaignInDb)
        {
            _dbContext.Remove(campaignInDb);
        }


    }
}

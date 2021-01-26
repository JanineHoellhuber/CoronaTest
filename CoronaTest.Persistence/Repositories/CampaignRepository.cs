using ClassLibrary1.Entities;
using CoronaTest.Core.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

    }
}

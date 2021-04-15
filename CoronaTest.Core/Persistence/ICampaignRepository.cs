using CoronaTest.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaTest.Core.Persistence
{
    public interface ICampaignRepository
    {
        Task AddRangeAsync(Campaign[] campaigns);
        Task<int> GetCountAsync();
        Task<Campaign[]> GetAllAsync();
        Task AddAsync(Campaign campaign);
        Task<Campaign> GetByIdAsync(int id);
        void Delete(Campaign campaignInDb);
    }
}

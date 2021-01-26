using ClassLibrary1.Entities;
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
    }
}

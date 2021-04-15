
using CoronaTest.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaTest.Core.DTO
{
    public class CampaignDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

    
       
        public CampaignDto(Campaign campaign)
        {
            Id = campaign.Id;
            Name = campaign.Name;
            From = campaign.From;
            To = campaign.To;
        }

        public Campaign ToCampaign()
        {
            return new Campaign()
            {
                Id = this.Id,
                Name = this.Name,
                From = this.From,
                To = this.To
        };
        }
    }
}

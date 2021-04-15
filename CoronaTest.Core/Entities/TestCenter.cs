using CoronaTest.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaTest.Core.Entities
{
    public class TestCenter : EntityObject
    {
        public ICollection<Campaign> AvailableInCampaigns { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public string Postcode { get; set; }
        public int SlotCapacity { get; set; }
        public string Street { get; set; }
    }
}

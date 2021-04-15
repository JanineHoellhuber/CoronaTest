
using CoronaTest.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaTest.Core.DTO
{
    public class TestCenterDto
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public string Postcode { get; set; }
        public int SlotCapacity { get; set; }
        public string Street { get; set; }

        public TestCenterDto(TestCenter testCenter)
        {
            Id = testCenter.Id;
            Name = testCenter.Name;
            City = testCenter.City;
            Postcode = testCenter.Postcode;
            Street = testCenter.Street;
            SlotCapacity = testCenter.SlotCapacity;
        }

        public TestCenter ToTestCenter()
        {
            return new TestCenter()
            {
                Name = this.Name,
                City = this.City,
                Postcode = this.Postcode,
                Street = this.Street,
                SlotCapacity = this.SlotCapacity
            };
        }
    }
}

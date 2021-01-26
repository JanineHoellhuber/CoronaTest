using CoronaTest.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Entities
{
    public class Campaign : EntityObject
    {
        public ICollection<TestCenter> AvailableTestCenters { get; set; }

        public DateTime From { get; set; }
        public string Name { get; set; }
        public DateTime To { get; set; }
        public int Examinations { get; set; }

    }

}

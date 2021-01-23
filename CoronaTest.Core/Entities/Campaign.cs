using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Entities
{
    public class Campaign
    {
        List<TestCenter> AvailableTestCenters { get; set; }
        //Examinations
        public DateTime From { get; set; }
        public string Name { get; set; }
        public DateTime To { get; set; }
    }
}

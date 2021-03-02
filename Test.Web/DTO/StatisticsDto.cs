using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Web.DTO
{
    public class StatisticsDto
    {
        public int CountExaminations { get; set; }
        public int CountUnknownTest { get; set; }
        public int CountPositiveTest { get; set; }
        public int CountNegativeTest { get; set; }
    }
}

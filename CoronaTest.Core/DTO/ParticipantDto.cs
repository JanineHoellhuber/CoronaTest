using CoronaTest.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.DTO
{
    public class ParticipantDto
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public string CampaignName { get; set; }
        public string TestCenterName { get; set; }
        public TestResult TestResult { get; set; }
    }
}

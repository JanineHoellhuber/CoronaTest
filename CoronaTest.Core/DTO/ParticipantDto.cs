using System;
using System.Collections.Generic;
using System.Text;
using static ClassLibrary1.Enums.Enums;

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

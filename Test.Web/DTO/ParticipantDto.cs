using CoronaTest.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "Die {0} ist verpflichtend")]
        [StringLength(10, ErrorMessage = "Die {0} muss genau 10 Zeichen lang sein!", MinimumLength = 10)]
        public string SSNr { get; set; }
    }
}


using CoronaTest.Core.Entities;
using CoronaTest.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaTest.Core.DTO
{
    public class ExaminationDto
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public TestResult TestResult { get; set; }
        public DateTime ExaminationAt { get; set; }
        public ExaminationStates State { get; set; }
        public string TestCenter { get; set; }
        public int TestCenterId { get; set; }
        public Participant Participant { get; set; }
        public int ParticipantId { get; set; }
        public string Campaign { get; set; }
        public int CampaignId { get; set; }

        public ExaminationDto()
        {

        }
        public ExaminationDto(Examination examination)
        {
            Id = examination.Id;
            Identifier = examination.Identifier;
            TestResult = examination.TestResult;
            ExaminationAt = examination.ExaminationAt;
            State = examination.State;
            TestCenter = examination.TestCenter.Name;
            TestCenterId = examination.TestCenter.Id;
            Participant = examination.Participant;
            ParticipantId = examination.Participant.Id;
            Campaign = examination.Campaign.Name;
            CampaignId = examination.Campaign.Id;
           
        }
    }
}

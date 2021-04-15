
using CoronaTest.Core.Entities;
using CoronaTest.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

 namespace CoronaTest.Core.DTOs
{
    public class ExaminationsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TestResult TestResult { get; set; }
        public DateTime ExaminationAt { get; set; }
        public string Identifier { get; set; }
        public ExaminationsDto(Examination examination)
        {
            Id = examination.Id;
            Name = $"{examination.Participant.FirstName} {examination.Participant.LastName}";
            TestResult = examination.TestResult;
            ExaminationAt = examination.ExaminationAt;
            Identifier = examination.Identifier;
        }

        public ExaminationsDto()
        {

        }

    }
}

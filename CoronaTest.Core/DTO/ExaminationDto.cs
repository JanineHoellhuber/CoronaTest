using ClassLibrary1.Entities;
using CoronaTest.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaTest.Core.DTO
{
    public class ExaminationDto
    {
        public int Id { get; set; }
        public TestResult TestResult { get; set; }
        public string Name { get; set; }
        public DateTime ExaminationAt { get; set; }
        public ExaminationDto(Examination examination)
        {
            Id = examination.Id;
            Name = examination.Participant.Name;
            TestResult = examination.Result;
            ExaminationAt = examination.ExaminationAt;
        }
    }
}

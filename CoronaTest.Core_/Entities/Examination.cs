using System;
using System.Collections.Generic;
using System.Text;
using static ClassLibrary1.Enums.Enums;

namespace ClassLibrary1.Entities
{
    public class Examination
    {
        public Participant Participant { get; set; }
        public ExaminationStates State { get; set; }
        public TestResult Result { get; set; }
        public Campaign Campaign { get; set; }
        public TestCenter TestCenter { get; set; }

        public DateTime ExaminationAt { get; set; }
        public string Identifier { get; set; }

        public static Examination CreateNew()
        {
            return new Examination();
        }
    }
}

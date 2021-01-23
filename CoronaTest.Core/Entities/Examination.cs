using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Entities
{
    public class Examination
    {
        public TestCenter ExaminationAt { get; set; }
        public string Identifier { get; set; }

        public static Examination CreateNew()
        {
            return new Examination();
        }
    }
}

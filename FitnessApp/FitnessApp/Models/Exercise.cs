using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessApp
{
    public class Exercise//make this public
    {
        public string Day { get; set; }
        public string Type { get; set; }
        public int SetNumber { get; set; }
        public int RepetitionNumber { get; set; }

        public Exercise() { }

        public Exercise(string day, string type, int setNumber, int repetitionNumber)
        {
            Day = day;
            Type = type;
            SetNumber = setNumber;
            RepetitionNumber = repetitionNumber;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode08
{
    class Entry
    {
        public List<string> SignalValues { get; set; }
        public List<string> DigitOutputvalue { get; set; }

        public Entry(List<string> signalValues, List<string> digitOutputValue)
        {
            SignalValues = signalValues;

            DigitOutputvalue = digitOutputValue;
        }


    }
}

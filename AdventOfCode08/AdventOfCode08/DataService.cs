using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace AdventOfCode08
{
    class DataService
    {
        private const string _infile = "..\\..\\..\\input.txt";

        public List<Entry> Entries { get; set; }


        public DataService()
        {
            Entries = new List<Entry>();
            var content = File.ReadAllText(_infile);

            foreach(var  line in content.Split("\r\n"))
            {
                // split into two components
                var splitLine = line.Split("|");

                // index 0 = Signal values, index 1 = Digits
                var signalValueList = new List<string>(splitLine[0].Split(" ")).Where(s => s.Trim().Length > 0).ToList();
                var digitList = new List<string>(splitLine[1].Split(" ")).Where(s => s.Trim().Length > 0).ToList();

                Entries.Add(new Entry(signalValueList, digitList));
            }

        }

        public void DumpEntries()
        {
            StringBuilder result = new StringBuilder();
            foreach (var e in Entries)
            {
                StringBuilder s = new StringBuilder();
                StringBuilder d = new StringBuilder();

                foreach (var signal in e.SignalValues)
                {
                    s.Append(signal + " ");
                }

                foreach (var digit in e.DigitOutputvalue)
                {
                    d.Append(digit + " ");
                }

                result.AppendJoin("|", s.ToString(), d.ToString());
                result.AppendLine();
            }

            Console.WriteLine(result);
        }



    }
}

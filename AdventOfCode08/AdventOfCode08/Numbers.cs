using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode08
{
    class Numbers
    {
        public Dictionary<int, string> NumbersDict { get; set; }

        public Numbers(int config =1)
        {
            NumbersDict = new Dictionary<int, string>();

            if (config == 1)
            {
                NumbersDict[0] = "abcefg";
                NumbersDict[1] = "cf";
                NumbersDict[2] = "acdeg";
                NumbersDict[3] = "acdfg";
                NumbersDict[4] = "bcdf";
                NumbersDict[5] = "abdfg";
                NumbersDict[6] = "abdefg";
                NumbersDict[7] = "acf";
                NumbersDict[8] = "abcdefg";
                NumbersDict[9] = "abcdfg";
            }
            else
            {
                for(int i = 0; i<10;i++)
                {
                    NumbersDict[i] = string.Empty;
                }
            }
        }
        

        public int CountDigits(int digit, Entry entry)
        {
            return entry.DigitOutputvalue.Where(r => r.Length == NumbersDict[digit].Length).Count();
            // ;           return entry.DigitOutputvalue.Where(r => r == NumbersDict[digit]).Count();
            //return 0;
            
        }

        public string CalculateDigits(Entry entry)
        {
            string result = string.Empty;
            FillNumbersDict(entry);

            var d = entry.DigitOutputvalue.Select(v =>
                 NumbersDict.Where(pair => SortString(pair.Value) == SortString(v)).First().Key.ToString()).ToList(); ;

            d.ForEach(s => result += s);

            return result;
        }

        private void FillNumbersDict(Entry entry)
        {
            NumbersDict = new Dictionary<int, string>();
            for (int i = 0; i < 10; i++)
            {
                NumbersDict[i] = string.Empty;
            }
            DumpList(entry.SignalValues);

            // Determine known values: 1, 4, 7, 8
            NumbersDict[1] = entry.SignalValues.Where(s => s.Length == 2).First().ToString();
            NumbersDict[4] = entry.SignalValues.Where(s => s.Length == 4).First().ToString();
            NumbersDict[7] = entry.SignalValues.Where(s => s.Length == 3).First().ToString();
            NumbersDict[8] = entry.SignalValues.Where(s => s.Length == 7).First().ToString();


            // 6 is only entry with length 6 which has no complete match with 1 (which has 2 signals)
            var result = entry.SignalValues.Where(s => (s.Contains(NumbersDict[1][0]) && s.Contains(NumbersDict[1][1])) == false);
            NumbersDict[6] = entry.SignalValues.Where(s => (s.Contains(NumbersDict[1][0]) &&
                        s.Contains(NumbersDict[1][1])) == false &&
                        s.Length == 6)
                .First()
                .ToString();

            // Determine combinations for 9 and 0
            // Length 6: compare with 7, then with 4 to determine 9
            // Other Length 6 is 0
            var work2 = entry.SignalValues.Where(
                    s => s.Length == 6 &&
                    SortString(s) != SortString(NumbersDict[6]))
                .ToList();


            // 7, then 4.
            var work3 = entry.SignalValues.Where(
                s => s.Length == 6 &&
                    SortString(s) != SortString(NumbersDict[6]))
                .Select(s => new string(s.ToArray().Except(NumbersDict[7].ToArray()).ToArray()))
                .Select(s => new string(s.ToArray().Except(NumbersDict[4].ToArray()).ToArray()))
                .ToList();
            //for(int i = 0; i <3; i++)
            //{
            //    work = work.Select(s => s.Replace(NumbersDict[7][i].ToString(), String.Empty)).ToList();
            //}

            //// 4
            //for (int i = 0; i < 4; i++)
            //{
            //    work = work.Select(s => s.Replace(NumbersDict[4][i].ToString(), String.Empty)).ToList();
            //}

            NumbersDict[9] = (work3[0].Length == 1) ? work2[0] : work2[1];
            NumbersDict[0] = (work3[0].Length == 1) ? work2[1] : work2[0];

            // Determing combination for 4
            // Lengte 5: Vergelijk met 7, 2 over = 3
            //
            NumbersDict[3] = entry.SignalValues.Where(
                    s => s.Length == 5 &&
                        new string(s.ToArray().Except(NumbersDict[7].ToArray()).ToArray()).Length == 2)
                .First().ToString();


            // Determine 5
            // Lengte 5: vergelijk met 6, 1 over = 5

            //var w = entry.SignalValues.Where(s => s.Length == 5 && SortString(s) != SortString(NumbersDict[3]));
            //var w2 = w.Select(s => new string(s.ToArray().Intersect(NumbersDict[6].ToArray()).ToArray()));

            NumbersDict[5] = entry.SignalValues.Where(s => s.Length == 5 &&
                                        SortString(s) != NumbersDict[3] &&
                                        new string(s.ToArray().Intersect(NumbersDict[6].ToArray()).ToArray()).Length == 5)
                                            .First()
                                            .ToString();

            // 2 = the length 5 input not used in 5 and 3
            NumbersDict[2] = entry.SignalValues.Where(s => s.Length == 5 &&
                                                        SortString(s) != SortString(NumbersDict[5]) &&
                                                        SortString(s) != SortString(NumbersDict[3]))
                                    .First()
                                    .ToString();

            DumpDictionary();
        }

        
        private void DumpList(List<string> input)
        {
            StringBuilder b = new StringBuilder();

            foreach(string s in input)
            {
                b.Append(s + "\r\n");
            }

            Console.WriteLine(b.ToString());
        }

        private void DumpDictionary()
        {
            var b = new StringBuilder();
            NumbersDict.Keys.ToList().ForEach(k => b.Append(k.ToString() + " : " + NumbersDict[k] + "\r\n"));
            Console.WriteLine(b.ToString());
        }

        private string SortString(string value)
        {
            var value2 = value.ToCharArray();
            Array.Sort(value2);
            return new string(value2);
        }
        
    }
}

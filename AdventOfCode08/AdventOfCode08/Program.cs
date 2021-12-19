using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode08
{
    class Program
    {
        static void Main(string[] args)
        {
            // retrieve data from input file.
            var d = new DataService();

            d.DumpEntries();

            // Get numbers display
            var n = new Numbers();
            int res = 0;
            int[] i = new int[] {1, 4, 7, 8};
            foreach (var e in d.Entries)
            {
                foreach(int j in i)
                { res += n.CountDigits(j, e); }
            }

            Console.WriteLine($"Res1: {res}");


            string res2 = string.Empty ;
            List<int> resultList = new List<int>() ;

            n = new Numbers(2);
            foreach (var e in d.Entries)
            {
                string eResult = n.CalculateDigits(e);
                resultList.Add(int.Parse(eResult));
                res2 += eResult + "\r\n"; 


            }

            var result = resultList.Sum();

            Console.WriteLine($"{res2}");
            Console.WriteLine($"Sum: {result}");
        }
    }
}

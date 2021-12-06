using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode05
{
    public class DataService
    {
        private const string _fileIn = "..\\..\\..\\input.txt";
        public List<int> LanternFish { get; set; }

        public DataService()
        {
            LanternFish = new List<int>();
            

            List<string> input = new List<string>();
            input.AddRange(File.ReadAllText(_fileIn).Split(","));
            input.ForEach(x =>
                LanternFish.Add(int.Parse(x))
                );

            return;
        }

    }
}

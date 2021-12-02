using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2
{
    public class DataService
    {
        private const string _fileIn = "..\\..\\..\\input.txt";
        public List<string> GetData()
        {
            var l = new List<string>();


            l.AddRange(File.ReadAllText(_fileIn).Split("\r\n"));


            return l;

        }
    }
}

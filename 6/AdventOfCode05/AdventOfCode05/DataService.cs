using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
<<<<<<< HEAD
using System.Linq;
=======
using AdventOfCode05;
>>>>>>> 70c2038c64db43e11815a7e4a3eff013696d449a

namespace AdventOfCode05
{
    public class DataService
    {
        private const string _fileIn = "..\\..\\..\\input.txt";
<<<<<<< HEAD
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

=======

        public List<VentLine> VentLines { get; set; }
        public int maxX{ get; set; }
        public int maxY { get; set; }

        public DataService()
        {
            maxX = 0;
            maxY = 0;
            VentLines = new List<VentLine>();
            var input = File.ReadAllText(_fileIn).Replace(" -> ", ",").Split("\r\n");
            foreach(var s in input)
            {
                if (s.Trim().Length > 0)
                {
                    string[] coordinates = s.Split(",");
                    VentLine v = new VentLine(coordinates);
                    int x1 = int.Parse(v.x1);
                    int x2 = int.Parse(v.x2);
                    int y1 = int.Parse(v.y1);
                    int y2 = int.Parse(v.y2);

                    maxX = (x1 > maxX) ? x1 : maxX;
                    maxX = (x2 > maxX) ? x2 : maxX;
                    maxY = (y1 > maxY) ? y1 : maxY;
                    maxX = (y2 > maxY) ? y2 : maxY;
                    
                    VentLines.Add(v);
                }
            }

        }

        
>>>>>>> 70c2038c64db43e11815a7e4a3eff013696d449a
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2
{
    class MoveSub1
    {
        public int forward { get; set; }
        public int down { get; set; }

        public void MoveSub()
        {
            forward = 0;
            down = 0;

            var a = new DataService();

            var l = a.GetData();

            int i = 0;

            foreach (string s in l)
            {
                i++;
                var item = new List<string>();
                item.AddRange(s.Split(" "));

                switch (item[0])
                {
                    case "up":
                        {
                            down -= int.Parse(item[1]);
                            break;
                        }
                    case "forward":
                        {
                            int value = int.Parse(item[1]);

                            forward += value;
                            down += value ;
                            break;
                        }
                    case "down":
                        {
                            down += int.Parse(item[1]);
                            break;
                        }
                }
            }
        }
    }
}


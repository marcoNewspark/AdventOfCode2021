using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode05
{
    public class VentLine
    {
        public string x1 { get; set; }
        public string y1 { get; set; }
        public string x2 { get; set; }
        public string y2 { get; set; }

        public VentLine(string[] coordinates)
        {
            x1 = coordinates[0];
            y1 = coordinates[1];
            x2 = coordinates[2];
            y2 = coordinates[3];
        }

        public VentLine()
        {

        }

        public string Dump()
        {
            StringBuilder b = new StringBuilder();

            b.Append(x1.ToString());
            b.Append(","); 
            b.Append(y1.ToString());
            b.Append(" -> ");
            b.Append(x2.ToString());
            b.Append(",");
            b.Append(y2.ToString());

            return b.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode05
{
    

    class VentlineService
    {
        // dimension 0 = x, dimension 1 = y
        public int[,] VentlineMatrix { get; set; }

        public VentlineService(int maxX, int maxY)
        {
            VentlineMatrix = new int[maxX+1, maxY+1];
        }

        // Plot the ventline input in the matrix if it is a vertical
        public bool PlotVentLine(VentLine input)
        {
            var xMax = VentlineMatrix.GetUpperBound(0);
            var yMax = VentlineMatrix.GetUpperBound(1);
            int x1, x2, y1, y2;

            // Console.WriteLine( input.Dump());
            
            x1 = int.Parse(input.x1);
            x2 = int.Parse(input.x2);
            y1 = int.Parse(input.y1);
            y2 = int.Parse(input.y2);


            PlotAxis(x1, y1, x2, y2);

            return true;
        }

        private void SwapValues(ref int val1, ref int val2)
        {
            int work = val1;
            val1 = val2;
            val2 = work;
        }


        private void PlotAxis(int startX, int startY, int endX, int endY)
        {
            int factorX = (startX > endX) ? -1 : 1;
            int factorY = (startY > endY) ? -1 : 1;

            if (startX == endX)
            {
                int workY = startY;
                while(workY!= endY+factorY)
                {
                    VentlineMatrix[startX, workY] += 1;
                    workY += factorY;
                }

            }
            else if (startY == endY)
            {
                int workX = startX;
                while(workX != endX + factorX)
                {
                    VentlineMatrix[workX, startY] += 1;
                    workX += factorX;
                }
            }
            else
            {
                int workX = startX;
                int workY = startY;
                while(workX!=endX+factorX)
                {
                    VentlineMatrix[workX, workY] += 1;
                    workX += factorX;
                    workY += factorY;
                }
            }

            //DumpMatrix();
        }

        public void DumpMatrix()
        {
            StringBuilder b = new StringBuilder();
            for (int i = 0; i <= VentlineMatrix.GetUpperBound(1); i++)
            {
                for (int j = 0; j <= VentlineMatrix.GetUpperBound(0); j++)
                {
                    string value = VentlineMatrix[j,i].ToString().PadLeft(4, ' ');
                    b.Append(value.Substring(value.Length - 3, 3));
                }
                b.Append("\r\n");
            }
            Console.WriteLine(b.ToString());
        }

        // Filter all items <= 1 from the list, and count the remainder
        public int GetIntersections()
        {
            var total = 0;
            for (int i = 0; i <= VentlineMatrix.GetUpperBound(1); i++)
            {
                var a = Enumerable.Range(0, VentlineMatrix.GetUpperBound(0) + 1)
                .Select(x => VentlineMatrix[i, x])
                .Where(y => y > 1).ToList();

                total += a.Count();
            }

            return total;
            

        }

    }
}

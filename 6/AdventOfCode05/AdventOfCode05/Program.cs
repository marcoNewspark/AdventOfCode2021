using System;

namespace AdventOfCode05
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = new DataService();
<<<<<<< HEAD

            var l = new LanternfishService(d.LanternFish);

            var result = l.CalculatePopulationWithArrays(256);
            //var result = l.CalculatePopulation (256);
            Console.WriteLine($"Result: {result}");
=======
            var v = new VentlineService(d.maxX, d.maxY);

            foreach(VentLine l in d.VentLines)
            {
                v.PlotVentLine(l);
                
            }
            v.DumpMatrix();
            var total = v.GetIntersections();
            Console.WriteLine($"Total: {total}");
            Console.ReadLine();
>>>>>>> 70c2038c64db43e11815a7e4a3eff013696d449a
        }
    }
}

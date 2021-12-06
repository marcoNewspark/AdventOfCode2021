using System;

namespace AdventOfCode06
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = new DataService();

            var l = new LanternfishService(d.LanternFish);

            long result = l.Test2(256);
            //var result = l.CalculatePopulationWithArrays(256);
            //var result = l.CalculatePopulation (256);
            Console.WriteLine($"Result: {result}");

        }
    }
}

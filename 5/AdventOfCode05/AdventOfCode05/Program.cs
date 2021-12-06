using System;

namespace AdventOfCode05
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = new DataService();

            var l = new LanternfishService(d.LanternFish);

            var result = l.CalculatePopulationWithArrays(256);
            //var result = l.CalculatePopulation (256);
            Console.WriteLine($"Result: {result}");
        }
    }
}

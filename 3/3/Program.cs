using System;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new RateCalculator();
            var d = new DataService();
            var input = d.GetData();

            var gamma = calc.CalculateGamma(input);
            var epsilon = calc.CalculateEpsilon(input);

            Console.WriteLine($"Gamma: {gamma}");
            Console.WriteLine($"Epsilon: {epsilon}");
            Console.WriteLine($"Product: {gamma*epsilon}");

            var calc2 = new LifeSupportCalculator();

            var o2 = calc2.CalculateOxygen(input);
            var co2 = calc2.CalculateCO2(input);

            Console.WriteLine($"O2: {o2}");
            Console.WriteLine($"CO2: {co2}");
            Console.WriteLine($"Product: {co2* o2}");

        }
    }
}

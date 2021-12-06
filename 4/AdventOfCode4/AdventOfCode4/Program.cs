using System;

namespace AdventOfCode4
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = new DataService();
            var b = new BingoService(d);
            
            var result = b.PlayBingo();
            Console.WriteLine($"Gewonnen: {result}");

             var sum = b.GetSumOfUnmarkedNumbers(b.WinningBoard);
            Console.WriteLine($"Sum: {sum}");

            var winningNumber = int.Parse(b.WinningNumber);
            Console.WriteLine($"Winning number: {winningNumber}");

            var uitkomst = sum * winningNumber;
            Console.WriteLine($"Result: {uitkomst}");

            var losingBoard = b.LosingBoard;
            var losingNumber = b.LosingNumber;

            Console.WriteLine($"Losing number: {losingNumber}");
            Console.WriteLine("Losingboard:");
            b.PrintBoard(losingBoard);

            sum = b.GetSumOfUnmarkedNumbers(losingBoard);
            Console.WriteLine($"Sum: {sum}");

            Console.WriteLine($"Product: {sum * int.Parse(losingNumber)}");

            Console.ReadLine();


        }
    }
}

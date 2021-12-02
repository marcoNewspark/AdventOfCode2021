using System;
using System.Collections.Generic;

namespace AdventOfCode2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var m = new MoveSub2();

            //var m = new MoveSub1();
            m.MoveSub();

            Console.WriteLine($"Down: {m.down} Forward: {m.forward} Product: {m.down*m.forward}");
        }
    }
}

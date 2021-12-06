using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode4
{
    class BingoService
    {
        public DataService BingoData{ get; set; }
        public string[,] WinningBoard { get; set; }
        public string[,] LosingBoard { get; set; }
        public string WinningNumber { get; set; }
        public string LosingNumber { get; set; }

        private bool winnaarBekend;

        public BingoService(DataService dataService )
        {
            BingoData = dataService;
            winnaarBekend = false;
        }

        // Draw the numbers, process the boards.
        public bool PlayBingo()
        {
            var numbers = BingoData.Numbers;
            var boards = BingoData.Boards;
            var losingBoards = new List<string[,]>();

            foreach (var b in boards) { 
                PrintBoard(b);
                Console.WriteLine();
            };
            Console.WriteLine($"Aantal boards: {boards.Count.ToString()}");
            Console.ReadLine();

            foreach(string number in numbers)
            {
                Console.WriteLine($"Number: {number}");

                ProcessNumber(number, ref boards);

                var result = CheckBoards(ref boards);
                if(result)
                {
                    if (winnaarBekend)
                    {
                        LosingNumber = number;
                    }
                    else
                    {
                        WinningNumber = number;
                        winnaarBekend = true;
                    }
                    
                    if(boards.Count == 1)
                    {
                        Console.WriteLine("1 board left");
                        if (LosingBoard == null)
                        {
                            // only 1 board left. Store it for later reference
                            LosingBoard = boards[0];
                            PrintBoard(LosingBoard);
                        }
                        else
                        {
                            //board has won. we can exit now
                            LosingNumber = number;
                            break;

                        }
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine($"Aantal boards: {boards.Count.ToString()}");
                    }
                }
            }

            return false;
        }

        // find the drawn number in the boards and mark it 
        private void ProcessNumber(string number, ref List<string[,]> boards)
        {
            foreach (var b in boards)
            {
                // cycle through the lines
                for (int i = 0; i <= b.GetUpperBound(0); i++)
                {

                    // cycle through the columns
                    for (int j = 0; j <= b.GetUpperBound(1); j++)
                    {
                        // add X to number if it matches
                        b[i, j] = (b[i, j] == number) ? b[i, j] + "X" : b[i, j];
                    }
                }
            }
        }

        public void PrintBoard(string[,] board)
        {
                StringBuilder line = new StringBuilder();

                for (int i = 0; i <= board.GetUpperBound(0); i++)
                {
                    // cycle through the columns
                    for (int j = 0; j <= board.GetUpperBound(1); j++)
                    {
                        var value = (board[i, j].Contains('X') ? board[i, j] + " " : board[i, j] + "  ");
                        value = " " + value;
                        value = value.Substring(1, value.Length - 1);
                        line.Append(value);
                    }
                    Console.WriteLine(line.ToString());
                    line.Clear();
                 }
        }
        public void PrintLine(List<string> line)
        {
            StringBuilder b = new StringBuilder();
            foreach (var s in line)
            {
                var value = (" " + s).Replace('X', ' ');
                value = value.Substring(1, value.Length - 1);
                b.Append(value);
            }
            Console.WriteLine(b.ToString());
        }

        // Check if we have a full line yet
        private bool CheckBoards(ref List<string[,]> boards)
        {
            bool result= false;
            List<string[,]> losingBoards = new List<string[,]>();
            foreach (string[,] b in boards)
            {
                result = ChecKBoard(b);
                if (result) { 
                    losingBoards.Add(b); 
                    if(WinningBoard==null)
                    {
                        WinningBoard = b;
                    }
                }
            }

            if(boards.Count > 1)
            {
                foreach (string[,] b in losingBoards)
                {
                    boards.Remove(b);
                }
            }
            return result;
        }

        private bool ChecKBoard(string[,] board)
        {
            bool gewonnen = false;
                
            // check rows or columns if we have a winner
            for (int i = 0; i <= board.GetUpperBound(1); i++)
            {
                // check rows, count Xs
                var checkRow = Enumerable.Range(0, 5)
                    .Select(x => board[x, i])
                    .Where(s => s.Contains('X'))
                    .ToList();

                gewonnen = (checkRow.Count >= 5) ? true : false;

                if (gewonnen)
                {
                    break;
                }
                else
                {
                    // check columns, count Xs
                    var checkCol = Enumerable.Range(0, 5)
                        .Select(x => board[i, x])
                        .Where(s => s.Contains('X'))
                        .ToList();
                    gewonnen = (checkCol.Count >= 5) ? true : false;
                    if (gewonnen)
                    {
                        break;
                    }
                }
            }
            return gewonnen;
        }
    

        public int GetSumOfUnmarkedNumbers(string[,] board)
        {
            int sum = 0;
            // haal uit alle rijnede unmarked numbers
            for(int i = 0; i < 5; i++) {

                var sumRange =
                    Enumerable.Range(0, 5)
                    .Select(x => board[x, i])
                    .Where(s => s.Contains('X') == false)
                    .ToList(); ;


                sum += Enumerable.Range(0, 5)
                    .Select(x => board[x, i])
                    .Where(s => s.Contains('X') == false)
                    .Sum(x => Int32.Parse(x));
            }

            return sum;

        }

    }
}

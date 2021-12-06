using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode4
{
    public class DataService
    {
        private const string _fileIn = "..\\..\\..\\input.txt";

        public List<string> Numbers { get; set; }
        public List<string[,]> Boards { get; set; }
        
        
        public DataService()
        {
            Numbers = new List<string>();
            Boards = new List<string[,]>();
            string content = File.ReadAllText(_fileIn);

            System.Collections.Generic.Queue<string> lines = new Queue<string>() ;
            foreach(string s in content.Split("\n"))
            {
                lines.Enqueue(s);
            }

            // first line is the numbers being called
            var line = lines.Dequeue();
            Numbers.AddRange(line.Split(","));
            
            // empty line
            line = lines.Dequeue();

            // Now the board starts. 
            // Each line is 5 numbers, split by a space. each board is 5 lines high
            // int array[5,5]
            bool cont = true;

            string[,] board = new string[5, 5];

            while(cont)
            {
                
                line = lines.Dequeue();
                int lineNum = 0;
                int col = 0;

                cont = (line == string.Empty) ? false : true;
                
                while (line.Trim() != string.Empty)
                {
                    string curLine = line.Replace("  ", " ").TrimStart();
                    List<string> numberList = new List<string>(curLine.Split(" ")) ;
                    
                    foreach(string number in numberList)
                    {
                        board[lineNum, col++] = number;
                     }

                    // read next line
                    line = lines.Dequeue();
                    lineNum++;
                    col = 0;
                }

                if (cont) { 
                    Boards.Add(board);
                    PrintBoard(board);
                    board = new string[5, 5];
                    col = 0;
                };

                cont = lines.Count != 0;
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
    }
}

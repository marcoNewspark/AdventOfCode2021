using System;
using System.Collections.Generic;
using System.Text;

namespace _3
{
    class RateCalculator
    {
        public int CalculateGamma(List<String> input)
        {

            // all strings in input are same length
            // construct int array, length = length of first string
            int[] gamma = ProcessInput(input);

            StringBuilder b = new StringBuilder();
            StringBuilder logMessage = new StringBuilder();
            for (int i=0;i<=gamma.GetUpperBound(0);i++)
            {
                b.Append((gamma[i] > 0) ? "1" : "0");
            }

            Console.WriteLine(logMessage.ToString());
            Console.WriteLine(b.ToString() + ", " + Convert.ToInt32(b.ToString(), 2).ToString());

            return Convert.ToInt32(b.ToString(), 2);
        }

        public int CalculateEpsilon(List<string> input)
        {
            // all strings in input are same length
            // construct int array, length = length of first string
            int[] gamma = ProcessInput(input);

            StringBuilder b = new StringBuilder();
            StringBuilder logMessage = new StringBuilder();
            for (int i = 0; i <= gamma.GetUpperBound(0); i++)
            {
                b.Append((gamma[i] > 0) ? "0" : "1");
                               
            }

            Console.WriteLine(logMessage.ToString());
            Console.WriteLine(b.ToString() + ", " + Convert.ToInt32(b.ToString(), 2).ToString());

            return Convert.ToInt32(b.ToString(), 2);

        }

        private int[] ProcessInput(List<string> input)
        {

            int[] gamma = new int[input[0].Length];

            // initialize with 0
            for (int i = 0; i < gamma.GetUpperBound(0); i++)
            {
                gamma[i] = 0;
            }

            // if input = 1, gamma[i]++. if input=0, gamma[i]--
            foreach (string s in input)
            {
                // zero based index
                for (int i = 0; i < s.Length; i++)
                {
                    switch (s[i])
                    {
                        case '0':
                            {
                                gamma[i]--;
                                break;
                            }
                        case '1':
                            {
                                gamma[i]++;
                                break;
                            }
                    }
                }
            }

            return gamma;
        }
    }
}

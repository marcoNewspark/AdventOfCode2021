using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3
{
    class LifeSupportCalculator
    {
        public int CalculateOxygen(List<string> input)
        {
            // determine 
            // int[] gamma = ProcessInput(input);
            int maxCount = input[0].Length;
            List<string> work = input;
            
            for(int i =0; i < maxCount; i++)
            {
                // Determine dominant value
                var gamma = ProcessInput(work, i);

                // Dominant value = filtervalue
                var filterValue = (gamma >= 0) ? "1" : "0";

                // Filter list based on filtervalue on current position
                work = work.Where(value => value[i].ToString() == filterValue).ToList() ;

                if(work.Count == 1)
                {
                    break;
                }   
            }
            return Convert.ToInt32(work[0], 2);
        }


        public int CalculateCO2(List<string> input)
        {
            int maxCount = input[0].Length;
            List<string> work = input;

            for (int i = 0; i < maxCount; i++)
            {
                // determine dominant bit in the column
                var gamma = ProcessInput(work, i);

                // Filtervalue = opposite of dominant bit
                var filterValue = (gamma >= 0) ? "0" : "1";

                // Filter based on filtervalue on current position
                work = work.Where(value => value[i].ToString() == filterValue).ToList();

                if (work.Count == 1)
                {
                    break;
                }
            }

            return Convert.ToInt32(work[0],2);
        }

        private int ProcessInput(List<string> input, int pos)
        {
            int gamma = 0;
           
            // if input = 1, gamma[i]++. if input=0, gamma[i]--
            foreach (string s in input)
            {
                gamma = gamma + ((s[pos] == '0') ? -1 : 1);
            }

            return gamma;
        }


    }
}

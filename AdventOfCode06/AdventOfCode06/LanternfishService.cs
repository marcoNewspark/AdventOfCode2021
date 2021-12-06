using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode06
{
    class LanternfishService
    {
        List<int> LanternFish { get; set; }
        List<List<int>> AllFish { get; set; }
        
        public LanternfishService(List<int> lanternFish)
        {
            LanternFish = lanternFish;
            AllFish = new List<List<int>>();
            AllFish.Add(LanternFish);
        }

        public long Test2(int days)
        {
            Dictionary<int, long> fishes = new Dictionary<int, long>();

            for (int i = 0; i < 9; i++)
            {
                fishes[i] = LanternFish.Where(x => x == i).Count();
            }

            for (int d = 0; d < days; d++)
            {
            
                // determine new fishes
                long newFishes = fishes[0];

                long work = fishes[8];

                // shift
                for (int i = 7; i >= 0; i--)
                {
                    long work2 = fishes[i];
                    fishes[i] = work;
                    work = work2;
                }

                fishes[6] += newFishes ;
                fishes[8] = newFishes;
            }

            long total = 0;
            for (int i = 0; i < 9; i++)
            {
                total += fishes[i];
            }


            return total;
        }

        public int Test(int days)
        {
            int[][] allFish = new int[days][];

            allFish[0] = LanternFish.ToArray();

            // day 0 to day 255
            for(int i = 0; i < days; i++)
            {
                Console.WriteLine($"Day {i} ");
                // determine fishes at 0
                var addCount = 0;

                for(int j=0;j<i;j++)
                {
                    
                    var fishDay = allFish[j];

                    var filtered = fishDay.Where<int>(x => x == 0);
                    if (filtered != null)
                    {
                        addCount += fishDay.Where<int>(x => x == 0).Count<int>();
                    }

                    // process existing fishes
                    for(int k=0;k<=fishDay.GetUpperBound(0);k++)
                    {
                        allFish[j][k] = (allFish[j][k] == 0) ? 6 : allFish[j][k] - 1;
                    }

                    // add new fishes for today
                    allFish[i] = Enumerable.Range(0, addCount).Select(x => x = 8).ToArray<int>();
                }



                //allFish.ForEach(arr =>
                //{
                //addCount += arr.AsEnumerable<int>().Where(x => x == 0).Count();
                //});

                // process existing fishes

                // add new fish
                

            }

            return 0;
        }

        public long CalculatePopulationWithArrays(long days)
        {
            List<int[]> allFish = new List<int[]>();

            

            allFish.Add(LanternFish.ToArray());

            for (int i = 0; i < days; i++)
            {
                Console.WriteLine($"Day {i} - lists: {allFish.Count}");
                // determine fishes at 0
                var addCount = 0;
                allFish.ForEach(arr =>
                {
                    addCount += arr.AsEnumerable<int>().Where(x => x == 0).Count();
                });

                // process existing fishes
                // process existing lists
                for (int j = 0; j < allFish.Count; j++)
                {
                    for(var k=0; k < allFish[j].GetUpperBound(0); k++)
                    {
                        allFish[j][k] = (allFish[j][k] == 0) ? 6 : allFish[j][k] - 1;
                    }
                }

                // create new list of fishes
                int[] newList= Enumerable.Range(0, addCount).Select(x => x = 8).ToArray<int>();
                if (newList != null)
                {
                    allFish.Add(newList);
                }
            }

            return 0;
        }
        public long CalculatePopulation(long days)
        {
            
            for (long i = 0; i < days; i++)
            {
                Console.WriteLine($"Day {i} - lists: {AllFish.Count}");
                int addCounter = 0;
                // check number of 0s
                AllFish.ForEach(list =>
                {
                    list.ForEach(x => addCounter = (x == 0) ? addCounter + 1 : addCounter);
                });

                // process existing lists
                for (int j  = 0; j < AllFish.Count; j++)
                {
                    AllFish[j] = AllFish[j].ConvertAll<int>(f => f = (f == 0) ? 6 : f - 1);
                }

                // create new list 
                List<int> newList = new List<int>();
                newList.AddRange(Enumerable.Range(0, addCounter).Select(x => x = 8).ToList<int>());
                AllFish.Add(newList);

                //Console.WriteLine($"Day {i} - population: {LanternFish.Count + NewFish.Count}");

                //addCounter = FishArray.AsEnumerable<int>().Where(i => i == 0).Count<int>();
                //FishArray = FishArray.AsEnumerable<int>().Select(i => i = (i == 0) ? 6 : i - 1).ToArray() ;

                //LanternFish.ForEach(x => addCounter = (x == 0) ? addCounter + 1 : addCounter);
                //LanternFish = LanternFish.ConvertAll<int>(i => i = (i == 0) ? 6 : i - 1);



                //DumpPopulation();
            }
            var count = 0;
            AllFish.ForEach(list =>
           {
               count += list.Count;
           });
            return count;
        }
        
        public void DumpPopulation()
        {
            StringBuilder b = new StringBuilder();
            LanternFish.ForEach(x =>
            {
                b.Append(x + ",");
            });

            Console.WriteLine(b.ToString());
        }

    }
}

using System;
using System.Collections.Generic;

namespace Lists_of_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sub1 = new List<int> { 1, 2, 3 };
            List<int> sub2 = new List<int> { 3, 4, 5 };

            int[] mini1 = { 1, 2, 3 };
            int[] mini2 = { 4, 5, 6 };

            List<List<int>> metaList = new List<List<int>> {sub1, sub2};
            Console.WriteLine("metaList contains {0} items.", metaList.Count);

            int[][] metaArray = { mini1, mini2 };
            Console.WriteLine("metaArray contains {0} items.", metaArray.Length);

            List<int[]> LofA = new List<int[]> { mini1, mini2 };
            Console.WriteLine("LofA contains {0} items.", LofA.Count);

            List<int>[] AofF = { sub1, sub2 };
            Console.WriteLine("AofF contains {0} items.", AofF.Length);

            Console.ReadKey();
        }
        
    }
}

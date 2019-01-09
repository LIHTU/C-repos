using System;

namespace ArraysIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            // new array of length 5
            int[] ages = new int[5];
            Console.WriteLine("ages: {0}",ages);
            foreach (int age in ages)
            {
                Console.WriteLine("age: {0}", age);
            }

            // new array with 3 ints
            int[] numbs = { 1, 2, 3, 4, 5 };
            
            foreach (int num in numbs)
            {
                Console.WriteLine("num: {0}", num);
            }

            Array.Copy(ages, numbs, 4);

            Console.ReadKey(true);
        }
    }
}

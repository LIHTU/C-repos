using System;
using System.Collections.Generic;

namespace ListsVsArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // Needs Systems.Collections.Generic
            List<int> myList = new List<int>();
            myList.Insert(0, 2);
            Console.WriteLine("{0}",myList[0]);

            string s = "The cat is, on, the roof \t and I \t Love \n it. mew,mew,mew";
            string[] seps = {" ",", ","\t", ",", "\n" };
            string[] pieces = s.Split(seps, StringSplitOptions.None);
            List<string> parts = new List<string>();
            Console.WriteLine("pieces:");

            foreach (string p in pieces)
            {
                Console.WriteLine("{0}", p);
                parts.Insert(Array.IndexOf(pieces, p), p);
            }
            Console.WriteLine("parts:");
            foreach (string p in parts)
            {
                Console.WriteLine("{0}", p);
            }

            Console.ReadKey();
        }
    }
}

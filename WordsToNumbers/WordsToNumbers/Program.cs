using System;
using static System.Console;

namespace WordsToNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string. I'll convert it to a number that you can send to your robot girlfriend.");
            
            while (true)
            {
                string userString = ReadLine();
                WriteLine(userString);
                int stringVal = 0;
                foreach (char c in userString)
                {
                    // skips first member of string after first loop... WHY?
                    WriteLine("{0}\t {1} = {2}", userString.IndexOf(c), c, (int)c);
                    stringVal += (int)c;
                }
                WriteLine("The value of the sum of the unicode decimal vals of your string is: {0}", stringVal);
            }
        }
    }
}

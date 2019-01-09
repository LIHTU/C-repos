using System;
using static System.Console;

namespace UserInput
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Type your age.");
            string age = ReadLine();
            WriteLine("age: {0}", age);
            string n = "8";
            ReadKey();
            int snake = Convert.ToInt32(age);
            WriteLine("you are at least {0} months old.", (snake * 12));
            ReadKey();
        }
    }
}

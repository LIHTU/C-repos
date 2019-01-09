using System;
using static System.Console;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;

            while(true)
            {
                int[] numbers = { 10, 11, 12, 13, 14, 15 };
                Write("Please enter the index of the array:");

                try
                {
                    choice = Convert.ToInt32(ReadLine());
                    WriteLine("numbers[{0}] = {1}", choice, numbers[choice]);
                } catch (IndexOutOfRangeException e)
                {
                    WriteLine("Error: {0}:", e);
                    WriteLine("Error: Index should be from 0 to 5.");
                } catch (FormatException e)
                {
                    WriteLine("Error: {0}:", e);
                    Console.WriteLine("Error: You did not enter and integer");
                } catch (Exception e)
                {
                    WriteLine("Error: {0}:", e);
                    WriteLine(e.Message);
                }
            }
        }
    }
}

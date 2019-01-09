using System;
using static System.Console;
using System.IO;

namespace WorkingWithFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            // use stream reader and stream writer to encrypt the stock numbers.
            // instead of incrementing letters by a consistent amount, say {5}, you could increment by a set of amounts {5, 1, 12, 26, 13, 14, 16}, so 
            // first letter is incremented by 5, second by 1, etc.

            string path = "C:\\Users\\Robin\\Desktop\\teslaStocks2019.csv";
            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.EndOfStream != true)
                {
                    WriteLine(sr.ReadLine().Replace(',','\t'));
                }
                sr.Close();  // within using block.  What if outside?  sr not in that context error, silly.
            }

            string overritePath = "C:\\Users\\Robin\\Desktop\\overrite.csv";
            using (StreamWriter sr = new StreamWriter(overritePath, true))
            {

            }

            Console.ReadLine();
        }
    }
}

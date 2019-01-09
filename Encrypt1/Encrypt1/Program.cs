using System;
using static System.Console;
using System.IO;

namespace Encrypt1
{
    class Program
    {
        static void Main(string[] args)
        {
            // use stream reader and stream writer to encrypt the stock numbers.
            // instead of incrementing letters by a consistent amount, say {5}, you could increment by a set of amounts {5, 1, 12, 26, 13, 14, 16}, so 
            // first letter is incremented by 5, second by 1, etc.

            string path = "C:\\Users\\Robin\\Desktop\\ibm.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                string eFile = "";
                while (sr.EndOfStream != true)
                {
                    foreach (char c in sr.ReadLine())
                    {
                        int cInt = (int)c + 1;
                        char eChar = (char)cInt;
                        eFile += eChar;
                    }
                    eFile += "\n";
                }
                sr.Close();  // within using block.  What if outside?  sr not in that context error, silly.

                WriteLine(eFile);
            }

            Console.ReadLine();
        }
    }
}

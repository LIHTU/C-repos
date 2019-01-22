using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;

namespace Encrption1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\users\\Robin\\OneDrive\\Desktop\\ibm.txt";
            List<char> encipherSeed = new List<char>(){ '1', '2', '3', '4' };
            int seedIndex = 0;

            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.EndOfStream != true)
                {
                    string eString = "";
                    foreach (char c in sr.ReadLine())
                    {

                        
                        int asInt = (int)(c);
                        int inc = (int)encipherSeed[seedIndex];
                        int asInt2 = asInt + inc;

                        char eChar = (char)(asInt2);
                        // what is the format of the target file? utf?  ascii?
                        // how to find out the format/encoding of a file
                        // how is(isn't) encoding/format related to file extension?
                        // libraries can help.  maybe an ascii parse library or utf parse library
                        // use modulus to wrap through vals that break set ceiling
                        // https://en.wikipedia.org/wiki/Caesar_cipher
                        // use inverse distribution alorythm
                        WriteLine("asInt {0} + inc {1} = asInt2 {2}({3})", asInt, inc, asInt2, eChar);

                        eString += eChar;

                        seedIndex += 1;
                        if (seedIndex > encipherSeed.Count-1)
                        {
                            seedIndex = 0;
                        }
                    }
                    WriteLine(eString+"\n");
                }
                sr.Close();
            };
            ReadKey();
        }

        static string EncryptSimple(StreamReader sr, string line)
        {
            return "";
            //WriteLine(eString);
            //return eString;
        }
    }
}

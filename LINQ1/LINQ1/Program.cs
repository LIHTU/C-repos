using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] hts = { 1, 2, 3, 4, 5, 6 };
            var evens = from h in hts where (h % 2 == 0) select h;
            foreach (var e in evens)
            {
                Console.WriteLine("{0}", e);
            }
            Console.ReadLine();

            // Question for Alex:
            // Do we ever use Linq in our project? Why would we?  I could see possibly using it to 'simplify' a query
            // by whittling down a set that's returned from an already complicated sql query.
        }
    }
}

using System;

namespace Type_Casting
{
    class Program
    {
        static void Main(string[] args)
        {
            // converting from doubles 
            double pid = 3.1415;
            float pif = (float)pid;
            decimal pim = (decimal)pid;
            Console.Write("from doubles\t float:{0} dec:{1} \n", pif, pim);

            // converting from floats
            double pid2 = (double)pif; // acquired higher precision than original..., but lost accuracy...
            decimal pim2 = (decimal)pif;
            Console.Write("from floats\t double:{0} dec:{1} \n", pid2, pim2);

            // converting from floats 2 with literals
            double pid3 = (double)3.1415; // DID NOT acquire higher precision than original
            decimal pim3 = (decimal)3.1415;
            Console.Write("from lit floats\t double:{0} dec:{1} \n", pid3, pim3);

            // converting from decimals
            decimal pim4 = 3.1415m;
            double pid4 = (double)pim4;
            float pif2 = (float)pim4;
            Console.Write("double:{0} float:{1} \n", pid4, pif2);

            // test whether converting double > float, float > double ten million times results in less accuracy than doing it once.
            float times = 0;
            double myDouble = 3.1415;
            while (times < 10000000)
            {
                float myFloat = (float)pid;
                myDouble = (double)pif;
                times++;
            }

            
            Console.Write("myDouble:{0} \n", myDouble);
            float f1 = (float)3.000004;
            Console.Write("myDouble:{0} \n", f1);

            Console.ReadKey();
        }
    }
}

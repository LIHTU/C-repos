using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassA a = new ClassA();
            a.MyNumber = 5;
            a.InterfaceMethod();
            Console.Read();
        }

    }

    interface IShape
    {
        int MyNumber
        {
            get; set;
        }
        void InterfaceMethod();
    }

    class ClassA : IShape
    {
        private int myNumber;
        public int MyNumber
        {
            get
            {
                return myNumber;
            }
            set
            {
                if (value < 0)
                {
                    myNumber = 0;
                }
                else
                {
                    myNumber = value;
                }
            }
        }
        public void InterfaceMethod()
        {
            // why isn't MyNumber using .get() ? 
            Console.WriteLine("The number is {0}.", MyNumber);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace AbstractClassDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //MyAbstractClass abClass = new MyAbstractClass();
            ClassA a = new ClassA();
            a.PrintMessage();
            a.PrintMessageAbstract();
            Read();
        }
    }

    abstract class MyAbstractClass
    {
        private string message = "Hello c#";
        public void PrintMessage()
        {
            WriteLine(message);
        }
        public abstract void PrintMessageAbstract();


    }

    class ClassA : MyAbstractClass
    {
        public override void PrintMessageAbstract()
        {
            WriteLine("derived class says C# is fun!");
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Reflection;

namespace Payroll
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Staff
    {
        private float hourlyRate;
        private int hWorked;

        protected float TotalPay { get; set; }
        private float BasicPay { get; set; }
        private string NameOfStaff { get; set; }
        public int HoursWorked {
            get
            {
                return hWorked;
            }
            set
            {
                if (value > 0)
                {
                    hWorked = value;
                } else
                {
                    hWorked = 0;
                }
            }
        }

        public Staff(string name, float rate)
        {
            NameOfStaff = name;
            hourlyRate = rate;
        }

        public virtual void CalculatePay()
        {
            WriteLine("Calculating Pay...");
            BasicPay = hWorked * hourlyRate;
            TotalPay = BasicPay;
        }

        public string ToString(object src)
        {
            // can reflection handle fields and props?
            string rString = "";
            PropertyInfo[] StaffProps = typeof(Staff).GetProperties();
            foreach(PropertyInfo prop in StaffProps)
            {
                rString +=  prop.Name + ": " + prop.GetValue(src)+"\n";
            }
            return rString;
        }
        
    }
}

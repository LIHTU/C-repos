using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public virtual CalculatePay()
        {

        }
        
    }
}

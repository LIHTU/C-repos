using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Reflection;
using System.IO;

namespace Payroll
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Staff> myStaff = ReadFile.read();
            WriteLine(myStaff.Count);
            foreach(Staff s in myStaff)
            {
                WriteLine(s.ToString());
            }

            ReadKey();  // end program
        }
    }

    class Staff
    {
        private float hourlyRate;
        private int hWorked;

        protected float TotalPay { get; set; }
        private float BasicPay { get; set; }
        protected string NameOfStaff { get; set; }
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
            NameOfStaff = name; // could be neg; not good.
            hourlyRate = rate; // also could be neg; not good.
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
                rString +=  prop.Name + ": " + prop.GetValue(src)+"\n";  // bar.GetValue(foo)
            }
            return rString;
        }
        
    }

    class Manager : Staff
    {
        private const float managerHourlyRate = 50;

        public int Allowance { get; set; }

        public Manager(string name) : base(name, managerHourlyRate) { }

        public override void CalculatePay()
        {
            base.CalculatePay();  //keyword base is handy.  When overriding, is we want to resuse part of parent contructor, call base.thingToResuse()
            Allowance = 1000;
            if (HoursWorked > 160)
            {
                TotalPay = Allowance + TotalPay; // can't use BasicPay here due to it being private (not protected)
            }
        }
        public override string ToString()
        {
            string managerString = "" +
                "managerHourlyRate: " + managerHourlyRate + "\n" +
                "Allowance: " + Allowance + "\n" +
                "HoursWorked: " + HoursWorked + "\n" +
                "NameOfStaff: " + NameOfStaff + "\n";
            return managerString;
        }
    }

    class Admin : Staff
    {
        private const float overtimeRate = 15.5F;
        private const float adminHourlyRate = 30;

        private float Overtime { get; set; }

        public Admin(string name) : base(name, adminHourlyRate) {
            // could this have content?  They've been empty in examples.
            name = name + "content added in constructor";
        }

        public override void CalculatePay()
        {
            base.CalculatePay();  // To use the functionality of the parent + bonus.  override { base.somehing(); new stuff...}
            if (HoursWorked > 160)
            {
                Overtime = overtimeRate * (HoursWorked - 160); // Hoursworked here is inherited
            }
        }
        public override string ToString()
        {
            string adminString = "" +
                "adminHourlyRate: " + adminHourlyRate + "\n" +
                "overtimeRate: " + overtimeRate + "\n" +
                "Overtime: " + Overtime + "\n";
            return base.ToString(this) + adminString;
        }
    }

    class ReadFile
    {
        public static List<Staff> read() {
            List<Staff> myStaff = new List<Staff>();
            string[] result = new string[2];
            string path = "staff.txt";// in the debug folder where the ".exe" is, according to book.  don't see exe tho
            string[] separator = { ", " };

            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.EndOfStream != true)
                    {
                        string line = sr.ReadLine();
                        result = line.Split(separator, StringSplitOptions.None);
                        if (result[1] == "Manager") myStaff.Add(new Manager(result[0]));
                        else if (result[1] == "Admin") myStaff.Add(new Admin(result[0]));
                        else WriteLine("Could not resolve staff role {0}", result[1]);
                    }
                    sr.Close();
                }
            } else WriteLine("No file");
            return myStaff;
        }
    }
}

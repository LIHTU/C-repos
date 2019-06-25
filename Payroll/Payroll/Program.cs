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
            List<Staff> myStaff = FileReader.ReadFile();
            int month = 0;
            int year = 0;

            while(year == 0)
            {
                Console.Write("\nPlease enter the year: ");
                try
                {
                    year = int.Parse(ReadLine());
                    WriteLine("year: {0}", year);
                    if (year > 2019 || year < 2000)
                    {
                        throw new YearRangeException("year outside of company's history."); // explicit throw so we can specify exception type
                    }
                    // don't need > Exception is thrown automatically due to try{} block
                    // if no try block, program breaks if string entered.
                    //else if (typeof(int) == year.GetType()) // flash card
                    //else if (year is Int) // flash card
                    //{
                    //    throw new Exception();
                    //}
                }
                catch (YearRangeException e)
                {
                    WriteLine(e.Message);
                    year = 0;
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                    year = 0;
                }
            }

            while (month == 0)
            {
                Console.Write("\nPlease enter the month: ");
                try
                {
                    month = int.Parse(ReadLine());
                    WriteLine("month: {0}", month);
                    if (month > 12 || month < 1)
                    {
                        throw new MonthRangeException("Please enter a valid month value (1-12)");
                    }
                }
                catch (MonthRangeException e)
                {
                    WriteLine(e.Message);
                    month = 0;
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                    month = 0;
                }
            }

            foreach(Staff s in myStaff)
            {
                try
                {
                    Write("Enter the hours worked for {0}: ", s.NameOfStaff);
                    s.HoursWorked = int.Parse(ReadLine());
                    s.CalculatePay();
                    WriteLine(s.ToString());
                } catch(Exception e)
                {
                    WriteLine(e.Message);
                }
            }

            PaySlip ps = new PaySlip(month, year);
            ps.GeneratePaySlip(myStaff);
            ps.GenerateSummary(myStaff);

            ReadKey();  // end program
        }
    }

    public class YearRangeException : Exception
    {
        //public string override Message { get; set; }
        public YearRangeException (string Message) : base(Message)
        {
            Message = "Year out of range."; 
        }
    }

    public class MonthRangeException : Exception
    {
        //public string override Message { get; set; }
        public MonthRangeException(string Message) : base(Message)
        {
            Message = "Month out of range.";
        }
    }

    class Staff
    {
        private float hourlyRate;
        private int hWorked;

        protected float TotalPay { get; set; }
        public float BasicPay { get; set; }
        public string NameOfStaff { get; set; }
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
                "NameOfStaff: " + NameOfStaff + "\n" +
                "managerHourlyRate: " + managerHourlyRate + "\n" +
                "Allowance: " + Allowance + "\n" +
                "HoursWorked: " + HoursWorked + "\n";
                
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
                "AdminHourlyRate: " + adminHourlyRate + "\n" +
                "overtimeRate: " + overtimeRate + "\n" +
                "Overtime: " + Overtime + "\n";
            return base.ToString(this) + adminString;
        }
    }

    class FileReader
    {
        public static List<Staff> ReadFile() {
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

    class PaySlip
    {
        private int month;
        private int year;
        enum MonthsOfYear { Jan=1, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec }; // why capital name?

        public PaySlip(int payMonth, int payYear)
        {
            month = payMonth;
            year = payYear;
        }

        public void GeneratePaySlip(List<Staff> myStaff)
        {
            string path;
            foreach(Staff s in myStaff)
            {
                path = s.NameOfStaff+".txt";
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("PAYSLIP FOR {0} {1}\n", (MonthsOfYear)month, year);
                    sw.WriteLine("===================================\n");
                    sw.WriteLine("Name of Staff: {0}\n", s.NameOfStaff);
                    sw.WriteLine("Hours Worked: {0}\n\n", s.HoursWorked);
                    sw.WriteLine("Basic Pay: {0:C}\n", s.BasicPay);
                    if (s.GetType() == typeof(Manager) )
                    {
                        sw.WriteLine("Allowance: {0:C}\n\n", ((Manager)s).Allowance);  // Casting!
                    }
                    sw.WriteLine("Total Pay: {0}", s.BasicPay + (s.GetType() == typeof(Manager) ? ((Manager)s).Allowance : 0));

                    sw.Close();
                }
            }
        }

        public void GenerateSummary(List<Staff> staffList)
        {
            // from where order by select
            var result = from emp in staffList
                where emp.HoursWorked < 10
                //order by emp.NameOfStaff
                select emp;
            WriteLine("result: ", result);

            string path = "summary.txt";

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Staff with less than 10 working hours in {0}\n\n", (MonthsOfYear)month);
                foreach (Staff s in result)
                {
                    sw.WriteLine("Name: {0}\t Hours Worked: {1}", s.NameOfStaff, s.HoursWorked);
                }
                sw.Close();
            }
        }
    }
}

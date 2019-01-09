using System;

namespace ClassDemo
{
    class Staff
    {
        private String nameOfStaff;
        private const int hourlyRate = 30;
        private int hWorked;

        public int HoursWorked
        {
            get
            {
                return hWorked;
            }
            set
            {
                if (value > 0)
                    hWorked = value;
                else
                    hWorked = 0;
            }
        }

        public void PrintMessage()
        {
            Console.WriteLine("Calculating Salary...");
        }

        public int CalculatePay()
        {
            PrintMessage();
            int staffPay;
            staffPay = hWorked * hourlyRate;

            if (hWorked > 0)
                return staffPay;
            else
                return 0;
        }

        public int CalculatePay(int bonus, int allowances)
        {
            PrintMessage();
            if (hWorked > 0)
                return hWorked * hourlyRate + bonus + allowances;
            else
                return 0;
        }

        public override string ToString()
        {
            return "Name of Staff = " + nameOfStaff +
                ", hourlyrate = " + hourlyRate +
                ", hWorked = " + hWorked;
        }

        public Staff(string name)
        {
            nameOfStaff = name;
            Console.WriteLine("\n" + nameOfStaff);
            Console.WriteLine("----------------------------------\n");
        }

        public Staff(string firstName, string lastName)
        {
            nameOfStaff = firstName + " " + lastName;
            Console.WriteLine("\n" + nameOfStaff);
            Console.WriteLine("----------------------------------\n");
        }
    }

    public static class Building {
        public static void DisplayTime()
        {
            string now = DateTime.Now.ToString("hh:mm tt");
            Console.WriteLine(now);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Staff Robin = new Staff("Robin");
            Robin.HoursWorked = 30;
            Robin.CalculatePay();
            Robin.ToString();
            Console.WriteLine(Robin.ToString());
            Robin.HoursWorked = 40;
            Console.WriteLine(Robin.ToString());
            Console.WriteLine("{0:C}", Robin.CalculatePay());
            Building.DisplayTime();

            Console.ReadKey();

        }
    }
}

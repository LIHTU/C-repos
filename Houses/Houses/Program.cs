using System;
using static System.Console;
using System.Reflection;

namespace Houses
{
    public class Apartment
    {
        public int AddressLine1 { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }

        public Apartment(int line1, string city, int zip)
        {
            AddressLine1 = line1;
            City = city;
            Zip = zip;
        }
    }
    public class House
    {
        public string Owner;
        public string[] Residents;
        public string City;


        public House(string locationCity, string ownerName)
        {
            Owner = ownerName;
            City = locationCity;
            WriteLine("new house created.");
        }
        public House(string ownerName) { }
        public House()
        {
            WriteLine("new parameterless house created.");
        }
        
    }

    public class Rental : House
    {

        public Rental(float rent, string locationCity, string ownerName) : base(locationCity, ownerName)
        {
            WriteLine("new rental house created with 3 params."); 
        }
        public Rental(float rent)
        {
            WriteLine("new rental house created with 1 params.");
        }
        public int Rent { get; set; }
    }

    public class TimeShare : House
    {
        public TimeShare()
        {
            WriteLine("new time share. no details specified.");
        }
        public TimeShare(float rent, string locationCity) : base(locationCity)
        {

        }
    }

    public static class ThirdEye
    {
        public static void SeeInto<T>(T src)
        {
            WriteLine("Third Eye Sees:");
            PropertyInfo[] srcProps = typeof(T).GetProperties();
            WriteLine("{0}", srcProps.Length);
            foreach (PropertyInfo prop in srcProps)
            {
                WriteLine("{0}: {1}", prop.Name, prop.GetValue(src));
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Rental LawrenceHouse = new Rental(1494, "eug", "Scarlet");
            Rental PolkHouse = new Rental(2000);
            TimeShare Vacay = new TimeShare(2000, "Sioux fAlls");
            House Grange = new House("Boulder","Robin");
            Apartment Medary = new Apartment(517, "Brookings", 57006);

            ThirdEye.SeeInto(LawrenceHouse);
            ThirdEye.SeeInto(PolkHouse);
            ThirdEye.SeeInto(Vacay);
            ThirdEye.SeeInto(Grange);
            ThirdEye.SeeInto(Medary);

            // if you declare a House with just owner name, it gets contructed right?
            House pippsHouse = new House("pippin");
            pippsHouse.ToString();

            ReadKey();
        }
    }
}

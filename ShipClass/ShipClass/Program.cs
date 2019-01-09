using System;
using static System.Console;
using System.Reflection;

namespace ShipClass
{

    public class Ship {
        private int health = 10;
        private int shields = 10;

        // constructor

        public Ship(string name)
        {
            ShipName = name;
        }
        public Ship (string name, int[] dimensions)
        {
            ShipName = name;
            Dimensions = dimensions;
        } 

        public String ShipName { get; set; }
        public int Health
        {
            get { return health; }
            set
            {
                if (value > 10)
                {
                    health = 10;
                }
                else if (value < 0)
                {
                    health = 0;
                }
                else
                {
                    health = value;
                }
            }
        }
        public int Shields
        {
            get { return shields; }
            set
            {
                if (value > 10)
                {
                    shields = 10;
                }
                else if (value < 0)
                {
                    shields = 0;
                }
                else
                {
                    shields = value;
                }
            }
        }
        public int[] Dimensions { get; set; }
        public override string ToString()
        {
            PropertyInfo[] shipProps = typeof(Ship).GetProperties();
            string propsString = "";
            propsString += "\nProperties of ship class (from ToString method):\n";
            foreach (PropertyInfo sProp in shipProps)
            {
                propsString += sProp.Name + "\n";
            }
            return propsString;
        }
        
        // Could you modify this so that you could make it global and pass in any class and instantiated object?  Try in Houses Project
        public string ToString(object src)
        {
            PropertyInfo[] shipProps = typeof(Ship).GetProperties();
            string propsString = "";
            propsString += "\nProperties of ship object (from ToString method):\n";
            foreach (PropertyInfo sProp in shipProps)
            {
                // in JS we would do Object.getValue(property) or just Object.Property to get the val
                // in CS we do property.GetValue(object, null)
                propsString += sProp.Name + ": " + sProp.GetValue(src) + "\n";
            }
            return propsString;
        }
    }

    public static class ThirdEye
    {
        public static string SeeAll<T>(T src)
        {
            PropertyInfo[] srcProps = typeof(T).GetProperties();
            string propsString = "";
            propsString += "\nThird Eye Sees!:\n";
            foreach (PropertyInfo prop in srcProps)
            {
                // in JS we would do Object.getValue(property) or just Object.Property to get the val
                // in CS we do property.GetValue(object, null)
                propsString += prop.Name + ": " + prop.GetValue(src) + "\n";
            }
            return propsString;
        }
    }

    public class Planet
    {
        private float density;
        private string variety;
        private string primaryColor;
        private string secondaryColor;

        public Planet(string name, string variety, int size)
        {
            Name = name;
        }

        public string Name { get; set; }
        public string Variety {
            get {
                return variety;
            }
            set {
                if (value == "gas" || value == "g")
                {
                    variety = "Gas";
                    density = 0.05F;
                }
                if (value == "terrestrial" || value == "t")
                {
                    variety = "Terrestrial";
                    density = 1.4F;
                }
            }
        }
        public string Size { get; set; }
    }

    public static class Cursor
    {
        public static void setColor(int a, int b)
        {
            if (a > b) {
                Console.ForegroundColor = ConsoleColor.Green;
            } else if (a<b) {
                Console.ForegroundColor = ConsoleColor.Red;
            } else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Ship RobinShip = new Ship("Robin's Ship");
            RobinShip.Health = 30;
            RobinShip.Shields = -20;

            Ship PippinShip = new Ship("Pippin's Ship");
            PippinShip.Health = 10;
            PippinShip.Shields = 10;

            WriteLine("Ship Name \tHealth\tShields");
            Write("{0} \t", RobinShip.ShipName);
            Cursor.setColor(RobinShip.Health, PippinShip.Health);
            Write("{0} \t", RobinShip.Health);
            Cursor.setColor(RobinShip.Shields, PippinShip.Shields);
            Write("{0} \n", RobinShip.Shields);

            Console.ForegroundColor = ConsoleColor.White;
            Write("{0} \t", PippinShip.ShipName);
            Cursor.setColor(PippinShip.Health, RobinShip.Health);
            Write("{0} \t", PippinShip.Health);
            Cursor.setColor(PippinShip.Shields, RobinShip.Shields);
            Write("{0} \t ", PippinShip.Shields);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Ship starShip = new Ship("space goer");
            // You can use reflection to create an instance of a type dynamically and even invoke methods of the type.

            WriteLine("\n"); WriteLine("\n");

            Type shipType = typeof(Ship);
            WriteLine("shipType.Name: {0}, shipType.Namespace: {1}", shipType.Name, shipType.Namespace);

            PropertyInfo[] shipProps = typeof(Ship).GetProperties();
            WriteLine("\nproperties of ship class:");
            foreach(PropertyInfo sProp in shipProps)
            {
                WriteLine(sProp.Name);
            }

            WriteLine(RobinShip.ToString());
            WriteLine(RobinShip.ToString(RobinShip));
            WriteLine(ThirdEye.SeeAll(RobinShip));


            ReadKey();
        }
    }
}

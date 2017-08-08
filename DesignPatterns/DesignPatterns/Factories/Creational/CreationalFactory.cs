using System;
using System.Threading.Tasks;
using static System.Console;

namespace DesignPatterns.Factories.Creational
{
    //Proper Factories
    //Factory Method

    //public enum CooridinateSystem
    //{
    //    Cartesian,
    //    Polar
    //}

    //seprate component knowing how to initalise types in a particular way
    

    public class Point
    {
       //factory method = name not constrained to constructor
       //Same overload with same arguments different names

        private double x, y;

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }


        private Point(double x, double y // names do not communicate intent CoordinateSystem cs = CoordinateSystem.Cartesian
            )
        {
            this.y = y;
            this.x = x;
            //POOR DESIGN TOO MANY ARGUMENTS
            //switch (system)
            //{
            //        case CooridinateSystem.Cartesian:
            //            x = a;
            //            y = b;
            //        break;
            //        case CooridinateSystem.Polar:
            //            y = a * Math.Cos(b);
            //            y = a * Math.Sin(b);
            //            break;
            //}
        }

        public static Point Origin = new Point(0,0); //better
        public static Point Origin2 => new Point(0,0);
        
        //inner factory
        public static class Factory
        {
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }

            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }
    }

    //public class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var point = Point.Factory.NewPolarPoint(1.0, Math.PI / 2);
    //        WriteLine(point);

    //        var origin = Point.Origin;
    //        var origin2 = Point.Origin2;

    //        ReadLine();
    //    }

       
    //}
}

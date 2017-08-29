using Autofac.Features.ResolveAnything;
using static System.Console;
namespace DesignPatterns.Singleton.Monostate
{
    public class MonostateDemo
    {
        public class Ceo
        {
            private static string name;
            private static int age;

            public string Name
            {
                get => name;
                set => name = value;
            }

            public int Age
            {
                get => age;
                set => age = value;
            }

            public override string ToString()
            {
                return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
            }
        }

        //public static void Main(string[] args)
        //{
        //    var ceo = new Ceo();
        //    ceo.Name = "Rudi J";
        //    ceo.Age = 55;

        //    WriteLine(ceo);

        //    var ceo2 = new Ceo();
        //    ceo2.Name = "JR";
        //    Write(ceo2);

        //    ReadLine();
        //}

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using static  System.Console;

namespace DesignPatterns.Factories.Abstract
{
    //give out abstract objects instead of concrete objects
    //Not returning types you are creating = returning abstract classes or interfaces

    public interface IHotDrink
    {
        void Consume();
    }

    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            WriteLine($"this tea is nice");
        }
    }

    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            WriteLine("Coffee is great");
        }
    }

    public interface IHotdrinkFactory
    {
        IHotDrink Prepare(int amount);
    }

    internal class TeaFactory : IHotdrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            WriteLine($"Put in a tea bag pour {amount}");
            return new Tea();
        }
    }

    public class HotDrinkMachine
    {
        ////THis breaks OCP
        //public enum AvailbleDrink
        //{
        //    Coffee, Tea
        //}

        //private Dictionary<AvailbleDrink, IHotdrinkFactory> factories = new Dictionary<AvailbleDrink, IHotdrinkFactory>();

        //public HotDrinkMachine()
        //{
        //    foreach (AvailbleDrink drink in Enum.GetValues(typeof(AvailbleDrink)))
        //    {
        //        var factory =
        //            (IHotdrinkFactory) Activator.CreateInstance(Type.GetType(
        //                $"DesignPatterns.Factories.Abstract.{Enum.GetName(typeof(AvailbleDrink), drink)}Factory"));
        //        factories.Add(drink, factory);
        //    }
        //}

        //public IHotDrink MakeDrink(AvailbleDrink drink, int amount)
        //{
        //    return factories[drink].Prepare(amount);
        //}


        //Use reflection rather
        private List<Tuple<string, IHotdrinkFactory>> factories= new List<Tuple<string, IHotdrinkFactory>>();

        public HotDrinkMachine()
        {
            foreach (var type in typeof(HotDrinkMachine).Assembly.GetTypes())
            {
                if (typeof(IHotdrinkFactory).IsAssignableFrom(type) && !type.IsInterface)
                {
                    factories.Add(Tuple.Create(
                        type.Name.Replace("Factory", string.Empty), (IHotdrinkFactory)Activator.CreateInstance(type)
                        ));
                }
            }
        }

        public IHotDrink MakeDrink()
        {
            WriteLine("Avail: ");
            for (var index = 0; index < factories.Count; index++)
            {
                var tuple = factories[index];
                Write($"{index} : {tuple.Item1}");
               
            }

            while (true)
            {
                string s;
                if ((s = Console.ReadLine()) != null && int.TryParse(s, out int i) && i > 0 && i < factories.Count)
                {
                    Write("Specify Amount: ");
                    s = ReadLine();
                    if (s != null && int.TryParse(s, out int amount) && amount > 0)
                    {
                        return factories[i].Item2.Prepare(amount);
                    }
                }

                WriteLine("incorrect input. Try again!");
            }
        }
    }

    internal class CoffeeFactory : IHotdrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            WriteLine($"Grind some beans and pourt {amount} ml, add sugar.");
            return new Coffee();
        }
    }


    public class Program
    {
        static void Main(string[] args)
        {
            var machine = new HotDrinkMachine();
            var drink = machine.MakeDrink();
            drink.Consume();
            //var drink = machine.MakeDrink(HotDrinkMachine.AvailbleDrink.Tea, 100);
            //drink.Consume();

            ReadLine();
        }
    }
}

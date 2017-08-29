using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static System.Console;

namespace DesignPatterns.Singleton.Singleton
{
    /// <summary>
    /// Component which is instantiated only once and restist the idea of being instantiated more than once
    /// </summary>


    public interface IDatabase
    {
        int GetPopulation(string name);
    }

    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;
        private static int instanceCount;
        public static int Count => instanceCount;
        private int count = 100;
        private SingletonDatabase()
        {
            instanceCount++;
            capitals = new Dictionary<string, int>();
            foreach (var capital in SingletonDemo.Capitals)
            {
                count++;
                capitals.Add(capital, count);
            }
        }

        private static Lazy<SingletonDatabase> instance { get; } = new Lazy<SingletonDatabase>(() => new SingletonDatabase());
        public static SingletonDatabase Instance => instance.Value;

        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }

    public class SingletonRecordFinder
    {
        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
            {
                result += SingletonDatabase.Instance.GetPopulation(name);
            }

            return result;
        }
    }

    public class Tests
    {
        [Fact]
        public void is_singleton()
        {
            var db = SingletonDatabase.Instance;
            var db2 = SingletonDatabase.Instance;
            Assert.Equal(db, db2);
            Assert.Equal(SingletonDatabase.Count, 1);
        }

        [Fact]
        public void singleton_population_test()
        {
            var rf = new SingletonRecordFinder();
            var names = SingletonDemo.Capitals;
            var total = rf.GetTotalPopulation(names);
            Assert.Equal(total, 515);
        }
    }


    public class SingletonDemo
    {
    //    public static void Main(string[] args)
    //    {
    //        var db = SingletonDatabase.Instance;
    //        WriteLine($"Pretoria has {db.GetPopulation("Pretoria")}");


    //        ReadLine();

    //    }

        public static List<string> Capitals = new List<string>
        {
            "Pretoria",
            "Washington", 
            "London",
            "Shanghai",
            "Melbourne"
        };
    }

   
}

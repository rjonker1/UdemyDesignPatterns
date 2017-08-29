using System.Collections.Generic;
using DesignPatterns.Singleton.Singleton;
using static System.Console;
namespace DesignPatterns.Singleton.SingletonDI
{

    public class ConfigurableRecordFinder
    {
        private readonly IDatabase database;
        public ConfigurableRecordFinder(IDatabase database)
        {
            this.database = database;
        }


        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
            {
                result += database.GetPopulation(name);
            }

            return result;
        }

    }

    public class FakeDatabase : IDatabase
    {
        public int GetPopulation(string name)
        {
            throw new System.NotImplementedException();
        }
    }

    public class SingletonDIDemo
    {
        //public static void Main(string[] args)
        //{
            
        //}
    }
}

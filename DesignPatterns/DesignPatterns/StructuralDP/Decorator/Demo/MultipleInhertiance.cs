using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralDP.Decorator.Demo
{
    public interface IBird
    {
        string Fly();
    }

    public class Bird : IBird
    {
        public string Fly()
        {
            return "Fly like an eagle";
        }
    }

    public interface ILizard
    {
        string Crawl();
    }

    public class Lizard : ILizard
    {
        public string Crawl()
        {
            return "Crawl like a snake";
        }
    }

    public class Dragon //no multiple inheritance
    {
        private IBird bird;
        private ILizard lizard;


        public Dragon(IBird bird, ILizard lizard)
        {
            this.bird = bird;
            this.lizard = lizard;
        }

        public string Crawl()
        {
            return lizard.Crawl();
        }

        public string Fly()
        {
            return bird.Fly();
        }

    }
}

using static System.Console;

namespace DesignPatterns.StructuralDP.Decorator.Demo
{
    /// <summary>
    /// Adding behaviour wihtout altering the class itself
    /// Dont want to rewrite or alter existing code
    /// Keep new functionality separator
    /// 
    /// Facilitates addition of behaviours to inidiviual objects without inheriting from them
    /// </summary>
    public class DecoratorDemo
    {
        public static void Main(string[] args)
        {
            var cb = new CodeBuilder();
            cb.AppendLine("class Foo");
            cb.AppendLine("{");
            cb.AppendLine("}");

            WriteLine(cb);

            //adapter
            MyStringBuilder msb = "class Foo";
            msb += "{";
            msb += "}";
            WriteLine(msb);

            //Mulitple Inheritance
            var dragon = new Dragon(new Bird(), new Lizard());
            WriteLine(dragon.Fly());
            WriteLine(dragon.Crawl());



            ReadLine();
        }
    }
}

using System;
using DesignPatterns.Solid;
using Solid;
using static System.Console;

namespace DesignPatterns
{

  

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        #region Single Responsibility

    //        //var journal = new Journal();
    //        //journal.AddEntry("Entry 1");
    //        //journal.AddEntry("Entry 2");
    //        //journal.AddEntry("Entry 3");
    //        //Console.WriteLine(journal);


    //        //var persistence = new Persistence();
    //        //var fileName = @"C:\0-Projects\my\Udemy\temp\journal.txt";
    //        //persistence.SaveToFile(journal, fileName, true);
    //        //Process.Start(fileName);

    //        #endregion

    //        #region Open Closed Principle

    //        var apple = new Product("Apple", Color.Green, Size.Small);
    //        var tree = new Product("Tree", Color.Green, Size.Large);
    //        var house = new Product("Apple", Color.Blue, Size.Large);

    //        Product[] products = new[] {apple, house, tree};

    //        //BAD
    //        //var filter = new ProductFilter();
    //        //Console.WriteLine("Green products (old): ");
    //        //foreach (var product in filter.FileterByColour(products, Color.Green))
    //        //{
    //        //    Console.WriteLine($" {product.Name } is green");
    //        //}

    //        //BETTER

    //        //var betterFilter = new BetterFilter();
    //        //Console.WriteLine("Green products (new): ");
    //        //foreach (var product in betterFilter.Filter(products, new ColorSpecification(Color.Green)))
    //        //{
    //        //    Console.WriteLine($" {product.Name } is green");
    //        //}

    //        //Console.WriteLine("Large Green products (new): ");
    //        //foreach (var product in betterFilter.Filter(products, new AddSpecification<Product>(new ColorSpecification(Color.Green), new SizeSpecification(Size.Large) )))
    //        //{
    //        //    Console.WriteLine($" {product.Name } is green and {product.Size}");
    //        //}

    //        #endregion

    //        #region LiskovSubstitutionPrinciple

    //        //var rectangle = new Rectangle(5,6);
    //        //WriteLine($"{rectangle} has area {Area(rectangle)}");

    //        //Rectangle square = new Square();
    //        //square.Width = 4;
    //        //WriteLine($"{square} has area {Area(square)}");

    //        #endregion

    //        #region Interface Segregation Principle



    //        #endregion

    //        #region Dependency Inversion Principle

    //        var parent = new Person { Name = "John" };
    //        var child1 = new Person { Name = "Chris" };
    //        var child2 = new Person { Name = "Matt" };

    //        // low-level module
    //        var relationships = new Relationships();
    //        relationships.AddParentAndChild(parent, child1);
    //        relationships.AddParentAndChild(parent, child2);

    //        new Research(relationships);


    //        #endregion

    //        Console.ReadLine();
    //    }
    //}
}

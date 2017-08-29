using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static  System.Console;

namespace DesignPatterns.StructuralDP.Composite.Demo
{
    /// <summary>
    /// A mechanism of treating individual (scalar) object and compositions of objects in a uniform manner
    /// </summary>
    class CompositeDemo
    {
        static void Main(string[] args)
        {
            ////Geomentric shapes
            //var drawing = new GraphicObject() {Name = "Drawing One"};
            //drawing.Children.Add(new Square() {Color = "Red"});
            //drawing.Children.Add(new Circle() { Color = "Yellow" });

            //var group = new GraphicObject();
            //group.Children.Add(new Square() { Color = "Blue" });
            //group.Children.Add(new Circle() { Color = "Blue" });

            //drawing.Children.Add(group);

            //WriteLine(drawing);


            //Neural Network
            var neuron1 = new Neuron();
            var neuron2 = new Neuron();
            neuron1.ConnectTo(neuron2);

            ReadLine();
        }

        
    }
}

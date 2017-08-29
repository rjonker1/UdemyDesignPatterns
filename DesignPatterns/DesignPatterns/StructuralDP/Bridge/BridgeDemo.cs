using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using static System.Console;

namespace DesignPatterns.StructuralDP.Bridge.BrideDemo
{
    /// <summary>
    /// Avoid entity explosion. Use Aggregation
    /// A mechanism that decouples an interface (hieracrchy) from an implmentation (hierarchy)
    /// Connect different abstractions together
    /// Connect domain object to different implementations
    /// </summary>

        /// Decoupleing abstraction from implementation
        /// Both can exist as hierarchies
        /// Stronger form of encapsulation

    public interface IRenderer
    {
        void RenderCircle(float radius);
    }

    public class VectorRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            WriteLine($"Drawing a circle of radius {radius}");
        }
    }

    public class RasterRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            WriteLine($"Drawing pixels for circle of radius {radius}");
        }
    }

    public abstract class Shape
    {
        protected IRenderer renderer;

        public Shape(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public abstract void Draw();
        public abstract void Resize(float factor);
    }

    public class Circle : Shape
    {
        private float radius;
        public Circle(IRenderer renderer, float radius) : base(renderer)
        {
            this.radius = radius;
        }
        public override void Draw()
        {
            renderer.RenderCircle(radius);
        }

        public override void Resize(float factor)
        {
            radius *= factor;

        }
    }

    public class BridgeDemo
    {
        //static void Main(string[] args)
        //{
        //    var cb = new ContainerBuilder();
        //    cb.RegisterType<VectorRenderer>().As<IRenderer>();
        //    cb.Register((c, p) => new Circle(c.Resolve<IRenderer>(), p.Positional<float>(0)));

        //    using (var c = cb.Build())
        //    {
        //        var circle = c.Resolve<Circle>(
        //            new PositionalParameter(0, 5.0f)
        //        );
        //        circle.Draw();
        //        circle.Resize(2);
        //        circle.Draw();
        //    }

        //    ReadLine();

        //}
    }
}

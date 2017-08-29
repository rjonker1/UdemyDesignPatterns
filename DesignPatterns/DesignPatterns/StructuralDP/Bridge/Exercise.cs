
using System.Collections.Generic;

namespace DesignPatterns.StructuralDP.Bridge
{

    public interface IRenderer
    {
        string WhatToRenderAs { get; }
    }

    public abstract class Shape
    {
        private readonly IRenderer renderer;

        protected Shape(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public string Name { get; set; }
        public override string ToString()
        {
            return $"Drawing {Name} as {renderer.WhatToRenderAs}";
        }
    }

    public class Triangle : Shape
    {
        public Triangle(IRenderer renderer) : base(renderer)
        {
            Name = "Triangle";
        }
    }

    public class Square : Shape
    {
        public Square(IRenderer renderer) : base(renderer)
        {
            Name = "Square";
        }
    }

    public class RasterRenderer : IRenderer
    {
        public string WhatToRenderAs => "pixels";
    }

    public class VectorRenderer : IRenderer
    {
        public string WhatToRenderAs => "lines";
    }


    //public abstract class Shape
    //{
    //    public string Name { get; set; }
    //}

    //public class Triangle : Shape
    //{
    //    public Triangle() => Name = "Circle";
    //}

    //public class Square : Shape
    //{
    //    public Square() => Name = "Square";
    //}

    //public class VectorSquare : Square
    //{
    //    public override string ToString() => "Drawing {Name} as lines";
    //}

    //public class RasterSquare : Square
    //{
    //    public override string ToString() => "Drawing {Name} as pixels";
    //}

    // imagine VectorTriangle and RasterTriangle are here too
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Solid
{
    //substitute base type for a sub type
    public class Rectangle
    {
        public virtual int  Width { get; set; }
        public virtual int Height { get; set; }

        public Rectangle()
        {
            
        }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)} :{Width}, {nameof(Height)} : {Height}";
        }

        static public int Area(Rectangle rectangle) => rectangle.Height * rectangle.Width;
    }

    public class Square : Rectangle
    {
        public override int Width {
            set { base.Width = base.Height = value; }
        }

        public override int Height
        {
            set { base.Width = base.Height = value; }
        }
    }


}

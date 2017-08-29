using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DesignPatterns.StructuralDP.Adapter
{
    /// <summary>
    /// Getting the interface you want from the interface you have
    /// Construct whic adapts existing interface X to conform to required interface Y
    /// -- think of electrical adapter
    /// </summary>
    public class AdapterDemo
    {
        public class Point
        {
            public int X, Y;

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        public class Line
        {
            public Point Start, End;

            public Line(Point start, Point end)
            {
                Start = start;
                End = end;
            }
        }

        public class VectorObject : Collection<Line>
        {
            
        }

        public class VectorRectangle : VectorObject
        {
            public VectorRectangle(int x, int y, int width, int height)
            {
                Add(new Line(new Point(x, y), new Point(x + width, y)));
                Add(new Line(new Point(x + width, y), new Point(x + width, y + height)));
                Add(new Line(new Point(x, y), new Point(x, y + height)));
                Add(new Line(new Point(x, y + height), new Point(x + width, y + height)));
            }
        }

        public class LineToPointAdapter : Collection<Point>
        {
            private static int count;

            public LineToPointAdapter(Line line)
            {
                WriteLine($"{++count}: Generating points for line [{line.Start.X}, {line.Start.Y}]-[{line.End.X}, {line.End.Y}]");

                int left = Math.Min(line.Start.X, line.End.X);
                int right = Math.Max(line.Start.X, line.End.X);
                int top = Math.Min(line.Start.Y, line.End.Y);
                int bottom = Math.Max(line.Start.Y, line.End.Y);
                int dx = right - left;
                int dy = line.End.Y - line.Start.Y;

                if (dx == 0)
                {
                    for (int y = top; y <= bottom; ++y)
                    {
                        Add(new Point(left, y));
                    }
                }
                else if (dy == 0)
                {
                    for (int x = left; x <= right; ++x)
                    {
                        Add(new Point(x, top));
                    }
                }
            }
        }

        private static readonly List<VectorObject> vectorRectangles = new List<VectorObject>
        {
            new VectorRectangle(1,1,10,10),
            new VectorRectangle(3,3,6,6),
        };

        public static void DrawPoint(Point p)
        {
            Write(".");
        }



        //static void Main(string[] args)
        //{
        //    Draw();
        //    Draw();

        //    ReadLine();
        //}

        private static void Draw()
        {
            foreach (var vo in vectorRectangles)
            {
                foreach (var line in vo)
                {
                    var adapter = new LineToPointAdapter(line);
                   
                    foreach (var a in adapter)
                    {
                        DrawPoint(a);
                    }
                }
            }
        }


    }
}

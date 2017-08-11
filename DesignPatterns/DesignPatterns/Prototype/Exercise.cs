namespace DesignPatterns.Prototype
{
    public class Exercise
    {
        public class Point
        {
            public int X, Y;
        }

        public class Line
        {
            public Point Start, End;

            public Line DeepCopy()
            {
                var start = new Point {X = this.Start.X, Y = this.Start.Y};
                var end = new Point {X = End.X, Y = End.Y};
                return new Line {Start = start, End = end};
            }
        }
    }
}

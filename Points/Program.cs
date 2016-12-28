using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
    public class Point :ICloneable
    {
        double x, y;
        public Point()
        {
            x = 0.0; y = 0.0;
        }
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public void Move(double dx, double dy)
        {
            this.x += dx;
            this.y += dy;
        }
        public double DistanceTo(Point p)=> Math.Sqrt(Math.Pow(p.x - this.x, 2) + Math.Pow(p.y - this.y, 2));
        public void Write() => Console.Write($"({x},{y})");
        public override string ToString() => $"({x},{y})";

        public object Clone()
        {
            return new Point(this.x, this.y);
        }
    }
    public class Line
    {
        Point A, B;
        public Line(Point A, Point B)
        {
            this.A = (Point) A.Clone();      // Try with:  this.A = A;
            this.B = (Point) B.Clone();      // Try with:  this.B = B;
        }
        public Line(double x1, double y1, double x2, double y2)
        {
            this.A = new Points.Point(x1, y1);
            this.B = new Points.Point(x2, y2);
        }
        public double Length
        {
            get
            {
                return A.DistanceTo(B);
            }
        }
        public override string ToString() => $"Line from {A.ToString()} to {B.ToString()}";
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            Point A, B;
            A = new Point(-2,0);
            B = new Point(1, 4);
            //A.Write();
            //B.Write();
            Console.WriteLine($"The distance between point {A.ToString()} and {B.ToString()} is {A.DistanceTo(B)}");

            Line L1 = new Line(A, B);
            Console.Write(L1.ToString());
            Console.WriteLine($", Lenght = {L1.Length}");

            A.Move(1, 1);
            Console.WriteLine($"Point A moved to {A.ToString()}");
            Console.Write($"L1: {L1.ToString()}");
            Console.WriteLine($", Lenght = {L1.Length}");

            Line L2 = new Line(-2, 0, 1, 4);
            Console.Write($"L2: {L2.ToString()}");
            Console.WriteLine($", Lenght = {L2.Length}");

            Console.ReadKey();
        }
    }
}

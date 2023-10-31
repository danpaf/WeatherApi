using ConsoleApp1.Interfaces;

namespace ConsoleApp1.Classes;

public class Point : IClonable<Point>
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Point Clone()
    {
        return new Point(this.X, this.Y);
    }
}
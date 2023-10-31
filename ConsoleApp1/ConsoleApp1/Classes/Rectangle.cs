using ConsoleApp1.Interfaces;

namespace ConsoleApp1.Classes;

public class Rectangle : IClonable<Rectangle>
{
    public Point TopLeft { get; set; }
    public Point BottomRight { get; set; }

    public Rectangle(Point topLeft, Point bottomRight)
    {
        TopLeft = topLeft;
        BottomRight = bottomRight;
    }

    public Rectangle Clone()
    {
        return new Rectangle(this.TopLeft.Clone(), this.BottomRight.Clone());
    }
}
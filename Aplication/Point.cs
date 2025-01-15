using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application;

public readonly struct Point
{
    public readonly int X, Y;
    public Point(int x, int y) => (X, Y) = (x, y);
    public override string ToString() => $"({X},{Y})";
    public Point Next(Direction direction)
    {
        Point p1 = new Point(X, Y);
        if (direction == Direction.Up)
            p1 = new Point(X, Y + 1);
        else if (direction == Direction.Down)
            p1 = new Point(X, Y - 1);
        else if (direction == Direction.Left)
            p1 = new Point(X - 1, Y);
        else if (direction == Direction.Right)
            p1 = new Point(X + 1, Y);
        return p1; 
    }
    
    // rotate given direction 45 degrees clockwise
    public Point NextDiagonal(Direction direction)
    {
        Point p1 = new Point(X, Y);
        if (direction == Direction.Up)
            p1 = new Point(X + 1, Y + 1);
        else if (direction == Direction.Down)
            p1 = new Point(X - 1, Y - 1);
        else if (direction == Direction.Left)
            p1 = new Point(X - 1, Y + 1);
        else if (direction == Direction.Right)
            p1 = new Point(X + 1, Y - 1);
        return p1;
    }

}

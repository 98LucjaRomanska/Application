using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Rectangle
    {
        public readonly int X1, Y1, X2, Y2;
        private Point a,b;
        //X1,Y1 - lewy dolny kąt
        public Rectangle(int x1, int y1, int x2, int y2)
        {
            if (x1 == x2 || y1 == y2)
                throw new ArgumentException("Nie chcemy chudych prostokątów");

            X1 = x1; Y1 = y1;
            X2 = x2; Y2 = y2;

            if (x1 > x2)
            {
                X2 = x1;
                X1 = x2;
            }
            if (y1 > y2)
            {
                Y2 = y1;
                Y1 = y2;
            }

        }
        public Rectangle(Point p1, Point p2) : this(p1.X, p1.Y, p2.X, p2.Y)
        {
            p1 = new Point(p1.X, p1.Y);
            p2 = new Point(p2.X, p2.Y);
        }

        public override string ToString() => $"({X1}, {Y1}):({X2}, {Y2})";

        public bool Contains(Point point) 
        {
            if (point.X <= X2 && point.Y <=Y2 && point.X >=X1 && point.Y >=Y1)
                return true;
            else
                return false;

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Maps
{
    public class SmallTorusMap : SmallMap
    {
        public override string Name { get => "SmallTorusMap"; }
        public int Size { get; }
        private Rectangle rex;
        public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }
        public override string ToString()
        {
            return $"({0},{0})-({SizeX - 1},{SizeY - 1})";
        }


        
        public Point Wrapper(Point p)
        {
            //(1,1)
            // (1 + 20) % 20 = 1 - robienie kółka wokół mapy
            int wrapX = (p.X + SizeX) % SizeX;
            int wrapY = (p.Y + SizeY) % SizeY;

            return new Point(wrapX, wrapY);
        }
        public override Point Next(Point p, Direction d)
        {
            Point newPoint = p.Next(d);
            newPoint = Wrapper(newPoint);
            return newPoint;
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            Point newPoint = p.NextDiagonal(d);
            newPoint = Wrapper(newPoint);
            return newPoint;
        }
    }
}

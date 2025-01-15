using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Maps
{
    public class SmallSquareMap : SmallMap
    {
        public int Size { get; }
        //każda mapa ma swój słownik

        //private Dictionary<Point, List<Creature>> dict = new();
        //private List<Creature> list = new();


        public override string Name { get => "SmallSquareMap"; }

        private Rectangle rex;
        public SmallSquareMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            rex = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
        }
        public override string ToString()
        {
            return $"({0},{0})-({SizeX - 1},{SizeY - 1})";
        }


        public override Point Next(Point p, Direction d)
        {
            if (!Exist(p.Next(d)))
                return p;
            else
                return p.Next(d);
            
        }
        public override Point NextDiagonal(Point p, Direction d)
        {
            Point newPoint = p.NextDiagonal(d);

            if (!Exist(newPoint))
                return p;
            else return newPoint;
        }



        //brakuje kodu z refaktoryzacji w drugiej mapie i nie ma At

        
    }
}

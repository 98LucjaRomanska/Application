using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Maps;

public class SmallMap : Map
{
    private Rectangle rex;
    public override string Name { get; } 
    public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20 || sizeY > 20)
            throw new ArgumentOutOfRangeException("Given size is exceeding the width or height.");
        SizeX = sizeX;
        SizeY = sizeY;

        rex = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
    }
    


    public override Point Next(Point p, Direction d)
    {
        throw new NotImplementedException();
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        throw new NotImplementedException();
    }
    
     
    
}

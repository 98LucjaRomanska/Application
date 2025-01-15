using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application;

public class DirectionParser
{
    public DirectionParser() { }

    public static List<Direction> Parse(string d)
    {
        List<Direction> list = new();

        for (int i = 0; i < d.Length; i++)
        {

            string c = d[i].ToString().ToLower();
            if (c == "l")
            {
                list.Add(Direction.Left);
            }
            else if (c == "r")
            {
                list.Add(Direction.Right);
            }
            else if (c == "d")
            {
                list.Add(Direction.Down);
            }
            else if (c == "u")
            {
                list.Add(Direction.Up);
            }
        }
        return list;
    }
}

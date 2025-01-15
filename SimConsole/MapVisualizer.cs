using Application.Maps;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
//using System.Linq.Expressions;
using System.Text;


namespace Application;

public class MapVisualizer
{
    private Map Map;
    public MapVisualizer(Map map)
    {
        Map = map;
    }

    public void Draw()
    {
        Console.OutputEncoding = Encoding.UTF8;

        int kolumny = Map.SizeX - 1;
        int wiersze = Map.SizeY - 1;

        //góra
        Console.Write($"{Box.TopLeft}{Box.Horizontal}");
        for (int i = 0; i < kolumny; i++)
        {
            Console.Write($"{Box.TopMid}{Box.Horizontal}");
        }
        Console.Write($"{Box.TopRight}");

        //środek
        for (int i = wiersze; i >= 0; i--)
        {
            Console.Write($"\n{Box.Vertical}");
            for (int j = 0; j < kolumny + 1; j++)
            {
                var c = Map.At(j, i);
                if (c != null && c.Count != 0)
                {
                    switch (c.Count)
                    {
                        case 1:
                            Console.Write($"{c[0].Name.Substring(0,1)}{Box.Vertical}");
                            break;
                        case > 1:
                            Console.Write($"{c[0].Name.Substring(0, 1)}{c[1].Name.Substring(0, 1)}{Box.Vertical}");
                            break;
                    }
                }
                else
                {
                    Console.Write(' ');
                    Console.Write(Box.Vertical);
                }
                
            }

            if (i > 0)
            {
                Console.Write($"\n{Box.MidLeft}{Box.Horizontal}");
                var middle = $"{Box.Cross}{Box.Horizontal}";
                for (int x = 0; x < kolumny - 1; x++)
                {
                    Console.Write(middle);
                }
                Console.Write($"{Box.Cross}{Box.Horizontal}{Box.MidRight}");
            }
            else
            {
                Console.Write($"\n{Box.BottomLeft}{Box.Horizontal}");
                var middle = $"{Box.BottomMid}{Box.Horizontal}";
                for (int x = 0; x < kolumny - 1; x++)
                {
                    Console.Write(middle);
                }
                Console.Write($"{Box.BottomMid}{Box.Horizontal}{Box.BottomRight}\n");
            }
        }
    }


}

/*
public class MapVisualizer(Map map)
{
    public List<Creature> ListC { get; }
    
    public Map Map { get; } = map;  
    public Simulation SimultoGet { get; }
    public char Symbol { get; }


    public void Draw()
    {

        Console.Write(Box.TopLeft);

        for (int i = 0; i < map.SizeX - 1; i++)
        {
            Console.Write($"{Box.Horizontal}{Box.TopMid}");
        }
        Console.WriteLine($"{Box.Horizontal}{Box.TopRight}");

        for (int j = map.SizeY - 1; j >= 0; j--)
        {
            Console.Write(Box.Vertical);
            for (int i = 0; i < map.SizeX; i++)
            {
                var c = map.At(i, j);
                if (c != null && c.Count != 0)
                {
                    switch (c.Count)
                    {
                        case 1:
                            Console.Write($"{c[0].Symbol}{Box.Vertical}");
                            break;
                        case > 1:
                            Console.Write($"X{Box.Vertical}");
                            break;
                    }
                }
                else
                {
                    Console.Write(' ');
                    Console.Write(Box.Vertical);
                }



            }
            //Console.WriteLine();

            if (j > 0)
            {
                Console.Write($"\n{Box.MidLeft}{Box.Horizontal}");
                var middle = $"{Box.Cross}{Box.Horizontal}";
                for (int x = 0; x < Map.SizeX - 1; x++)
                {
                    Console.Write(middle);
                }
                Console.Write($"{Box.Cross}{Box.Horizontal}{Box.MidRight}");
            }
            else
            {
                Console.Write($"\n{Box.BottomLeft}{Box.Horizontal}");
                var middle = $"{Box.BottomMid}{Box.Horizontal}";
                for (int x = 0; x < Map.SizeX - 1; x++)
                {
                    Console.Write(middle);
                }
                Console.Write($"{Box.BottomMid}{Box.Horizontal}{Box.BottomRight}\n");
            }

        }

    }
}*/

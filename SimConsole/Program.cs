using System.Text;
using Application.Maps;
using Application;
using System.Reflection.Emit; 

namespace Application;

internal class Program
{
    static void Main(string[] args)
    {
        
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Hello, World!");

        SmallTorusMap map = new(8,7);
        List<IMappable> mappables = [new Character ("Dwarf"), new Plant("Kaladium"), new Plant("Kliwia")];
        List<Point> points = [new(2, 1), new(4,3), new(7,6)];
        string moves = "uuuurrrruuullluuu";
         
        Simulation simulation = new(map, mappables, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);
        mapVisualizer.Draw();

        int turn = 1;
        try
        {
            for (int i = 0; i < moves.Length; i++)
            {
                Console.ReadKey();
                Console.WriteLine($"Turn {turn}");
                Console.WriteLine($"{simulation.CurrentMappable.Info} goes {simulation.CurrentMoveName}");
                mapVisualizer.Draw();
                simulation.Turn();
                turn++;
            }
        }
        catch(InvalidOperationException ex)
        {
            Console.WriteLine(ex);
        }
        
    }
}

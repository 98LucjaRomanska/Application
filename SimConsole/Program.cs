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
        List<Creature> creatures = [new Creature("Elandor"),new Creature("Gorbag"), new("Dwarf")];
        List<Point> points = [new(2, 1), new(4,3), new(7,6)];
        string moves = "uuuuuuuuuu";
         
        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);
        mapVisualizer.Draw();

        int turn = 1;
        try
        {
            for (int i = 0; i < moves.Length; i++)
            {
                Console.ReadKey();
                Console.WriteLine($"Turn {turn}");
                Console.WriteLine($"{simulation.CurrentCreature.Name} goes {simulation.CurrentMoveName}");
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

using System.Text;
using Application.Maps;
using Application;
using System.Reflection.Emit;
using System.Data.SqlTypes;

namespace Application;

internal class Program
{
    static void Main(string[] args)
    {
        
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Hello, World!");

        SmallTorusMap map = new(8,7);
        List<IMappable> mappables = [new Plant("Kaladium"), new Plant("Kliwia"), new Plant("Kaktus"), new Plant("Kostrzewa"), new Plant("Konwalia"), new Plant("Kminek")];
        IMappable character = new Character("Ogrodnik John");
        Point charpost = new(2, 1);
        List<Point> points = [new(2,2), new(2,3), new(2,5), new(2,6), new(5,6), new(6,5)];
        string seqmoves = "uuuuurrrrrrr";
        string moves = "urldrulrdulrdlrlrlrlrlrlrl";
        List<SimulationHistory> history = [];
        
        Simulation simulation = new(map, character, mappables, charpost, points, moves, seqmoves);

        //SimulationHistory simHistory = new(simulation);

        MapVisualizer mapVisualizer = new(simulation.Map);
        mapVisualizer.Draw();


        
        int turn = 1;

        Console.WriteLine($"Ruchy ogrodnika {seqmoves.Length} ruchy kwiatów {moves.Length}");
        try
        {
            for (int i = 0; i < seqmoves.Length; i++)
            {
                Console.ReadKey();
                Console.WriteLine($"Turn {turn}");
                //Console.WriteLine($"{simulation.CurrentMappable.Info} goes {simulation.CurrentMoveName}");
                Console.WriteLine($"{character.Info} goes {simulation.CurrentSeqMove}"); // to musi być osobne
                Console.WriteLine($"{character.Info} stands at {character.Position}");
                simulation.Turn();
                turn++;
                
                mapVisualizer.Draw();
                //simulation.Turn();
                //turn++;

            }
        }
        catch(InvalidOperationException ex)
        {
            Console.WriteLine(ex);
        }
        //turn -1 to index
       
        

        
    }

}

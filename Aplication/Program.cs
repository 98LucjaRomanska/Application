using Application.Maps;
using System.Data;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SmallSquareMap sqMap = new(20,20);


            //Dictionary<Creature, Point> dict = new();
            var mod = new Creature("Modliszka", 1);
            var elf = new Creature("Elf");
            var ork = new Creature("Ork");
            var p0 = new Point(8, 10);
            var p1 = new Point(7, 10);
            var p2 = new Point(9, 10);
            
            List<Creature> list =[mod, elf, ork];

            List<Point> positions = [
                new Point(2,3),
                new Point(2,4),
                new Point(2,5)
                ];
            int turn = 0; 
            Simulation sim = new(sqMap,list,positions,"drulu");
            try
            {
                Console.WriteLine(sqMap.At(new Point(2, 5)));
                Console.WriteLine(sqMap.At(p0));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }
           
            
            
            

        }
        static void Lab7()
        {
            //check propriety of moving Next2
            var sqMap = new SmallSquareMap(20, 20);
            List<Direction> destination = new() {
                Direction.Up,
                Direction.Down,
                Direction.Left,
                Direction.Right,
                };

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(sqMap.Next(new Point(19, 19), destination[i]));
                Console.WriteLine($"{sqMap.Next(new Point(0, 0), destination[i])}\n");
            }
        }
        static void Lab1to5()
        {
            //wszystkie testy walnij tu 
            Console.WriteLine("Hello, World!");
            Creature dolores = new("Dolores", 7);
            Creature orlando = new("Orlando", 0);
            Console.WriteLine(dolores.Name);

            List<Direction> destination = new() {
                Direction.Up,
                Direction.Down,
                Direction.Left,
                Direction.Right,
                Direction.Up,
                };
            for (int i = 0; i < 5; i++)
            {
                dolores.Upgrade();
                Console.Write(dolores.Info);
                
            }
            /*
            Direction[] directions = {
            Direction.Right, Direction.Left, Direction.Left, Direction.Down
            };*/

            //dolores.Go(directions);
            Console.WriteLine();
            /*
            string urlu = "urlul";
            dolores.Go(urlu);*/

            Point p = new(10, 25);
            Console.WriteLine(p.Next(Direction.Right));
            Console.WriteLine(p.NextDiagonal(Direction.Right));  // (11, 24)
            try
            {
                Rectangle rectangle = new Rectangle(9, 3, 9, 4);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Rectangle rec1 = new Rectangle(10, 4, 9, 3);
            Console.WriteLine(rec1.ToString());
            Rectangle rec2 = new Rectangle(10, 3, 9, 4);
            Console.WriteLine(rec2.ToString());
            var p1 = new Point(9, 4);
            var p2 = new Point(10, 3);
            Rectangle rec3 = new Rectangle(p1, p2);

            Console.WriteLine(rec3.ToString());
            Console.WriteLine(rec3.Contains(p));
  
            try
            {
                SmallSquareMap sqmMap = new(4, 4);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            /*
            SmallSquareMap sqMap = new(20,20);
            Console.WriteLine(sqMap.Exist(new Point(20, 0)));
            Console.WriteLine(sqMap.Exist(new Point(20, 20)));
            Console.WriteLine(sqMap.Exist(new Point(19, 19)));
            Console.WriteLine(sqMap);*/
        }
    }

        
}

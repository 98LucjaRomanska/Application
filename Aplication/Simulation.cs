using Application.Maps;
using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application;
public class Simulation
{
    public Dictionary<Point, List<IMappable>> Dictr { get => dictr; }
    private Dictionary<Point, List<IMappable>> dictr;
    //private List<IMappable> list = new List<IMappable>();
    //public List<IMappable> ListC { get => list; }
    private List<Direction> DirectionsParsed { get;  }
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Mappables moving on the map.
    /// </summary>
    public List<IMappable> Mappables { get; }

    /// <summary>
    /// Starting positions of mappables.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of mappables moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all mappables make moves, 
    /// next move is again for first creature and so on.
    /// </summary>

    public string Moves { get; }
    private int currentTurn = 0;



    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// IMappable which will be moving in current turn.
    /// </summary>
    public IMappable CurrentMappable => Mappables[currentTurn % Mappables.Count];

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName 
    { get 
        {
            
            return DirectionsParsed[currentTurn % DirectionsParsed.Count].ToString().ToLower();
        } 
    }

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if mappables' list is empty,
    /// if number of mappables differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IMappable> mappables,
        List<Point> positions, string moves)
    {
        if (mappables == null || mappables.Count == 0 )
            throw new ArgumentNullException("List is empty");

        if (positions == null)
            throw new ArgumentNullException("Positions not delivered.");
        
        if (positions.Count != mappables.Count)
            throw new ArgumentException("Number of mappables differs from number of starting positions");


        Map = map;
        Mappables = mappables; //Application.Generic
        Positions = positions;
        Moves = moves;
        DirectionsParsed = ValidateMoves(moves);

      
        


        //mappables muszą być inicjalizowane na mapie w symulatorze
        for (int j= 0; j < positions.Count; j++)
        {
            mappables[j].InitializeMap(map, positions[j]);
            //Map.Add(positions[j], mappables[j]);
            //2 razy dodaję stworzenie do mapy
        }

    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn() 
    {

        //case when Moves.Length is smaller
        if (Moves.Length < currentTurn) //moves= 5 currentTurn= 18
                                        //5%18 = 5, 5%19 = 5 0*19 + 5 = 5 
                                        //5%3 = 2 odp 1*3 + 2 = 5
        
            throw new ArgumentException("The number of moves must be greater than the number of turns");

        var parsedMoves = DirectionParser.Parse(Moves);
        if (parsedMoves.Count == 0)
            throw new InvalidOperationException("No moves available");
        var direction = DirectionsParsed[currentTurn% DirectionsParsed.Count];
        
        CurrentMappable.Go(direction);
                
        currentTurn++;
        
        if (currentTurn >= Moves.Length)
        { 
                Finished = true;
        }
        if (Finished)
            throw new InvalidOperationException("Simulation is finished");         
    
    
        
    }
    private List<Direction> ValidateMoves(string moves)
    {
        return moves
            .Where(c => "lurd".Contains(char.ToLower(c))) //filters a sequence of values based on a predicate
            .Select(c => DirectionParser.Parse(c.ToString()).FirstOrDefault())
            .ToList();
    }
}
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
    /*do simulationhistory*/
    private string? moveTaken;
    public string ReturnMoveTaken() => moveTaken;
    private string? seqmoveTaken;
    public string ReturnSeqMoveTaken() => seqmoveTaken;
    //delegat który skraca długość 

    public Point MainPosition { get; }
    public IMappable Character { get; }
    private List<Direction> DirectionsParsed { get; }
    private List<Direction> DirectionsParsedCh { get; }
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
    public string SeqMoves { get; }
    private int currentTurn = 0;

    public IMappable MovedMappableInfo;

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
    public string CurrentSeqMove
    {
        get
        {
            return DirectionsParsedCh[currentTurn % DirectionsParsedCh.Count].ToString().ToLower();
        }
    }

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if mappables' list is empty,
    /// if number of mappables differs from 
    /// number of starting positions.
    /// </summary>
    // Simulation simulation = new(map, charakter, mappables, charpost, points, moves);
    public Simulation(Map map, IMappable character, List<IMappable> mappables, Point mainPosition,
        List<Point> positions, string moves, string seqmoves)
    {
        if (mappables == null || mappables.Count == 0)
            throw new ArgumentNullException("List is empty");

        if (positions == null)
            throw new ArgumentNullException("Positions not delivered.");

        if (positions.Count != mappables.Count)
            throw new ArgumentException("Number of mappables differs from number of starting positions");
        if (seqmoves.Length != seqmoves.Length)
            throw new ArgumentException("Desired equal number of moves for character and plants.");
        if (map is null)
            throw new ArgumentNullException("Map isn't assigned.");

        Map = map;
        Mappables = mappables; //Application.Generic
        Positions = positions;
        Moves = moves;
        Character = character;
        MainPosition = mainPosition;
        SeqMoves = seqmoves;

        DirectionsParsed = ValidateMoves(moves);
        DirectionsParsedCh = ValidateMoves(seqmoves);
        MovedMappableInfo= Mappables[0];
        //movedMappableInfo zmienia się w każdej turze dla
        /*każdego kwiatka
         * Character porusza się w każdej turze więc nie potrzebuje licznika
         * musisz zaimplementować żeby historia dodawała też Character
        */
        character.InitializeMap(map, mainPosition);
        RemoveFlowers();

        for (int j = 0; j < positions.Count; j++)
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
        var parsedSeqmoves = DirectionParser.Parse(SeqMoves);
        if (parsedMoves.Count == 0 || parsedSeqmoves.Count == 0)
            throw new InvalidOperationException("No moves available");

        var direction = DirectionsParsed[currentTurn % DirectionsParsed.Count];
        var dirForCharacter = DirectionsParsedCh[currentTurn % DirectionsParsedCh.Count];
        Character.Go(dirForCharacter); // to musi być inne direction
        CurrentMappable.Go(direction);

        moveTaken = CurrentMoveName;
        seqmoveTaken = CurrentSeqMove;

        FlowerOnCharacter();
        currentTurn++;

        if (currentTurn >= Moves.Length)
        {
            Finished = true;
        }
        if (Finished)
            throw new InvalidOperationException("Simulation is finished");

        
        



    }
    public void RemoveFlowers()
    {
        //tą funkcję mogę też włożyć do inicjalizacji punktu 
        // z listy IMappables usuwam kwiata K

        // może nie działać bo nie ma aktualizacji punktów w symulatorze
        //dodaj wyświetlanie pozycji do programu
        if (Character.Position.X == CurrentMappable.Position.X && Character.Position.Y == CurrentMappable.Position.Y)
        {
            Map.Remove(CurrentMappable.Position, CurrentMappable);
            CurrentMappable.InitializeRemove(Map, CurrentMappable.Position);
            Mappables.Remove(CurrentMappable);
        }

        //dodaje jego punkty mocy 
    }
    public void FlowerOnCharacter()
    {
        /*
        if (Character.Position.X == CurrentMappable.Position.X && Character.Position.Y == CurrentMappable.Position.Y)
        {
            Character.Upgrade();
        }*/
        if (Map.At(Character.Position).Count >= 2)
        {
            Character.Upgrade();
            Console.WriteLine($"{Character.Name} waters a flower.");
        }
    }
    private List<Direction> ValidateMoves(string moves)
    {
        return moves
            .Where(c => "lurd".Contains(char.ToLower(c))) //filters a sequence of values based on a predicate
            .Select(c => DirectionParser.Parse(c.ToString()).FirstOrDefault())
            .ToList();
    }


}
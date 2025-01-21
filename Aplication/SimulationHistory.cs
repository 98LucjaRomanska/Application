using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Application.Maps;

namespace Application;

public class SimulationHistory
{

    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = [];
    public List<SimulationCharacterTurnLog> TurnCharacterLogs { get; } = [];

    //może jednak robić zdjęcia symulacji w turn 
    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ??
            throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
        Run();

    }

    private void Run()
    {
        var symbs = new Dictionary<Point, char>();
        foreach (var symb in _simulation.Mappables)
        {
            if (symbs.ContainsKey(symb.Position))
                symbs[symb.Position] = 'X';
        }

        TurnLogs.Add(new SimulationTurnLog()
        {

            Mappable = _simulation.MovedMappableInfo.ToString(),
            Move = _simulation.ReturnMoveTaken(),
            Symbols = symbs
        });
        var symbsCh = new Dictionary<Point, char>();
        symbsCh?.Add(_simulation.Character.Position, _simulation.Character.Symbol);
        TurnCharacterLogs.Add(new SimulationCharacterTurnLog()
        {
            Character = _simulation.Character.Name,
            SeqMove = _simulation.ReturnSeqMoveTaken(),
            Symbols = symbsCh

        });

        while (!_simulation.Finished)
        {
            _simulation.Turn();
            //bierze wszystkie IMappable i wrzuca je do zmiennej, aby potem dać do Turnloga
            symbs = new Dictionary<Point, char>();
            foreach (var symb in _simulation.Mappables)
            {
                if (symbs.ContainsKey(symb.Position)) symbs[symb.Position] = 'X';
                else symbs.Add(symb.Position, symb.Symbol);
            }

            TurnLogs.Add(new SimulationTurnLog()
            {

                Mappable = _simulation.MovedMappableInfo.ToString(),
                Move = _simulation.ReturnMoveTaken(),
                Symbols = symbs
            });

            symbsCh = new Dictionary<Point, char>();
            symbsCh?.Add(_simulation.Character.Position, _simulation.Character.Symbol);
            TurnCharacterLogs.Add(new SimulationCharacterTurnLog()
            {
                Character = _simulation.Character.Name,
                SeqMove = _simulation.ReturnSeqMoveTaken(),
                Symbols = symbsCh

            });
            
            
            
            
        }


    }
}

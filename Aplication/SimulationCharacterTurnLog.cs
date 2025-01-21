using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application;

public class SimulationCharacterTurnLog
{
    public required string Character { get; init; }
    public required string SeqMove{ get; init; }
    public required Dictionary<Point, char> Symbols { get; init; }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Maps;
namespace Application;

public class SimulationTurnLog
{
    /// <summary>
    /// Text representastion of moving object in this turn.
    /// CurrentMappable.ToString() <summary>
    /// Text representastion of moving object in this turn.
    /// </summary>
    public required string Mappable { get; init;}
    public required string Move { get; init;}
    public required Dictionary<Point, char> Symbols { get; init; }
    
}

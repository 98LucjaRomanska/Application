using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Maps;

public interface IMappable
{
    char Symbol { get; }
    Point Position { get; }
    string Name { get; }
    string ToString();
    void InitializeMap(Map map, Point position);
    void InitializeRemove(Map map, Point position);
    void Upgrade();
    string Info { get; }

    void Go(Direction d);
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Security;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using Application.Maps;

namespace Application;

public class Creature : IMappable
{
    private string name;
    private int level;
    private Map map;

    public virtual char Symbol { get => 'C'; }


    public Map? Map { get; private set; }

    public Point Position { get; private set; }
    public int Level
    {
        get => level;
        init {
            level = value;
            if (level < 0) level = 0;
            else if (level > 10) level = 10;
        }
    }
    public string Name { get { return name; } init { name = value; } }
    public Creature(string name, int level= 0)
    {
        Name = name;
        Level = level;
    }

    public void InitializeMap(Map map, Point position)
    {

        if (map == null)
            throw new ArgumentNullException(nameof(Map));
        Map = map;
        Position = position;
        map.Add(position, this);//inicjalizowanie stwora na mapie
    }
    public void InitializeRemove(Map map, Point position)
    {
        if (map == null)
            throw new ArgumentNullException(nameof(Map));
        Map = map;
        Position = position;
        map.Remove(position, this);
    }
    public string Info
    {
        get { return $"{Name} [{Level}]"; }
    }

    public void Upgrade()
    {
        if (level < 10) level++;
    }

    void IMappable.Upgrade() => this.Upgrade();
    public virtual void Go(Direction d)
    {
        if (Map == null)
            throw new InvalidOperationException("The creature can't move while not being on the map");
        var move = Map.Next(Position, d);
        Map.Move(Position, move, this);
        Position = move;
        
    }
    void IMappable.Go(Direction direction)
    {
        this.Go(direction);
    }
    string IMappable.Name
    {
        get => this.Name;
    }

    char IMappable.Symbol
    {
        get => this.Symbol;
    }

    //private List<Direction> directions = new List<Direction>();




}

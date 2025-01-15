using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Security;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using Application.Maps;

namespace Application;

public class Creature
{
    private string name;
    private int age;
    private Map map;
    private char symbol = 'C';
    public virtual char Symbol { get => symbol; }

    
    public Map? Map { get; private set; }
    
    public Point Position { get; private set; }
    public int Age
    {
        get => age; 
        init {
            age = value; 
            if (age < 0) age = 0;
            else if (age > 10) age = 10;
        }
    }
    public string Name { get { return name; } init { name = value; } }
    public Creature(string name, int age = 0)
    {
        Name = name;
        Age = age;
    }
    
    public void InitializeMap(Map map, Point position)
    {
        
        if (map == null)
           throw new ArgumentNullException(nameof(Map));
        Map = map;
        Position = position;
        map.Add(position, this);//inicjalizowanie stwora na mapie
    }
    public string Info
    {
        get { return $"{Name} [{Age}]"; }
    }
    public void Upgrade()
    {
        if (age < 10) age ++;
    }
    public void Go(Direction d)
    {
        if (Map == null)
            throw new InvalidOperationException("The creature can't move while not being on the map");
         var move = Map.Next(Position, d);
        Map.Move(Position, move, this);
        Position = move;
        //this.InitializeMap(Map, Position);
    }
    
    //private List<Direction> directions = new List<Direction>();



    
}

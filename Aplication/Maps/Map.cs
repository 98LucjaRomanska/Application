using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    public abstract string Name { get; }
    public int SizeX;
    public int SizeY;
    private Rectangle rex;

    protected Func<Map, Point, Direction, Point>? FNext { get; set; }
    protected Func<Map, Point, Direction, Point>? FNextDiagonal { get; set; }

    private Dictionary<Point, List<Creature>> dict = new();
    private List<Creature> list = new();
    public Map(int sizeX, int sizeY)
    {
        if (sizeX < 5)
            throw new ArgumentOutOfRangeException("Size X is too short.");
        if (sizeY < 5)
            throw new ArgumentOutOfRangeException("Size Y is too short.");
        SizeX = sizeX;
        SizeY = sizeY;
        rex = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
        dict = new Dictionary<Point, List<Creature>>();
    }

    /// <summary>
    /// Check if given point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p) => rex.Contains(p);

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public virtual Point Next(Point p, Direction d) => FNext?.Invoke(this, p, d) ?? p;

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public virtual Point NextDiagonal(Point p, Direction d) => FNextDiagonal?.Invoke(this,p,d) ?? p;

    public void Add(Point point, Creature c)
    {
        if (Exist(point) && !dict.ContainsKey(point))
        {
            dict[point] = new List<Creature>(); 
        }
        dict[point].Add(c);

        if (!Exist(point))
            throw new ArgumentException("Point does not belong to the map.");

    }

    public void Remove(Point point, Creature creature)
    {
        if (!dict.ContainsKey(point)) return; //zwraca niezmieniony pusty punkt 
        //z List<Creature> odejmij stwora
        dict[point].Remove(creature);
        if (dict[point].Count == 0)
        {
            dict.Remove(point);
        }

    }
    public void Move(Point from, Point destined, Creature creature)
    {
        //dodać mechanizm sprawdzający czy dany punkt jest już dictionary w add
        if (!Exist(destined)) throw new ArgumentException("Point does not belong to the map.");
        else
        {
            Remove(from, creature);
            Add(destined, creature);
        }
    }
    public List<Creature>? At(Point point)
    {
        if (dict.ContainsKey(point))
        {
            return dict[point];
        }
        return new List<Creature>();

        
    }
    public List<Creature>? At(int x, int y)
    {
        
        var point = new Point(x, y);
        if (dict.ContainsKey(point))
        {
            return dict[point];
               
        }
        return new List<Creature>();
        
    }
}
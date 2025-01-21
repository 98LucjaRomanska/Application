using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using Application.Maps;
using System.Numerics;

namespace Application
{
    //teraz przydaje mi się klasa imappable
    //żeby stwory róznych klas mogły chodzić po mapie
    public class Plant : IMappable
    {

        private string name;
        public string Name { get; set; }
        private int power; 
        public int Power { get; }
        private Map map;
        public Map? Map { get; private set; }
        public Point Position { get; private set; }
        public virtual char Symbol { get => 'K'; }

        public Plant(string name, int power = 1)
        {
            Name = name;
            Power = power;
        }
        public string Info
        { get => $"{Name} <{Power}>"; }

        public void Upgrade()
        {
            if (power < 10)
            {
                power++;
            }
        }
        public void InitializeMap(Map map, Point position)
        {
            if (map == null)
                throw new ArgumentNullException(nameof(Map));
            Map = map;
            Position = position;
            map.Add(position, this); //inicjalizowanie plant na mapie
        }
        public void InitializeRemove(Map map, Point position)
        {
            if (map == null)
                throw new ArgumentNullException(nameof(Map));
            Map = map;
            Position = position;
            map.Remove(position, this);
        }
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
        void IMappable.InitializeMap(Map map, Point position)
        {
            this.InitializeMap(map, position);
        }

        void IMappable.InitializeRemove(Map map, Point position)
        {
            this.InitializeRemove(map, position);
        }

        void IMappable.Upgrade() => this.Upgrade();
        char IMappable.Symbol => Symbol;

        string IMappable.Info => this.Info;
        /*
        private char symbol => 'K';
        public char Symbol {get { return symbol; } } */
    }
}

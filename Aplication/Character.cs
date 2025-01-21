using Application.Maps;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Character : Creature
    {
        public string Name { get; init; }
        private string name;
        public int Level { get; init; }
        private int level;
        public int Experience { get; init; }
       
        public override char Symbol { get => 'O'; }
        public Character(string name, int level = 0, int experience = 0) : base(name, level)
        {
            Name = name;
            Level = level;
            Experience = experience;

        }
        public string Info
        {
            get { return $"{Name} [{Level}]"; }
        }

        
    }
}

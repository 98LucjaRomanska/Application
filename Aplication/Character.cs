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
        public int Age { get; init; }
        private int age;
        public int Experience { get; init; }
       
        public override char Symbol { get => 'O'; }
        public Character(string name, int age = 0, int experience = 0) : base(name, age)
        {
            Name = name;
            Age = age;
            Experience = experience;

        }
        public string Info
        {
            get { return $"{Name} [{Age}]"; }
        }
        public void Upgrade()
        {
            if (age < 10) age++;
        }
        
    }
}

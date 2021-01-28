using System;
using System.Collections.Generic;

namespace Gladiators
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    interface IFighter
    {
        void SpecialAbility();
    }

    class Fighter
    {
        public int Health { get; private set; }
        public int Damage { get; private set; }
        public int Armor { get; private set; }

        public Fighter(int health, int damage, int armor)
        {
            Health = health;
            Damage = damage;
            Armor = armor;
        }
    }

    class Paladin : Fighter, IFighter
    {
        public Paladin(int health, int damage, int armor) : base(health, damage, armor)
        {

        }

        public void SpecialAbility()
        {
            throw new NotImplementedException();
        }
    }

    class Archer : Fighter, IFighter
    {
        public Archer(int health, int damage, int armor) : base(health, damage, armor)
        {

        }

        public void SpecialAbility()
        {
            throw new NotImplementedException();
        }
    }

    class Mystic : Fighter, IFighter
    {
        public Mystic(int health, int damage, int armor) : base(health, damage, armor)
        {
            
        }

        public void SpecialAbility()
        {
            throw new NotImplementedException();
        }
    }

    class Warrior : Fighter, IFighter
    {
        public Warrior(int health, int damage, int armor) : base(health, damage, armor)
        {

        }

        public void SpecialAbility()
        {
            throw new NotImplementedException();
        }
    }

    class Assassin : Fighter, IFighter
    {
        public Assassin(int health, int damage, int armor) : base(health, damage, armor)
        {
            
        }

        public void SpecialAbility()
        {
            throw new NotImplementedException();
        }
    }
}

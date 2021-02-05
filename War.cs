using System;
using System.Collections.Generic;

namespace War
{
    class Program
    {
        static void Main(string[] args)
        {
            Battle battle = new Battle();
            Army army1 = new Army(20);
            Army army2 = new Army(20);

            battle.Fight(army1, army2);
        }
    }

    class Battle
    {
        public void Fight(Army army1, Army army2)
        {
            while (army1.SoldiersAmount > 0 & army2.SoldiersAmount > 0)
            {
                int soldiersInBattleAmount = Math.Min(army1.SoldiersAmount, army2.SoldiersAmount);
                
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Войско 1:");
                army1.ShowInfo();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Войско 2:");
                army2.ShowInfo();
                Console.ForegroundColor = ConsoleColor.Gray;

                for (var i = 0; i < soldiersInBattleAmount; i++)
                {
                    army1.GetSoldierByIndex(i).TakeDamage(army2.GetSoldierByIndex(i).Damage);
                    army2.GetSoldierByIndex(i).TakeDamage(army1.GetSoldierByIndex(i).Damage);
                }

                army1.RemoveDeadSoldiers();
                army2.RemoveDeadSoldiers();

                Console.WriteLine("Нажмите любую клавишу для продолжения битвы.");
                Console.ReadKey(true);
            }

            if (army1.SoldiersAmount <= 0 && army2.SoldiersAmount <= 0)
            {
                Console.WriteLine("Ничья");
            }
            else if (army1.SoldiersAmount <= 0)
            {
                Console.WriteLine("Первое войско разгромлено");
            }
            else
            {
                Console.WriteLine("Второе войско разгромлено");
            }
        }
    }

    class Army
    {
        private List<Soldier> _soldiers;

        public int SoldiersAmount
        {
            get
            {
                return _soldiers.Count;
            }
        }

        public Army(int soldiersAmount)
        {
            _soldiers = new List<Soldier>();

            for (var i = 0; i < soldiersAmount; i++)
            {
                _soldiers.Add(new Soldier(300, 40, 20));
            }
        }

        public Soldier GetSoldierByIndex(int index)
        {
            return _soldiers[index];
        }

        public void RemoveDeadSoldiers()
        {
            for (var i = 0; i < _soldiers.Count; i++)
            {
                if (_soldiers[i].Health <= 0)
                {
                    _soldiers.Remove(_soldiers[i]);
                    i--;
                }
            }
        }

        public void ShowInfo()
        {
            foreach (var soldier in _soldiers)
            {
                soldier.ShowInfo();
            }
        }
    }

    class Soldier
    {
        private static Random _rand = new Random();
        private List<Ability> _abilities;
        private int _baseHealth;
        private int _baseDamage;
        private int _baseArmor;

        public int Health { get; private set; }
        public int Damage { get; private set; }
        public int Armor { get; private set; }

        public Soldier(int health, int damage, int armor)
        {
            _abilities = new List<Ability>();

            GetAbility();
            foreach (var ability in _abilities)
            {
                ability.SpecialEffect(ref health, ref damage, ref armor);
            }

            _baseHealth = _rand.Next((int)(0.9 * health), (int)(1.1 * health));
            _baseDamage = _rand.Next((int)(0.9 * damage), (int)(1.1 * damage));
            _baseArmor = _rand.Next((int)(0.9 * armor), (int)(1.1 * armor));

            Health = _baseHealth;
            Damage = _baseDamage;
            Armor = _baseArmor;
        }

        public void TakeDamage(int damage)
        {
            if (damage >= Armor)
            {
                Health -= (int)(1.1 * (damage - Armor)) + (int)(0.2 * damage);
            }
            else
            {
                Health -= (int)(0.2 * damage);
            }
        }

        public void GetAbility()
        {
            int abilityRate = _rand.Next(0, 100);
            if (abilityRate < 5)
            {
                AddAllAbilities();
            }
            else if (abilityRate < 10)
            {
                AddHealthAndDamageAbilities();
            }
            else if (abilityRate < 15)
            {
                AddHealthAndArmorAbilities();
            }
            else if (abilityRate < 20)
            {
                AddDamageAndArmorAbilities();
            }
            else if (abilityRate < 30)
            {
                _abilities.Add(new GreatHealth());
            }
            else if (abilityRate < 40)
            {
                _abilities.Add(new GreatDamage());
            }
            else if (abilityRate < 50)
            {
                _abilities.Add(new GreatArmor());
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"ХП: {Health} | Урон: {Damage} | Защита: {Armor}");
        }

        private void AddAllAbilities()
        {
            _abilities.Add(new GreatHealth());
            _abilities.Add(new GreatDamage());
            _abilities.Add(new GreatArmor());
        }

        private void AddHealthAndDamageAbilities()
        {
            _abilities.Add(new GreatHealth());
            _abilities.Add(new GreatDamage());
        }

        private void AddHealthAndArmorAbilities()
        {
            _abilities.Add(new GreatHealth());
            _abilities.Add(new GreatArmor());
        }

        private void AddDamageAndArmorAbilities()
        {
            _abilities.Add(new GreatDamage());
            _abilities.Add(new GreatArmor());
        }
    }

    abstract class Ability
    {
        public abstract void SpecialEffect(ref int health, ref int damage, ref int armor);
    }

    class GreatHealth : Ability
    {
        public override void SpecialEffect(ref int health, ref int damage, ref int armor)
        {
            health *= 2;
        }
    }

    class GreatDamage : Ability
    {
        public override void SpecialEffect(ref int health, ref int damage, ref int armor)
        {
            damage *= 2;
        }
    }

    class GreatArmor : Ability
    {
        public override void SpecialEffect(ref int health, ref int damage, ref int armor)
        {
            armor *= 2;
        }
    }
}

using System;
using System.Collections.Generic;

namespace Gladiators
{
    class Program
    {
        static void Main(string[] args)
        {
            Arena arena = new Arena();
            Fighter fighter1 = arena.ChooseFighter();
            Fighter fighter2 = arena.ChooseFighter();

            arena.Fight(fighter1, fighter2);
        }
    }

    class Arena
    {
        private List<Fighter> _fighters;

        public Arena()
        {
            _fighters = new List<Fighter>();
            _fighters.Add(new Paladin(800, 60, 50));
            _fighters.Add(new Archer(600, 80, 30));
            _fighters.Add(new Mystic(500, 90, 20));
            _fighters.Add(new Warrior(800, 70, 30));
            _fighters.Add(new Assassin(700, 80, 10));
        }

        public Fighter ChooseFighter()
        {
            Fighter fighter;
            int userInput;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Бойцы арены:");
            foreach (var element in _fighters)
            {
                element.ShowInfo();
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Выберите бойца:");
            if(int.TryParse(Console.ReadLine(), out userInput))
            {
                try
                {
                    fighter = _fighters[userInput - 1];
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Такого бойца нет. Выбран боец по умолчанию - Паладин.");
                    fighter = _fighters[0];
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Выбран боец по умолчанию - Паладин.");
                fighter = _fighters[0];
            }
            fighter = fighter.GetNewFighter(fighter);
            
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey(true);

            return fighter;
        }

        public void Fight(Fighter fighter1, Fighter fighter2)
        {
            Console.Clear();

            while (fighter1.Health > 0 & fighter2.Health > 0)
            {
                fighter1.SpecialAbility();
                fighter2.SpecialAbility();
                fighter2.TakeDamage(fighter1.Damage);
                fighter1.TakeDamage(fighter2.Damage);

                Console.WriteLine($"Исходящий урон: {fighter1.Damage} ||| {fighter2.Damage}");
                Console.WriteLine($"Оставшееся хп: {fighter1.Health} ||| {fighter2.Health}");
            }

            if (fighter1.Health <= 0 && fighter2.Health <= 0)
            {
                Console.WriteLine("Оба бойца мертвы.");
            }
            else if (fighter1.Health <= 0)
            {
                Console.WriteLine("Первый боец мертв. Победа второго.");
            }
            else
            {
                Console.WriteLine("Второй боец мертв. Победа первого.");
            }
        }
    }

    abstract class Fighter
    {
        protected static Random Rand = new Random();
        protected int BaseHealth;
        protected int BaseDamage;
        protected int BaseArmor;

        public int Health { get; protected set; }
        public int Damage { get; protected set; }
        public int Armor { get; protected set; }

        public Fighter(int health, int damage, int armor)
        {
            BaseHealth = Rand.Next((int)(0.9 * health), (int)(1.1 * health));
            BaseDamage = Rand.Next((int)(0.9 * damage), (int)(1.1 * damage));
            BaseArmor = Rand.Next((int)(0.9 * armor), (int)(1.1 * armor));

            Health = BaseHealth;
            Damage = BaseDamage;
            Armor = BaseArmor;
        }

        public void TakeDamage(int damage)
        {
            if (damage > Armor)
            {
                Health -= damage - Armor + (int)(0.2 * damage);
            }
            else
            {
                Health -= (int)(0.2 * damage);
            }
        }

        public abstract void SpecialAbility();
        public abstract void ShowInfo();
        public abstract Fighter GetNewFighter(Fighter fighter);
    }

    class Paladin : Fighter
    {
        public Paladin(int health, int damage, int armor) : base(health, damage, armor)
        {
            
        }

        public override void SpecialAbility()
        {
            Armor = BaseArmor;
            int chance = Rand.Next(0, 100);
            if (chance < 30)
            {
                Console.WriteLine("Умение паладина - Защита богов. Броня увеличивается в 2 раза.");
                Armor *= 2;
            }
        }

        public override void ShowInfo()
        {
            Console.WriteLine("1 - Паладин");
            Console.WriteLine("Уникальная способность - Защита богов. Броня увеличивается в 2 раза.");
        }

        public override Fighter GetNewFighter(Fighter fighter)
        {
            return new Paladin(fighter.Health, fighter.Damage, fighter.Armor);
        }
    }

    class Archer : Fighter
    {
        public Archer(int health, int damage, int armor) : base(health, damage, armor)
        {
            
        }

        public override void SpecialAbility()
        {
            Damage = BaseDamage;
            int chance = Rand.Next(0, 100);
            if (chance < 20)
            {
                Console.WriteLine("Умение лучника - Отравленная стрела. Увеличивает урон на 50 %");
                Damage = (int)(Damage * 1.5);
            }
        }

        public override void ShowInfo()
        {
            Console.WriteLine("2 - Лучник");
            Console.WriteLine("Уникальная способность - Отравленная стрела. Увеличивает урон на 50 %");
        }

        public override Fighter GetNewFighter(Fighter fighter)
        {
            return new Archer(fighter.Health, fighter.Damage, fighter.Armor);
        }
    }

    class Mystic : Fighter
    {
        public Mystic(int health, int damage, int armor) : base(health, damage, armor)
        {
            
        }

        public override void SpecialAbility()
        {
            int chance = Rand.Next(0, 100);
            if (chance < 40)
            {
                Console.WriteLine("Умение мистика - Исцеление. Восстанавливает 80 хп.");
                Health += 80;
            }
        }

        public override void ShowInfo()
        {
            Console.WriteLine("3 - Мистик");
            Console.WriteLine("Уникальная способность - Исцеление. Восстанавливает 80 хп.");
        }

        public override Fighter GetNewFighter(Fighter fighter)
        {
            return new Mystic(fighter.Health, fighter.Damage, fighter.Armor);
        }
    }

    class Warrior : Fighter
    {
        public Warrior(int health, int damage, int armor) : base(health, damage, armor)
        {
            
        }

        public override void SpecialAbility()
        {
            Damage = BaseDamage;
            int chance = Rand.Next(0, 100);
            if (chance < 30)
            {
                Console.WriteLine("Умение воина - Гнев предков. Увеличивает урон за счет потери собственного здоровья.");
                Health -= 70;
                Damage *= 2;
            }
        }

        public override void ShowInfo()
        {
            Console.WriteLine("4 - Воин");
            Console.WriteLine("Уникальная способность - Гнев предков. Увеличивает урон за счет потери собственного здоровья.");
        }

        public override Fighter GetNewFighter(Fighter fighter)
        {
            return new Warrior(fighter.Health, fighter.Damage, fighter.Armor);
        }
    }

    class Assassin : Fighter
    {
        public Assassin(int health, int damage, int armor) : base(health, damage, armor)
        {
            
        }

        public override void SpecialAbility()
        {
            Damage = BaseDamage;
            int chance = Rand.Next(0, 100);
            if (chance < 10)
            {
                Console.WriteLine("Умение убийцы - Удар в сердце. Наносит трехкратный урон.");
                Damage *= 3;
            }
        }

        public override void ShowInfo()
        {
            Console.WriteLine("5 - Убийца");
            Console.WriteLine("Уникальная способность - Удар в сердце. Наносит трехкратный урон.");
        }

        public override Fighter GetNewFighter(Fighter fighter)
        {
            return new Assassin(fighter.Health, fighter.Damage, fighter.Armor);
        }
    }
}

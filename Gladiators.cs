using System;

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
        public Paladin Paladin { get; private set; }
        public Archer Archer { get; private set; }
        public Mystic Mystic { get; private set; }
        public Warrior Warrior { get; private set; }
        public Assassin Assassin { get; private set; }

        public Arena()
        {
            Paladin = new Paladin(800, 50, 50);
            Archer = new Archer(600, 80, 30);
            Mystic = new Mystic(500, 90, 20);
            Warrior = new Warrior(800, 70, 30);
            Assassin = new Assassin(800, 90, 10);
        }

        public Fighter ChooseFighter()
        {
            Fighter fighter;
            string userInput;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Бойцы арены:");
            Console.WriteLine("1 - Паладин");
            Console.WriteLine("Уникальная способность - ");
            Console.WriteLine("2 - Лучник");
            Console.WriteLine("Уникальная способность - ");
            Console.WriteLine("3 - Мистик");
            Console.WriteLine("Уникальная способность - ");
            Console.WriteLine("4 - Воин");
            Console.WriteLine("Уникальная способность - ");
            Console.WriteLine("5 - Убийца");
            Console.WriteLine("Уникальная способность - ");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Выберите бойца:");
            userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Выбран паладин");
                    fighter = Paladin;
                    break;
                case "2":
                    Console.WriteLine("Выбран лучник");
                    fighter = Archer;
                    break;
                case "3":
                    Console.WriteLine("Выбран мистик");
                    fighter = Mystic;
                    break;
                case "4":
                    Console.WriteLine("Выбран воин");
                    fighter = Warrior;
                    break;
                case "5":
                    Console.WriteLine("Выбран убийца");
                    fighter = Assassin;
                    break;
                default:
                    Console.WriteLine("Выбран герой по умолчанию - паладин");
                    fighter = Paladin;
                    break;
            }
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey(true);

            return fighter;
        }

        public void Fight(Fighter fighter1, Fighter fighter2)
        {
            bool isFirst = fighter1.Initiative >= fighter2.Initiative;

            Console.Clear();
            Console.WriteLine($"Инициатива 1-го бойца:{fighter1.Initiative}\nИнициатива 2-го бойца: {fighter2.Initiative}");

            while (fighter1.Health > 0 & fighter2.Health > 0)
            {
                if (isFirst)
                {
                    Prioritize(fighter1, fighter2);
                }
                else
                {
                    Prioritize(fighter2, fighter1);
                }
                Console.WriteLine($"Здоровье 1-го бойца: {fighter1.Health}\nЗдоровье 2-го бойца: {fighter2.Health}");
            }

            if (fighter1.Health <= 0 && fighter2.Health <= 0)
            {
                Console.WriteLine("Оба бойца мертвы.");
            }
            else if (fighter1.Health <= 0)
            {
                Console.WriteLine("Первый боец мертв. Победа второго.");
            }
            else if (fighter2.Health <= 0)
            {
                Console.WriteLine("Второй боец мертв. Победа первого.");
            }
        }

        private void Prioritize(Fighter first, Fighter second)
        {
            first.SpecialAbility();
            second.TakeDamage(first.Damage);
            second.SpecialAbility();
            first.TakeDamage(second.Damage);
        }
    }

    abstract class Fighter
    {
        protected Random _rand;

        public int Health { get; protected set; }
        public int Damage { get; protected set; }
        public int Armor { get; protected set; }
        public int Initiative { get; private set; }

        public Fighter(int health, int damage, int armor)
        {
            _rand = new Random();
            Health = health;
            Damage = damage;
            Armor = armor;
            Initiative = _rand.Next(0, 1000);
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
    }

    class Paladin : Fighter
    {
        public Paladin(int health, int damage, int armor) : base(health, damage, armor)
        {

        }

        public override void SpecialAbility()
        {
            int chance = _rand.Next(0, 100);
            if (chance < 30)
            {
                Console.WriteLine("Умение паладина - Защита богов. Броня увеличивается в 2 раза.");
                Armor *= 2;
            }
        }
    }

    class Archer : Fighter
    {
        public Archer(int health, int damage, int armor) : base(health, damage, armor)
        {

        }

        public override void SpecialAbility()
        {
            int chance = _rand.Next(0, 100);
            if (chance < 20)
            {
                Console.WriteLine("Умение лучника - Отравленная стрела. Увеличивает урон на 50 %");
                Damage = (int)(Damage * 1.5);
            }
        }
    }

    class Mystic : Fighter
    {
        public Mystic(int health, int damage, int armor) : base(health, damage, armor)
        {

        }

        public override void SpecialAbility()
        {
            int chance = _rand.Next(0, 100);
            if (chance < 30)
            {
                Console.WriteLine("Умение мистика - Исцеление. Восстанавливает 80 хп.");
                Health += 80;
            }
        }
    }

    class Warrior : Fighter
    {
        public Warrior(int health, int damage, int armor) : base(health, damage, armor)
        {

        }

        public override void SpecialAbility()
        {
            int chance = _rand.Next(0, 100);
            if (chance < 30)
            {
                Console.WriteLine("Умение воина - Гнев предков.");
                Health += 80;
            }
        }
    }

    class Assassin : Fighter
    {
        public Assassin(int health, int damage, int armor) : base(health, damage, armor)
        {

        }

        public override void SpecialAbility()
        {
            int chance = _rand.Next(0, 100);
            if (chance < 30)
            {
                Console.WriteLine("Умение убийцы - Призрак из тени.");
                Health += 80;
            }
        }
    }
}

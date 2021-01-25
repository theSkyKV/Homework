using System;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(100, 20, 10);
            player.ShowInfo();
        }
    }

    class Player
    {
        private int _health;
        private int _damage;
        private int _armor;

        public Player(int health, int damage, int armor)
        {
            _health = health;
            _damage = damage;
            _armor = armor;
        }

        public void ShowInfo()
        {
            Console.WriteLine("Характеристики персонажа:");
            Console.Write($"Здоровье - {_health}\nУрон - {_damage}\nБроня - {_armor}");
        }
    }
}

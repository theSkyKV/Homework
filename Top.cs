using System;
using System.Collections.Generic;
using System.Linq;

namespace Top
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();
            database.GetBestOfLevel();
            Console.WriteLine();
            database.GetBestOfStrength();
        }
    }

    class Database
    {
        private static Random _rand = new Random();
        private List<Player> _players;

        public Database()
        {
            _players = new List<Player>();

            for (var i = 0; i < 30; i++)
            {
                string name = Convert.ToChar(_rand.Next(65, 91)) + "name" + i;
                int level = _rand.Next(0, 101);
                int strength = _rand.Next(10, 300);
                _players.Add(new Player(name, level, strength));
            }
        }

        public void GetBestOfLevel()
        {
            var bestPlayers = _players.OrderByDescending(player => player.Level).Take(3);
            ShowDatabase(bestPlayers);
        }

        public void GetBestOfStrength()
        {
            var bestPlayers = _players.OrderByDescending(player => player.Strength).Take(3);
            ShowDatabase(bestPlayers);
        }

        public void ShowDatabase(IEnumerable<Player> players)
        {
            foreach (var player in players)
            {
                Console.WriteLine($"{player.Name} | {player.Level} | {player.Strength}");
            }
        }
    }

    class Player
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Strength { get; private set; }

        public Player(string name, int level, int strength)
        {
            Name = name;
            Level = level;
            Strength = strength;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Union
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();
            database.Transfer();
        }
    }

    class Database
    {
        private static Random _rand = new Random();
        private List<Soldier> _soldiers1;
        private List<Soldier> _soldiers2;
        private List<string> _armings;
        private List<string> _militaryRanks;

        public Database()
        {
            _soldiers1 = new List<Soldier>();
            _soldiers2 = new List<Soldier>();
            _armings = new List<string>() { "АК-74", "СВД", "Макар" };
            _militaryRanks = new List<string>() { "рядовой", "ефрейтор", "сержант", "лейтенант", "капитан" };

            for (var i = 0; i < 30; i++)
            {
                string name = Convert.ToChar(_rand.Next(65, 70)) + "name" + i;
                string arming = _armings[_rand.Next(0, _armings.Count)];
                string militaryRank = _militaryRanks[_rand.Next(0, _militaryRanks.Count)];
                int serviceLife = _rand.Next(1, 25);

                if (i % 2 == 0)
                    _soldiers1.Add(new Soldier(name, arming, militaryRank, serviceLife));
                else
                    _soldiers2.Add(new Soldier(name, arming, militaryRank, serviceLife));
            }
        }

        public void Transfer()
        {
            var soldiers = _soldiers1.Where(soldier => soldier.Name.StartsWith("B")).Union(_soldiers2);
            ShowDatabase(soldiers);
        }

        public void ShowDatabase(IEnumerable<Soldier> soldiers)
        {
            foreach (var soldier in soldiers)
            {
                Console.WriteLine($"{soldier.Name}");
            }
        }
    }

    class Soldier
    {
        public string Name { get; private set; }
        public string Arming { get; private set; }
        public string MilitaryRank { get; private set; }
        public int ServiceLife { get; private set; }

        public Soldier(string name, string arming, string militaryRank, int serviceLife)
        {
            Name = name;
            Arming = arming;
            MilitaryRank = militaryRank;
            ServiceLife = serviceLife;
        }
    }
}

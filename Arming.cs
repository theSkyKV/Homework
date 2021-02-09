using System;
using System.Collections.Generic;
using System.Linq;

namespace Arming
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();
            database.GetNamesAndRanks();
        }
    }

    class Database
    {
        private static Random _rand = new Random();
        private List<Soldier> _soldiers;
        private List<string> _armings;
        private List<string> _militaryRanks;


        public Database()
        {
            _soldiers = new List<Soldier>();
            _armings = new List<string>() { "АК-74", "СВД", "Макар" };
            _militaryRanks = new List<string>() { "рядовой", "ефрейтор", "сержант", "лейтенант", "капитан" };

            for (var i = 0; i < 30; i++)
            {
                string name = Convert.ToChar(_rand.Next(65, 91)) + "name" + i;
                string arming = _armings[_rand.Next(0, _armings.Count)];
                string militaryRank = _militaryRanks[_rand.Next(0, _militaryRanks.Count)];
                int serviceLife = _rand.Next(1, 25);
                _soldiers.Add(new Soldier(name, arming, militaryRank, serviceLife));
            }
        }

        public void GetNamesAndRanks()
        {
            var newSoldiersList = from Soldier soldier in _soldiers
                                  select new
                                  {
                                      Name = soldier.Name,
                                      MilitaryRank = soldier.MilitaryRank
                                  };
            
            foreach (var soldier in newSoldiersList)
            {
                Console.WriteLine($"{soldier.Name} - {soldier.MilitaryRank}");
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
